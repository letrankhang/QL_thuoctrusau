using QL_CuaHangBanThuocTruSau.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views 
{
    public partial class Frm_NhapMaXacThuc : Form 
    {
        private ForgotPasswordController _controller;

        public Frm_NhapMaXacThuc (ForgotPasswordController controller) 
        {
            InitializeComponent ();
            this.Name = "Frm_NhapMaXacThuc";
            _controller = controller;
        }

        private void btnVerify_Click (object sender, EventArgs e) 
        {
            string otp = txtOTP.Text.Trim ();
            if( _controller.VerifyCode (otp) )
            {
                Frm_QuenMatKhau frm = new Frm_QuenMatKhau (_controller);
                this.Hide();        
                frm.ShowDialog();     
                this.Close();
            }
            else
            {
                MessageBox.Show ("Mã xác thực không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblResendOTP_Click (object sender, EventArgs e) 
        {
            // ghi chú kĩ:
            // Logic gửi lại mã (có thể gọi lại IdentifyUser hoặc một phương thức Resend cụ thể)
            // Để đơn giản, ta thông báo đang gửi lại
            this.Cursor = Cursors.WaitCursor;
            // Giả sử ta dùng lại identifier cũ (cần lưu identifier trong controller nếu muốn)
            // Ở đây tạm thời thông báo
            MessageBox.Show ("Hệ thống đang gửi lại mã xác thực...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Cursor = Cursors.Default;
        }

        private void lblResendOTP_MouseEnter(object sender, EventArgs e)
        {
            lblResendOTP.Font = new Font(lblResendOTP.Font, FontStyle.Underline);
        }

        private void lblResendOTP_MouseLeave(object sender, EventArgs e)
        {
            lblResendOTP.Font = new Font(lblResendOTP.Font, FontStyle.Regular);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
