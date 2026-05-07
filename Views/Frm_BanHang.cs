using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_BanHang : Form
    {
        private readonly SaleBUS _saleBUS = new SaleBUS();
        private readonly CustomerBUS _customerBUS = new CustomerBUS();
        private readonly ProductBUS _productBUS = new ProductBUS();
        private readonly InvoicePrinter _printer = new InvoicePrinter();

        public Frm_BanHang()
        {
            InitializeComponent();
            SetupGridColumns();

            this.KeyPreview = true;
            this.KeyDown += Frm_BanHang_KeyDown;
            txtSearch.KeyDown += TxtSearch_KeyDown;

            btnSavePrint.Click += (s, e) => HandlePayment(true);
            btnSaveOnly.Click += (s, e) => HandlePayment(false);
            btnCancel.Click += (s, e) => ClearCart();
            btnViewOld.Click += (s, e) => ShowOldInvoices();
        }

        private void ShowOldInvoices()
        {
            // Hiển thị lịch sử đơn hàng của khách hiện tại (Demo)
            int customerID = cboCustomer.SelectedValue != null ? (int)cboCustomer.SelectedValue : 1;
            MessageBox.Show($"Đang tra cứu lịch sử hóa đơn cho khách hàng ID: {customerID}...", "TRA CỨU ĐƠN CŨ");
        }

        private void SetupGridColumns()
        {
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add("VariantID", "ID");
            dgvCart.Columns.Add("ProductName", "Tên Sản Phẩm");
            dgvCart.Columns.Add("Unit", "ĐVT");
            dgvCart.Columns.Add("Quantity", "SL");
            dgvCart.Columns.Add("Price", "Đơn Giá");
            dgvCart.Columns.Add("Total", "Thành Tiền");

            dgvCart.Columns["VariantID"].Visible = false;
            dgvCart.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCart.Columns["Quantity"].Width = 60;
            dgvCart.Columns["Price"].DefaultCellStyle.Format = "N0";
            dgvCart.Columns["Total"].DefaultCellStyle.Format = "N0";
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(keyword)) return;

                var results = _productBUS.SearchProducts(keyword);
                if (results.Count == 1)
                {
                    AddProductToCart(results[0]);
                    txtSearch.Clear();
                }
                else if (results.Count > 1)
                {
                    // Tạm thời lấy cái đầu tiên, thực tế sẽ hiện Popup chọn
                    AddProductToCart(results[0]);
                    txtSearch.Clear();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!", "Thông báo");
                }
            }
        }

        private void AddProductToCart(ProductVariant variant)
        {
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["VariantID"].Value != null && (int)row.Cells["VariantID"].Value == variant.VariantID)
                {
                    int qty = Convert.ToInt32(row.Cells["Quantity"].Value) + 1;
                    row.Cells["Quantity"].Value = qty;
                    row.Cells["Total"].Value = qty * variant.RetailPrice;
                    UpdateTotals();
                    return;
                }
            }

            dgvCart.Rows.Add(variant.VariantID, variant.Product.Name, variant.Unit, 1, variant.RetailPrice, variant.RetailPrice);
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Total"].Value);
            }
            lblTotal.Text = $"Tổng tiền hàng: {total:N0} VNĐ";
            lblFinalPay.Text = $"KHÁCH PHẢI TRẢ: {total:N0}";
        }

        private void Frm_BanHang_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: txtSearch.Focus(); break;
                case Keys.F2: HandlePayment(true); break;
                case Keys.F5: HandlePayment(false); break;
            }
        }

        private void HandlePayment(bool isPrint)
        {
            try
            {
                if (dgvCart.Rows.Count == 0)
                {
                    MessageBox.Show("Giỏ hàng đang trống!", "Thông báo");
                    return;
                }

                var order = new Order
                {
                    CustomerID = cboCustomer.SelectedValue != null ? (int)cboCustomer.SelectedValue : 1,
                    UserID = SessionManager.CurrentUser?.UserID ?? 1,
                    Status = "COMPLETED"
                };

                List<OrderDetail> details = new List<OrderDetail>();
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    details.Add(new OrderDetail
                    {
                        VariantID = Convert.ToInt32(row.Cells["VariantID"].Value),
                        OrderQuantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                        UnitPrice = Convert.ToDecimal(row.Cells["Price"].Value)
                    });
                }

                order.TotalAmount = details.Sum(d => d.OrderQuantity * d.UnitPrice);

                if (_saleBUS.ProcessSale(order, details, order.TotalAmount))
                {
                    if (isPrint) _printer.Print(order, details, _customerBUS.GetCustomerById(order.CustomerID));
                    MessageBox.Show("Thanh toán thành công!", "Thông báo");
                    ClearCart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ClearCart()
        {
            dgvCart.Rows.Clear();
            UpdateTotals();
            txtSearch.Focus();
        }

        private void Frm_BanHang_Load(object sender, EventArgs e)
        {
            try
            {
                var customers = _customerBUS.GetAllCustomers();
                cboCustomer.DataSource = customers;
                cboCustomer.DisplayMember = "Name";
                cboCustomer.ValueMember = "CustomerID";
            }
            catch { }
        }
    }
}
