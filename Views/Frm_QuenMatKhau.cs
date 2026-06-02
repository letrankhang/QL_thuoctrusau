using QL_CuaHangBanThuocTruSau.Controllers;
using System;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views 
{
    public partial class Frm_QuenMatKhau : Form 
    {
        private ForgotPasswordController _controller;

        public Frm_QuenMatKhau() 
        {
            InitializeComponent();
            this.Name = "Frm_QuenMatKhau";

            _controller = new ForgotPasswordController();
        }

        public Frm_QuenMatKhau(ForgotPasswordController controller) 
        {
            InitializeComponent();
            this.Name = "Frm_QuenMatKhau";
            _controller = controller;

            if (pnlStep1 != null) pnlStep1.Visible = false;
            if (pnlStep2 != null) pnlStep2.Visible = false;
            if (pnlStep3 != null) pnlStep3.Visible = true;

            lblSubTitle.Text = "Thiết lập mật khẩu mới cho tài khoản";
        }

        private void btnReset_Click(object sender, EventArgs e) 
        {
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;
            string result = _controller.ResetPassword(newPass, confirmPass);
            if (result == "SUCCESS")
            {
                MessageBox.Show("Đặt lại mật khẩu thành công! Vui lòng đăng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); 
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void btnIdentify_Click (object sender, EventArgs e) { }

        private void btnVerify_Click (object sender, EventArgs e) { }

        private void btnBackToLogin_Click (object sender, EventArgs e) 
        { 
            this.Close (); 
        }

        private void lblSubTitle_Click (object sender, EventArgs e) { }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
           this.Close ();   
        }

        private void Frm_QuenMatKhau_Load(object sender, EventArgs e) { }
    }
}
