using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Utils;
using System;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_TRANGCHU : Form
    {
        private readonly LogoutController _logoutController;

        public Frm_TRANGCHU()
        {
            InitializeComponent();
            _logoutController = new LogoutController();
            this.FormClosed += Frm_TRANGCHU_FormClosed;
        }

        private void Frm_TRANGCHU_Load(object sender, EventArgs e)
        {
            UpdateUserInfo();
            OpenChildForm(new Dashboard(), "DASHBOARD");
        }

        private void UpdateUserInfo()
        {
            if (SessionManager.IsLoggedIn)
            {
                lblGreeting.Text = $"Xin chào, {SessionManager.CurrentUser.FullName} ({SessionManager.CurrentUser.Role})";
            }
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm, string title)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            lblInterfaceName.Text = title;
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront();
            childForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Dashboard(), "DASHBOARD");
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_TaiKhoan(), "QUẢN LÝ TÀI KHOẢN");
        }

        private void Frm_TRANGCHU_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isLoggingOut)
            {
                Application.Exit();
            }
        }

        private bool isLoggingOut = false;

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (_logoutController.HandleLogout())
                {
                    isLoggingOut = true;
                    Frm_DANGNHAP loginForm = new Frm_DANGNHAP();
                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra khi đăng xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_KhachHang(), "QUẢN LÝ KHÁCH HÀNG");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_BanHang(), "MÀN HÌNH BÁN HÀNG (POS)");
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
