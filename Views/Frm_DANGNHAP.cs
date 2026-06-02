using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views 
{
    public partial class Frm_DANGNHAP : Form 
    {
        private LoginController _loginController;
        private bool isPasswordVisible = false;

        public Frm_DANGNHAP () 
        {
            InitializeComponent ();
            _loginController = new LoginController ();
        }

        private void Frm_DANGNHAP_Load (object sender, EventArgs e) 
        {
            isPasswordVisible = false;
            txtMK.PasswordChar = '●';
            txtMK.IconRight = Properties.Resources.invisible;

            if (Properties.Settings.Default.RememberMe)
            {
                chkGhiNho.Checked = true;
                txtTenTK.Text = Properties.Settings.Default.SavedUsername;
                txtMK.Text = Properties.Settings.Default.SavedPassword;
            }
        }

        private void lblQuenMK_Click(object sender, EventArgs e)
        {
            FromNhapEmailorUsername frm = new FromNhapEmailorUsername();
            this.Hide();        
            frm.ShowDialog();  
            this.Show();
        }

        private void lblQuenMK_MouseEnter(object sender, EventArgs e)
        {
            lblQuenMK.Font = new Font(lblQuenMK.Font, FontStyle.Underline);
        }

        private void lblQuenMK_MouseLeave(object sender, EventArgs e)
        {
            lblQuenMK.Font = new Font(lblQuenMK.Font, FontStyle.Regular);
        }

        private void txtMK_IconRightClick(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            txtMK.PasswordChar = isPasswordVisible ? '\0' : '●';
            txtMK.IconRight = isPasswordVisible
                ? Properties.Resources.shared_vision3
                : Properties.Resources.invisible;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string result = _loginController.HandleLogin(txtTenTK.Text.Trim(), txtMK.Text.Trim());

            if (result == "SUCCESS")
            {
                ReportHelper.NguoiDangNhap = SessionManager.CurrentUser.FullName;
                ReportHelper.ChucVu = SessionManager.CurrentUser.Role == "Admin" ? "Quản trị viên" : "Nhân viên";

                MessageBox.Show("Xin chào, " + SessionManager.CurrentUser.FullName + "!\nVai trò: " + SessionManager.CurrentUser.Role, "Đăng nhập thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                );

                if (chkGhiNho.Checked)
                {
                    Properties.Settings.Default.RememberMe = true;
                    Properties.Settings.Default.SavedUsername = txtTenTK.Text.Trim();
                    Properties.Settings.Default.SavedPassword = txtMK.Text.Trim();
                }
                else
                {
                    Properties.Settings.Default.RememberMe = false;
                    Properties.Settings.Default.SavedUsername = "";
                    Properties.Settings.Default.SavedPassword = "";
                }
                Properties.Settings.Default.Save();
                Frm_TRANGCHU trangChu = new Frm_TRANGCHU();
                trangChu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
