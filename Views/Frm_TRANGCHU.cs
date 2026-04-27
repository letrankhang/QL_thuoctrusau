using QL_CuaHangBanThuocTruSau.Controllers;
using System;
using System.Windows.Forms;
using QL_CuaHangBanThuocTruSau.Utils;

namespace QL_CuaHangBanThuocTruSau.Views {
    public partial class Frm_TRANGCHU : Form {
        private readonly LogoutController _logoutController;

        public Frm_TRANGCHU () {
            InitializeComponent ();
            _logoutController = new LogoutController ();
            this.FormClosed += Frm_TRANGCHU_FormClosed;
        }

        private void Frm_TRANGCHU_Load (object sender, EventArgs e) {

        }

        private void Frm_TRANGCHU_FormClosed (object sender, FormClosedEventArgs e) {
            if (!isLoggingOut) {
                Application.Exit ();
            }
        }

        private bool isLoggingOut = false;

        private void btnDangXuat_Click (object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show ("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes) {
                if (_logoutController.HandleLogout ()) {
                    isLoggingOut = true;
                    Frm_DANGNHAP loginForm = new Frm_DANGNHAP ();
                    loginForm.Show ();
                    this.Close ();
                } else {
                    MessageBox.Show ("Đã có lỗi xảy ra khi đăng xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
