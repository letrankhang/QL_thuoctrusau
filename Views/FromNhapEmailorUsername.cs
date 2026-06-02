using QL_CuaHangBanThuocTruSau.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views 
{
    public partial class FromNhapEmailorUsername : Form 
    {
        private ForgotPasswordController _controller;

        public FromNhapEmailorUsername() 
        {
            InitializeComponent();
            this.Name = "FromNhapEmailorUsername";
            _controller = new ForgotPasswordController();
        }

        private void btnIdentify_Click(object sender, EventArgs e) 
        {
            string identifier = txtIdentifier.Text.Trim();
            
            this.Cursor = Cursors.WaitCursor;
            string result = _controller.IdentifyUser(identifier);
            this.Cursor = Cursors.Default;

            if (result == "SUCCESS") 
            {
                MessageBox.Show($"Hệ thống đã gửi mã xác thực đến email: {_controller.GetMaskedEmail()}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Frm_NhapMaXacThuc frm = new Frm_NhapMaXacThuc(_controller);
                this.Hide();          
                frm.ShowDialog();    
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

        private void lblBackToLogin_Click(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void lblBackToLogin_MouseEnter(object sender, EventArgs e)
        {
            lblBackToLogin.Font = new Font(lblBackToLogin.Font.FontFamily,
                lblBackToLogin.Font.Size, FontStyle.Bold | FontStyle.Underline);
        }

        private void lblBackToLogin_MouseLeave(object sender, EventArgs e)
        {
            lblBackToLogin.Font = new Font(lblBackToLogin.Font.FontFamily,
               lblBackToLogin.Font.Size, FontStyle.Bold);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
