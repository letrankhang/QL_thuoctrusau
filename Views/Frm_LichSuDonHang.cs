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
        private OrderBUS _orderBUS = new OrderBUS();
        private List<Order> _allOrders = new List<Order>();

        public Frm_LichSuDonHang()
        {
            InitializeComponent();
        }

        private void Frm_LichSuDonHang_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "d/M/yyyy";

            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "d/M/yyyy";
            LoadFullData();
        }

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
                
                dgvLichSu.Columns["OrderID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLichSu.Columns["OrderDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLichSu.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (dgvLichSu.Columns.Contains("OrderDate"))
                    dgvLichSu.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                if (dgvLichSu.Columns.Contains("TotalAmount"))
                {
                    dgvLichSu.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                    dgvLichSu.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var filtered = _allOrders.Where(o => o.OrderDate >= tuNgay && o.OrderDate < denNgay).ToList();

                BindData(filtered);
                DinhDangLuoi();

                if (filtered.Count == 0)
                    MessageBox.Show("Không có đơn hàng nào trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "btnLoc_Click");
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvLichSu.SelectedRows.Count > 0)
            {
                try
                {
                    // Lấy OrderID từ dòng đang chọn
                    // dgvLichSu.DataSource đang bind tới anonymous object, 
                    // nhưng cột OrderID vẫn tồn tại nếu được tạo tự động hoặc gán thủ công.
                    int orderId = Convert.ToInt32(dgvLichSu.SelectedRows[0].Cells["OrderID"].Value);

                    // Lấy dữ liệu đầy đủ từ Database bao gồm details, customer, user
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                BindData(_allOrders);
                DinhDangLuoi();
                return;
            }

            var filtered = _allOrders.Where(o =>
                o.OrderID.ToString().Contains(searchText) ||
                (o.Customer?.Name != null && o.Customer.Name.ToLower().Contains(searchText))
            ).ToList();

            BindData(filtered);
            DinhDangLuoi();
        }
    }
}
