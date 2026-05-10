using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Properties;
using QL_CuaHangBanThuocTruSau.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_BanHang : Form
    {
        SaleBUS _saleBUS = new SaleBUS();
        CustomerBUS _customerBUS = new CustomerBUS();
        ProductBUS _productBUS = new ProductBUS();
        CategoryBUS _categoryBUS = new CategoryBUS();
        InvoicePrinter _printer = new InvoicePrinter();
        private Frm_LichSuDonHang frmLichSuDonHang;
        private List<ProductVariant> _allVariants = new List<ProductVariant>();
        public Frm_BanHang()
        {
            InitializeComponent();
            SetupGridColumns();

            this.KeyPreview = true;
            this.KeyDown += Frm_BanHang_KeyDown;
            txtSearch.KeyDown += TxtSearch_KeyDown;

            // btnSavePrint đóng vai trò là nút "Thanh toán" (có thể nợ một phần)
            btnSavePrint.Click += (s, e) => HandlePayment(false, true);

            // btnSaveOnly đóng vai trò là nút "Ghi nợ 100%"
            btnSaveOnly.Click += (s, e) => HandlePayment(false, false);

            btnCancel.Click += (s, e) => ClearCart();
            btnViewOld.Click += (s, e) => ShowOldInvoices();

            this.Load += Frm_BanHang_Load;
        }

        private void Frm_BanHang_Load(object sender, EventArgs e)
        {
            try
            {
                var result = _customerBUS.GetAllCustomers();
                if (result.IsSuccess)
                {
                    var customers = result.Data;
                    if (customers != null && customers.Count > 0)
                    {
                        customers.Insert(0, new Customer { CustomerID = 0, Name = "--- Chọn khách hàng ---" });
                        cboCustomer.DataSource = customers;
                        cboCustomer.DisplayMember = "Name";
                        cboCustomer.ValueMember = "CustomerID";
                    }
                }
                SetupFilterCombos();
                RefreshProductData();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Frm_BanHang_Load");
            }
        }
        private void SetupFilterCombos()
        {
            LoadCboLocTheoLoai();

            cboLocTheoGia.Items.Clear();
            cboLocTheoGia.Items.Add("Tất cả giá");
            cboLocTheoGia.Items.Add("Dưới 50.000đ");
            cboLocTheoGia.Items.Add("50.000 đến 100.000đ");
            cboLocTheoGia.Items.Add("100.000 đến 200.000đ");
            cboLocTheoGia.Items.Add("200.000 đến 500.000đ");
            cboLocTheoGia.Items.Add("Trên 500.000đ");
            cboLocTheoGia.SelectedIndex = 0;
            cboLocTheoGia.DropDownWidth = 150;

            cboLocTheoLoai.SelectedIndexChanged += (s, e) => ApplyFilter();
            cboLocTheoGia.SelectedIndexChanged += (s, e) => ApplyFilter();
        }
        private void LoadCboLocTheoLoai()
        {
            var categories = _categoryBUS.layDanhSachLoai();
            if (categories == null) return;

            categories.Insert(0, new Category { CategoryID = 0, Name = "Tất cả loại" });

            cboLocTheoLoai.DataSource = categories;
            cboLocTheoLoai.DisplayMember = "Name";
            cboLocTheoLoai.ValueMember = "CategoryID";
        }

        private void ApplyFilter()
        {
            if (_allVariants == null || _allVariants.Count == 0) return;

            var filtered = _allVariants.AsEnumerable();

            string loai = (cboLocTheoLoai.SelectedItem as Category)?.Name;
            if (loai != "Tất cả loại" && !string.IsNullOrEmpty(loai))
            {
                filtered = filtered.Where(v =>
                    v.Product?.Category?.Name != null &&
                    v.Product.Category.Name.Contains(loai));
            }

            string gia = cboLocTheoGia.SelectedItem?.ToString();
            switch (gia)
            {
                case "Dưới 50.000đ":
                    filtered = filtered.Where(v => v.RetailPrice < 50000); 
                    break;

                case "50.000 đến 100.000đ":
                    filtered = filtered.Where(v => v.RetailPrice >= 50000 && v.RetailPrice <= 100000); 
                    break;

                case "100.000 đến 200.000đ":
                    filtered = filtered.Where(v => v.RetailPrice > 100000 && v.RetailPrice <= 200000); 
                    break;

                case "200.000 đến 500.000đ":
                    filtered = filtered.Where(v => v.RetailPrice > 200000 && v.RetailPrice <= 500000); 
                    break;

                case "Trên 500.000đ":
                    filtered = filtered.Where(v => v.RetailPrice > 500000); 
                    break;
            }

            LoadProductGallery(filtered.ToList());
        }

        private void RefreshProductData()
        {
            var result = _productBUS.GetAllProductVariants();
            if (result.IsSuccess)
            {
                _allVariants = result.Data;
                LoadProductGallery(result.Data);
            }
        }

        private void LoadProductGallery(List<ProductVariant> products)
        {
            try
            {
                flpProducts.Controls.Clear();
                if (products == null) return;

                foreach (var item in products)
                {
                    Guna.UI2.WinForms.Guna2Panel card = new Guna.UI2.WinForms.Guna2Panel
                    {
                        Width = 160,
                        Height = 180,
                        BorderRadius = 0,
                        FillColor = Color.White,
                        BorderColor = Color.FromArgb(230, 230, 230),
                        BorderThickness = 1,
                        Margin = new Padding(0, 0, 15, 15),
                        Cursor = Cursors.Hand
                    };

                    Label lblName = new Label
                    {
                        Text = item.Product?.Name ?? "Sản phẩm",
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        ForeColor = Color.FromArgb(45, 55, 72),
                        Location = new Point(10, 15),
                        Size = new Size(140, 45),
                        BackColor = Color.Transparent
                    };

                    Label lblUnit = new Label
                    {
                        Text = item.Unit,
                        Font = new Font("Segoe UI", 9),
                        ForeColor = Color.Gray,
                        Location = new Point(10, 60),
                        AutoSize = true,
                        BackColor = Color.Transparent
                    };

                    Label lblPrice = new Label
                    {
                        Text = $"{item.RetailPrice:N0}đ",
                        Font = new Font("Segoe UI", 11, FontStyle.Bold),
                        ForeColor = Color.SteelBlue,
                        Location = new Point(10, 130),
                        AutoSize = true,
                        BackColor = Color.Transparent
                    };

                    var stockResult = _productBUS.GetStockQuantity(item.VariantID);
                    int stockQty = stockResult.IsSuccess ? stockResult.Data : 0;
                    Label lblStock = new Label
                    {
                        Text = stockQty > 0 ? $"Tồn: {stockQty}" : "Hết hàng",
                        Font = new Font("Segoe UI", 8),
                        ForeColor = stockQty > 0 ? Color.SteelBlue : Color.FromArgb(225, 29, 72),
                        BackColor = stockQty > 0 ? Color.FromArgb(231, 241, 255) : Color.FromArgb(255, 228, 230),
                        Location = new Point(100, 132),
                        AutoSize = true,
                        Padding = new Padding(3)
                    };

                    card.Controls.Add(lblName);
                    card.Controls.Add(lblUnit);
                    card.Controls.Add(lblPrice);
                    card.Controls.Add(lblStock);

                    EventHandler cardClickHandler = (s, e) =>
                    {
                        if (stockQty > 0) AddProductToCart(item);
                        else MessageBox.Show("Sản phẩm đã hết hàng!", "Thông báo");
                    };

                    card.Click += cardClickHandler;
                    lblName.Click += cardClickHandler;
                    lblUnit.Click += cardClickHandler;
                    lblPrice.Click += cardClickHandler;

                    flpProducts.Controls.Add(card);
                }
            }
            catch (Exception ex) { Logger.Log(ex, "Frm_BanHang.LoadProductGallery"); }
        }

        private void SetupGridColumns()
        {
            try
            {
                dgvCart.Columns.Clear();
                dgvCart.Columns.Add("VariantID", "ID");
                dgvCart.Columns.Add("ProductName", "Sản Phẩm");
                dgvCart.Columns.Add("Capacity", "Dung Tích");
                dgvCart.Columns.Add("Price", "Đơn Giá");

                DataGridViewImageColumn btnMinus = new DataGridViewImageColumn();
                btnMinus.Name = "btnMinus";
                btnMinus.HeaderText = "";
                btnMinus.Image = Properties.Resources.minus; 
                btnMinus.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvCart.Columns.Add(btnMinus);

                dgvCart.Columns.Add("Quantity", "SL");
                dgvCart.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewImageColumn btnPlus = new DataGridViewImageColumn();
                btnPlus.Name = "btnPlus";
                btnPlus.HeaderText = "";
                btnPlus.Image = Properties.Resources.plus; 
                btnPlus.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvCart.Columns.Add(btnPlus);

                DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
                btnDelete.Name = "btnDelete";
                btnDelete.HeaderText = "";
                btnDelete.Image = Properties.Resources.bin; 
                btnDelete.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvCart.Columns.Add(btnDelete);

                dgvCart.Columns.Add("Total", "Thành Tiền");

                dgvCart.Columns["Total"].Visible = false;
                dgvCart.Columns["VariantID"].Visible = false;
                dgvCart.Columns["ProductName"].Width = 120;
                dgvCart.Columns["ProductName"].ReadOnly = true;
                dgvCart.Columns["Capacity"].Width = 80;
                dgvCart.Columns["Capacity"].ReadOnly = true;
                dgvCart.Columns["Quantity"].Width = 40;
                dgvCart.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCart.Columns["Price"].Width = 100;
                dgvCart.Columns["Price"].ReadOnly = true;
                dgvCart.Columns["Price"].DefaultCellStyle.Format = "N0";
                dgvCart.Columns["Price"].DefaultCellStyle.ForeColor = Color.SteelBlue;

                dgvCart.Columns["btnMinus"].Width = 30;
                dgvCart.Columns["btnMinus"].DefaultCellStyle.Padding = new Padding(6);

                dgvCart.Columns["btnPlus"].Width = 30;
                dgvCart.Columns["btnPlus"].DefaultCellStyle.Padding = new Padding(6);

                dgvCart.Columns["btnDelete"].Width = 45;
                dgvCart.Columns["btnDelete"].DefaultCellStyle.Padding = new Padding(11);

                dgvCart.CellValueChanged += DgvCart_CellValueChanged;
                dgvCart.CellValidating += DgvCart_CellValidating;
                dgvCart.CellContentClick += dgvCart_CellContentClick;
            }
            catch (Exception ex) { Logger.Log(ex, "Frm_BanHang.SetupGridColumns"); }
        }

        private void DgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCart.Columns[e.ColumnIndex].Name == "Quantity")
            {
                var row = dgvCart.Rows[e.RowIndex];
                if (row.Cells["Quantity"].Value != null && row.Cells["Price"].Value != null)
                {
                    int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    row.Cells["Total"].Value = qty * price;
                    UpdateTotals();
                }
            }
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvCart.Columns[e.ColumnIndex].Name;
            var row = dgvCart.Rows[e.RowIndex];
            int variantId = Convert.ToInt32(row.Cells["VariantID"].Value);

            // Xử lý nút Cộng (+)
            if (colName == "btnPlus")
            {
                var stockResult = _productBUS.GetStockQuantity(variantId);
                int stockQty = stockResult.IsSuccess ? stockResult.Data : 0;

                int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
                if (currentQty < stockQty)
                {
                    row.Cells["Quantity"].Value = currentQty + 1;
                    // CellValueChanged sẽ tự cập nhật Total và UpdateTotals
                }
                else
                {
                    MessageBox.Show($"Chỉ còn {stockQty} sản phẩm trong kho!", "Thông báo");
                }
            }
            // Xử lý nút Trừ (-)
            else if (colName == "btnMinus")
            {
                int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
                if (currentQty > 1)
                {
                    row.Cells["Quantity"].Value = currentQty - 1;
                    // CellValueChanged sẽ tự cập nhật Total và UpdateTotals
                }
                else
                {
                    if (MessageBox.Show("Xóa sản phẩm này khỏi giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dgvCart.Rows.RemoveAt(e.RowIndex);
                        UpdateTotals();
                    }
                }
            }
            // Xử lý nút Xóa
            else if (colName == "btnDelete")
            {
                if (MessageBox.Show("Xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvCart.Rows.RemoveAt(e.RowIndex);
                    UpdateTotals();
                }
            }
        }

        private void AddProductToCart(ProductVariant variant)
        {
            if (cboCustomer.SelectedValue == null || (int)cboCustomer.SelectedValue == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng trước khi thêm sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCustomer.Focus();
                return;
            }

            if (variant == null || variant.Product == null) return;

            var stockResult = _productBUS.GetStockQuantity(variant.VariantID);
            int stockQty = stockResult.IsSuccess ? stockResult.Data : 0;

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["VariantID"].Value != null && Convert.ToInt32(row.Cells["VariantID"].Value) == variant.VariantID)
                {
                    int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                    if (qty < stockQty)
                    {
                        row.Cells["Quantity"].Value = qty + 1;
                    }
                    else
                    {
                        MessageBox.Show($"Chỉ còn {stockQty} sản phẩm trong kho!", "Thông báo");
                    }
                    return;
                }
            }
            dgvCart.Rows.Add(variant.VariantID, variant.Product.Name, variant.Unit, variant.RetailPrice, Properties.Resources.minus, 1, Properties.Resources.plus, Properties.Resources.delete22, variant.RetailPrice);
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["Total"].Value != null) total += Convert.ToDecimal(row.Cells["Total"].Value);
            }
            lblTotal.Text = $"{total:N0} đ";
        }

        private void ClearCart()
        {
            dgvCart.Rows.Clear();
            UpdateTotals();
            txtSearch.Clear();
            txtSearch.Focus();
            RefreshProductData();
        }

        // =========================================================================
        // HÀM MỚI: TẠO DIALOG NHẬP SỐ TIỀN KHÁCH TRẢ
        // =========================================================================
        private decimal GetPaidAmountFromUser(decimal totalAmount)
        {
            decimal resultAmount = -1;

            Form prompt = new Form()
            {
                Width = 400,
                Height = 236, 
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Thanh toán đơn hàng",
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10),
                Padding = new Padding(20)
            };

            Label lblTotal = new Label()
            {
                Left = 20,
                Top = 13,
                Width = 345,
                Height = 30,
                Text = string.Format("Tổng tiền: {0:N0} VNĐ", totalAmount),
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.FromArgb(70, 130, 180)
            };

            Label lblPrompt = new Label()
            {
                Left = 20,
                Top = 50,
                Width = 345,
                Height = 20,
                Text = "Số tiền khách thanh toán:",
                ForeColor = Color.FromArgb(60, 60, 60),
                BackColor = Color.Transparent
            };

            Guna.UI2.WinForms.Guna2TextBox txtAmount = new Guna.UI2.WinForms.Guna2TextBox()
            {
                Left = 15,
                Top = 58,
                Width = 250,
                Height = 24,
                Text = totalAmount.ToString("0"),
                Font = new Font("Segoe UI", 12),
                BorderColor = Color.FromArgb(200, 200, 200),
                BorderRadius = 6,
            };

            Guna.UI2.WinForms.Guna2Button btnOk = new Guna.UI2.WinForms.Guna2Button()
            {
                Text = "Xác nhận",
                Left = 20,
                Top = 128,
                Width = 165,
                Height = 40,
                FillColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                BorderRadius = 6,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            Guna.UI2.WinForms.Guna2Button btnCancelBtn = new Guna.UI2.WinForms.Guna2Button()
            {
                Text = "Hủy",
                Left = 200,
                Top = 128,
                Width = 165,
                Height = 40,
                FillColor = Color.FromArgb(224, 224, 224),
                ForeColor = Color.FromArgb(128, 128, 128),
                BorderRadius = 6,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            btnOk.Click += (s, e) => { prompt.DialogResult = DialogResult.OK; prompt.Close(); };
            btnCancelBtn.Click += (s, e) => { prompt.DialogResult = DialogResult.Cancel; prompt.Close(); };

            prompt.Controls.Add(lblTotal);
            prompt.Controls.Add(lblPrompt);
            prompt.Controls.Add(txtAmount);
            prompt.Controls.Add(btnOk);
            prompt.Controls.Add(btnCancelBtn);
            prompt.AcceptButton = btnOk;
            prompt.CancelButton = btnCancelBtn;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                string cleanVal = txtAmount.Text.Replace(",", "").Replace(".", "");
                if (decimal.TryParse(cleanVal, out decimal paid))
                    resultAmount = paid;
            }

            prompt.Dispose();
            return resultAmount;
        }

        // HÀM XỬ LÝ THANH TOÁN 
        private void HandlePayment(bool isPrint, bool isFullPayment = true)
        {
            try
            {
                if (dgvCart.Rows.Count == 0) { MessageBox.Show("Giỏ hàng đang trống!", "Thông báo"); return; }
                if (cboCustomer.SelectedValue == null) { MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo"); return; }

                int customerId = (int)cboCustomer.SelectedValue;
                decimal totalAmount = 0;
                List<OrderDetail> details = new List<OrderDetail>();

                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.IsNewRow) continue;
                    var detail = new OrderDetail
                    {
                        VariantID = Convert.ToInt32(row.Cells["VariantID"].Value),
                        OrderQuantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                        UnitPrice = Convert.ToDecimal(row.Cells["Price"].Value)
                    };
                    details.Add(detail);
                    totalAmount += detail.OrderQuantity * detail.UnitPrice;
                }

                decimal paidAmount = 0;

                if (isFullPayment)
                {
                    // 1. Mở form hỏi số tiền trả trước
                    paidAmount = GetPaidAmountFromUser(totalAmount);

                    // 2. Nếu người dùng bấm Hủy (trả về -1) thì ngắt quá trình
                    if (paidAmount < 0) return;

                    // 3. Xử lý trường hợp khách đưa dư (thối lại)
                    if (paidAmount > totalAmount)
                    {
                        MessageBox.Show($"Khách đưa thừa: {(paidAmount - totalAmount):N0} VNĐ.\nVui lòng thối lại tiền thừa cho khách!", "Thông báo thối tiền", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        paidAmount = totalAmount; // Chỉ ghi nhận trả tối đa bằng tổng tiền vào DataBase
                    }
                }
                else
                {
                    // Xử lý nút Lưu ghi nợ 100%
                    if (MessageBox.Show($"Xác nhận lưu đơn GHI NỢ toàn bộ {totalAmount:N0} đ?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                    paidAmount = 0;
                }

                // Cập nhật linh hoạt Status tùy vào số tiền đưa
                string orderStatus = (paidAmount >= totalAmount) ? "COMPLETED" : "DEBT";

                var order = new Order
                {
                    CustomerID = customerId,
                    UserID = SessionManager.CurrentUser?.UserID ?? 1,
                    OrderDate = DateTime.Now,
                    TotalAmount = totalAmount,
                    Status = orderStatus
                };

                var result = _saleBUS.ProcessSale(order, details, paidAmount);

                if (result.IsSuccess)
                {
                    decimal debt = totalAmount - paidAmount;
                    string successMsg = (paidAmount >= totalAmount)
                                        ? "Thanh toán thành công!"
                                        : $"Giao dịch thành công!\nKhách hàng đã thanh toán: {paidAmount:N0} đ\nĐược ghi nợ lại: {debt:N0} đ";

                    MessageBox.Show(successMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearCart();
                    RefreshProductData();
                }
                else MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { Logger.Log(ex, "Frm_BanHang.HandlePayment"); MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void ShowOldInvoices()
        {
            try
            {
                if (frmLichSuDonHang == null || frmLichSuDonHang.IsDisposed)
                {
                    frmLichSuDonHang = new Frm_LichSuDonHang();
                }

                if (!frmLichSuDonHang.Visible)
                {
                    frmLichSuDonHang.Show();
                }   
                else
                {
                    frmLichSuDonHang.BringToFront();
                }     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở Lịch sử đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCart_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvCart.Columns[e.ColumnIndex].Name == "Quantity")
                if (!int.TryParse(e.FormattedValue.ToString(), out int qty) || qty <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương!", "Thông báo");
                    e.Cancel = true;
                }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                ApplyFilter();
                return;
            }

            var filtered = _allVariants.Where(v =>
                (v.Product?.Name ?? "").ToLower().Contains(keyword)
            ).ToList();

            LoadProductGallery(filtered);
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = txtSearch.Text.Trim();
                var result = string.IsNullOrEmpty(keyword) ? _productBUS.GetAllProductVariants() : _productBUS.SearchProducts(keyword);
                if (result.IsSuccess) LoadProductGallery(result.Data);
                e.SuppressKeyPress = true;
            }
        }

        private void Frm_BanHang_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: txtSearch.Focus(); txtSearch.SelectAll(); break;
                case Keys.F2: HandlePayment(false, true); break;
                case Keys.F5: HandlePayment(false, false); break;
                case Keys.F3: ClearCart(); break;
                case Keys.F4: ShowOldInvoices(); break;
            }
        }

        private void pnlRight_Paint(object sender, PaintEventArgs e) { }
        private void dgvCart_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { dgvCart_CellContentClick(sender, e); }
        private void btnViewOld_Click(object sender, EventArgs e) { ShowOldInvoices(); }

        private void btnInventoryHistory_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_LichSuKho frm = new Frm_LichSuKho();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở Lịch sử kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlCartHeader_Paint(object sender, PaintEventArgs e) { }
        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e) { }

    }
}