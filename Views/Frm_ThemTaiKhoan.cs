using QL_CuaHangBanThuocTruSau.Controllers;
using System;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views {
    public partial class Frm_ThemTaiKhoan : Form {
        private readonly AddUserController _addUserController;

        public Frm_ThemTaiKhoan () {
            InitializeComponent ();
            _addUserController = new AddUserController ();
        }

        private void btnSave_Click (object sender, EventArgs e) {
            string username = txtUsername.Text.Trim ();
            string fullName = txtFullName.Text.Trim ();
            string password = txtPassword.Text;
            string email = txtEmail.Text.Trim ();
            string role = cboRole.SelectedItem?.ToString () ?? "Staff";

            string result = _addUserController.HandleAddUser (username, password, fullName, email, role);

            if( result == "SUCCESS" )
            {
                MessageBox.Show ("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close ();
            }
            else
            {
                MessageBox.Show (result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click (object sender, EventArgs e) {
            this.Close ();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close ();
        }
    }
}
