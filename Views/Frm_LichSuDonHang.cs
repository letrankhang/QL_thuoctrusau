using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_LichSuDonHang : Form
    {
        private readonly OrderBUS _orderBUS = new OrderBUS();
        private List<Order> _allOrders = new List<Order>();
        private const string PlaceholderText = "Nhập mã hóa đơn hoặc tên khách hàng...";

        public Frm_LichSuDonHang()
        {
            InitializeComponent();
            SetupPlaceholder();
        }

        private void SetupPlaceholder()
        {
            txtTimKiem.Text = PlaceholderText;
            txtTimKiem.ForeColor = System.Drawing.Color.Gray;

            txtTimKiem.Enter += (s, e) =>
            {
                if (txtTimKiem.Text == PlaceholderText)
                {
                    txtTimKiem.Text = "";
                    txtTimKiem.ForeColor = System.Drawing.Color.Black;
                }
            };

            txtTimKiem.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    txtTimKiem.Text = PlaceholderText;
                    txtTimKiem.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        private void Frm_LichSuDonHang_Load(object sender, EventArgs e)
        {
            LoadFullData();
        }

        // Tải toàn bộ danh sách đơn hàng
        private void LoadFullData()
        {
            try
            {
                _allOrders = _orderBUS.GetAllOrders();
                BindData(_allOrders);
                DinhDangLuoi();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "LoadFullData");
                MessageBox.Show("Lỗi khi tải danh sách đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindData(List<Order> orders)
        {
            var displayList = orders.Select(o => new
            {
                o.OrderID,
                CustomerName = o.Customer?.Name ?? "N/A",
                UserName = o.User?.FullName ?? "N/A",
                o.OrderDate,
                o.TotalAmount,
                o.Status
            }).ToList();

            dgvLichSu.DataSource = displayList;
        }

        // Chức năng Lọc theo ngày
        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

            var filtered = _allOrders.Where(o => o.OrderDate >= tuNgay && o.OrderDate <= denNgay).ToList();
            BindData(filtered);
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvLichSu.SelectedRows.Count > 0)
            {
                try
                {
                    // Lấy OrderID từ dòng đang chọn
                    // Lưu ý: dgvLichSu.DataSource đang bind tới anonymous object, 
                    // nhưng cột "OrderID" vẫn tồn tại nếu được tạo tự động hoặc gán thủ công.
                    int orderId = Convert.ToInt32(dgvLichSu.SelectedRows[0].Cells["OrderID"].Value);

                    // Lấy dữ liệu đầy đủ từ Database (bao gồm details, customer, user)
                    var order = _orderBUS.GetOrderById(orderId);

                    if (order != null)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "PDF Files|*.pdf";
                        sfd.FileName = $"HoaDon_{order.OrderID}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            InvoicePrinter printer = new InvoicePrinter();
                            printer.ExportToPdf(order, sfd.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin chi tiết đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log(ex, "btnInHoaDon_Click");
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Chức năng tìm kiếm nhanh
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == PlaceholderText || string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                if (_allOrders.Count > 0 && dgvLichSu.Rows.Count != _allOrders.Count)
                {
                    BindData(_allOrders);
                }
                return;
            }

            string searchText = txtTimKiem.Text.ToLower();
            var filtered = _allOrders.Where(o =>
                o.OrderID.ToString().Contains(searchText) ||
                (o.Customer?.Name != null && o.Customer.Name.ToLower().Contains(searchText))
            ).ToList();

            BindData(filtered);
        }

        // Làm đẹp bảng dữ liệu
        private void DinhDangLuoi()
        {
            if (dgvLichSu.Columns.Count > 0)
            {
                if (dgvLichSu.Columns.Contains("OrderID")) dgvLichSu.Columns["OrderID"].HeaderText = "Mã Đơn";
                if (dgvLichSu.Columns.Contains("CustomerName")) dgvLichSu.Columns["CustomerName"].HeaderText = "Khách Hàng";
                if (dgvLichSu.Columns.Contains("UserName")) dgvLichSu.Columns["UserName"].HeaderText = "Nhân Viên";
                if (dgvLichSu.Columns.Contains("OrderDate")) dgvLichSu.Columns["OrderDate"].HeaderText = "Ngày Lập";
                if (dgvLichSu.Columns.Contains("TotalAmount")) dgvLichSu.Columns["TotalAmount"].HeaderText = "Tổng Tiền";
                if (dgvLichSu.Columns.Contains("Status")) dgvLichSu.Columns["Status"].HeaderText = "Trạng Thái";

                // Định dạng ngày tháng
                if (dgvLichSu.Columns.Contains("OrderDate"))
                    dgvLichSu.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // Định dạng tiền tệ VNĐ
                if (dgvLichSu.Columns.Contains("TotalAmount"))
                {
                    dgvLichSu.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                    dgvLichSu.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }
    }
}
