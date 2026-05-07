using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Drawing;
using System.Linq; // Thêm thư viện này để dùng LINQ kiểm tra số
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_KhachHang : Form
    {
        private readonly CustomerBUS _bus = new CustomerBUS();

        public Frm_KhachHang()
        {
            InitializeComponent();
            SetupModernUI();
            LoadData();
            RegisterEvents();
        }

        private void SetupModernUI()
        {
            this.BackColor = Color.FromArgb(242, 245, 250);

            // Cấu hình DataGridView
            dgvCustomers.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvCustomers.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvCustomers.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvCustomers.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);

            // Khóa TextBox ID ngay từ đầu để không cho phép sửa thủ công
            txtID.ReadOnly = true;
            txtID.BackColor = Color.LightGray; // Đổi màu để người dùng dễ nhận biết là ô bị khóa

            // Cấu hình các nút bấm
            btnThem.BorderRadius = 6;
            btnThem.FillColor = Color.FromArgb(94, 148, 255);

            btnSua.BorderRadius = 6;
            btnSua.FillColor = Color.FromArgb(39, 174, 96);

            btnXoa.BorderRadius = 6;
            btnXoa.FillColor = Color.FromArgb(231, 76, 60);

            btnLamMoi.BorderRadius = 6;
            btnLamMoi.FillColor = Color.FromArgb(149, 165, 166);
        }

        private void LoadData()
        {
            try
            {
                dgvCustomers.DataSource = _bus.GetList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Hàm bổ trợ kiểm tra số điện thoại hợp lệ
        private bool IsValidPhone(string phone)
        {
            // Kiểm tra: không rỗng, độ dài bằng 10 và tất cả đều là số
            return !string.IsNullOrWhiteSpace(phone) &&
                   phone.Length == 10 &&
                   phone.All(char.IsDigit);
        }

        private void RegisterEvents()
        {
            btnThem.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Vui lòng nhập tên!"); return; }

                // Bắt lỗi số điện thoại 10 số
                if (!IsValidPhone(txtPhone.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ! (Phải đúng 10 chữ số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                var c = new Customer { Name = txtName.Text, Phone = txtPhone.Text, Address = txtAddress.Text };
                MessageBox.Show(_bus.HandleCustomer(c, "ADD"));
                LoadData();
            };

            btnSua.Click += (s, e) =>
            {
                if (string.IsNullOrEmpty(txtID.Text)) { MessageBox.Show("Vui lòng chọn khách hàng cần sửa!"); return; }

                // Bắt lỗi số điện thoại 10 số khi sửa
                if (!IsValidPhone(txtPhone.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ! (Phải đúng 10 chữ số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                var c = new Customer { CustomerID = int.Parse(txtID.Text), Name = txtName.Text, Phone = txtPhone.Text, Address = txtAddress.Text };
                MessageBox.Show(_bus.HandleCustomer(c, "UPDATE"));
                LoadData();
            };

            btnXoa.Click += (s, e) =>
            {
                if (string.IsNullOrEmpty(txtID.Text)) return;
                if (MessageBox.Show("Xác nhận xóa khách hàng này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_bus.RemoveCustomer(int.Parse(txtID.Text)))
                        MessageBox.Show("Đã xóa thành công!");
                    else
                        MessageBox.Show("Không thể xóa khách hàng đã có giao dịch!");
                    LoadData();
                }
            };

            dgvCustomers.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var r = dgvCustomers.Rows[e.RowIndex];
                    txtID.Text = r.Cells["CustomerID"].Value?.ToString();
                    txtName.Text = r.Cells["Name"].Value?.ToString();
                    txtPhone.Text = r.Cells["Phone"].Value?.ToString();
                    txtAddress.Text = r.Cells["Address"].Value?.ToString();
                }
            };

            btnLamMoi.Click += (s, e) =>
            {
                txtID.Clear(); txtName.Clear(); txtPhone.Clear(); txtAddress.Clear();
            };
        }

        private void Frm_KhachHang_Load(object sender, EventArgs e)
        {

        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}