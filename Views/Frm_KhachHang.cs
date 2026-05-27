using DocumentFormat.OpenXml.Wordprocessing;
using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions; // Thêm thư viện để dùng Regex bắt lỗi số điện thoại
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_KhachHang : Form
    {
        private CustomerBUS khachHangBus = new CustomerBUS();
        private int maDangChon = 0;
        private List<Customer> _danhSachGoc = new List<Customer>();

        public Frm_KhachHang()
        {
            InitializeComponent();

            // --- FIX ĐỊNH DẠNG MÀN HÌNH ---
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // THÊM DÒNG NÀY: Ép form không được tự ý phóng to/thu nhỏ các control theo màn hình Windows
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void Frm_KhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;
            loadDanhSach();
            StyleDgv(dgvKhachHang);

            cboLocTheoNgay.Items.Clear();
            cboLocTheoNgay.Items.Add("Tất cả các ngày");
            cboLocTheoNgay.Items.Add("Hôm nay");
            cboLocTheoNgay.Items.Add("Tuần này");
            cboLocTheoNgay.Items.Add("Tháng này");
            cboLocTheoNgay.SelectedIndex = 0;
        }

        public void loadDanhSach()
        {
            try
            {
                var ds = khachHangBus.layDanhSach();
                _danhSachGoc = ds;
                dgvKhachHang.DataSource = ds;
                lblTongKhachHang.Text = ds.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraHopLe()
        {
            // Kiểm tra không được để trống bất kỳ trường nào
            if (string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(txtSĐT.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin (Tên, Số điện thoại, Địa chỉ)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra định dạng số điện thoại (Bắt buộc 10 số và bắt đầu bằng số 0)
            // Ký hiệu Regex: ^0 là bắt đầu bằng 0, \d{9} là theo sau bởi đúng 9 chữ số, $ là kết thúc chuỗi
            Regex regexPhone = new Regex(@"^0\d{9}$");
            if (!regexPhone.IsMatch(txtSĐT.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!\nVui lòng nhập đúng 10 số và bắt đầu bằng số 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSĐT.Focus(); // Đưa con trỏ chuột về lại ô SĐT
                return false;
            }

            return true;
        }

        private void lamMoi()
        {
            maDangChon = 0;
            txtTenKH.Clear();
            txtSĐT.Clear();
            txtDiaChi.Clear();
            txtTim.Clear();
            lblDangChon.Text = "---";
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                maDangChon = Convert.ToInt32(row.Cells["colMaKH"].Value);
                txtTenKH.Text = row.Cells["colTenKH"].Value?.ToString();
                txtSĐT.Text = row.Cells["colSĐT"].Value?.ToString();
                txtDiaChi.Text = row.Cells["colDiaChi"].Value?.ToString();
                lblDangChon.Text = maDangChon + " - " + txtTenKH.Text;
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = khachHangBus.timKiem(txtTim.Text.Trim());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;

            if (khachHangBus.kiemTraSoDienThoaiTonTai(txtSĐT.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại này đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer kh = new Customer
            {
                Name = txtTenKH.Text.Trim(),
                Phone = txtSĐT.Text.Trim(),
                Address = txtDiaChi.Text.Trim()
            };

            string loi = "";
            if (khachHangBus.them(kh, out loi))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lamMoi();
                loadDanhSach();
            }
            else
            {
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa từ danh sách bên dưới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi hàm kiểm tra tính hợp lệ trước khi xử lý
            if (!KiemTraHopLe()) return;

            if (khachHangBus.kiemTraSoDienThoaiTonTai(txtSĐT.Text.Trim(), maDangChon))
            {
                MessageBox.Show("Số điện thoại này đã tồn tại ở một khách hàng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer kh = new Customer
            {
                CustomerID = maDangChon,
                Name = txtTenKH.Text.Trim(),
                Phone = txtSĐT.Text.Trim(),
                Address = txtDiaChi.Text.Trim()
            };

            string loi = "";
            if (khachHangBus.sua(kh, out loi))
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhSach();
            }
            else
            {
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string loi = "";
                if (khachHangBus.xoa(maDangChon, out loi))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lamMoi();
                    loadDanhSach();
                }
                else
                {
                    MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lamMoi();
            loadDanhSach();
        }

        private void StyleDgv(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersHeight = 34;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            dgv.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgv.RowTemplate.Height = 34;

            if (dgv.Columns["cotNgayTao"] != null)
            {
                dgv.Columns["cotNgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgv.Columns["cotNgayTao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void cboLocTheoNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime homNay = DateTime.Today;
            DateTime tuNgay, denNgay;
            string tieuChi = cboLocTheoNgay.SelectedItem?.ToString();

            if (tieuChi == "Tất cả các ngày")
            {
                dgvKhachHang.DataSource = khachHangBus.layDanhSach();
                lblTongKhachHang.Text = _danhSachGoc.Count.ToString();
                lblDangChon.Text = "---";
                return;
            }

            if (tieuChi == "Hôm nay")
            {
                tuNgay = homNay;
                denNgay = homNay;
            }
             
            else if (tieuChi == "Tuần này")
            {
                int thu = (int)homNay.DayOfWeek;
                int soNgayVeThu2;
                if (thu == 0)
                    soNgayVeThu2 = 6;
                else
                    soNgayVeThu2 = thu - 1;

                tuNgay = homNay.AddDays(-soNgayVeThu2);
                denNgay = homNay;
            }
            else // Tháng này
            {
                tuNgay = new DateTime(homNay.Year, homNay.Month, 1);
                denNgay = homNay;
            }

            List<Customer> ketQua = khachHangBus.locTheoNgay(tuNgay, denNgay);

            dgvKhachHang.DataSource = ketQua;
            lblTongKhachHang.Text = ketQua.Count.ToString();
            lblDangChon.Text = "Lọc: " + tuNgay.ToString("dd/MM/yyyy") + " → " + denNgay.ToString("dd/MM/yyyy") + " (" + ketQua.Count + " KH)";
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = $"DanhSachKhachHang_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var danhSach = khachHangBus.layDanhSach();
                    ExcelHelper.XuatExcelKhachHang(danhSach, sfd.FileName);
                }
            }
        }

        private void btnXuatReport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files|*.pdf";
                sfd.FileName = $"BaoCaoKhachHang_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var danhSach = khachHangBus.layDanhSach();
                    ReportHelper.XuatReportKhachHang(danhSach, sfd.FileName);
                }
            }
        }
    }
}