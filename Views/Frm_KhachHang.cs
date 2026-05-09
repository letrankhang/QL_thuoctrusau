using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Text.RegularExpressions; // Thêm thư viện để dùng Regex bắt lỗi số điện thoại
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_KhachHang : Form
    {
        private CustomerBUS khachHangBus = new CustomerBUS();
        private int maDangChon = 0;

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
        }

        public void loadDanhSach()
        {
            try
            {
                var ds = khachHangBus.layDanhSach();
                dgvKhachHang.DataSource = ds;
                lblTongKhachHang.Text = ds.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- HÀM HỖ TRỢ: KIỂM TRA DỮ LIỆU ĐẦU VÀO ---
        private bool KiemTraHopLe()
        {
            // 1. Kiểm tra không được để trống bất kỳ trường nào
            if (string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(txtSĐT.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin (Tên, Số điện thoại, Địa chỉ)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Kiểm tra định dạng số điện thoại (Bắt buộc 10 số và bắt đầu bằng số 0)
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Gọi hàm kiểm tra tính hợp lệ trước khi xử lý
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

        private void pnlTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblDangChon_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}