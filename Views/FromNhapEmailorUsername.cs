using Guna.UI2.WinForms;
using QL_CuaHangBanThuocTruSau.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views {
    public partial class FromNhapEmailorUsername : Form {
        private readonly ForgotPasswordController _controller;

        public FromNhapEmailorUsername() {
            InitializeComponent();
            this.Name = "FromNhapEmailorUsername";
            _controller = new ForgotPasswordController();
        }

        private void btnIdentify_Click(object sender, EventArgs e) {
            string identifier = txtIdentifier.Text.Trim();
            
            this.Cursor = Cursors.WaitCursor;
            string result = _controller.IdentifyUser(identifier);
            this.Cursor = Cursors.Default;

            if (result == "SUCCESS") {
                MessageBox.Show($"Hệ thống đã gửi mã xác thực đến email: {_controller.GetMaskedEmail()}", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Chuyển sang giao diện nhập mã xác thực
                Frm_NhapMaXacThuc frm = new Frm_NhapMaXacThuc(_controller);
                frm.Show();
                this.Hide();
            } else {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void lblBackToLogin_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void guna2PictureBox1_Click (object sender, EventArgs e) {

        }

        private void txtIdentifier_TextChanged (object sender, EventArgs e) {

        }
    }
}
