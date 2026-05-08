using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views {
    public partial class Frm_SuaTaiKhoan : Form {
        private readonly UserController _userController;
        private readonly User _currentUser;

        public Frm_SuaTaiKhoan (User user) {
            InitializeComponent ();
            _userController = new UserController ();
            _currentUser = user;
            LoadUserData ();
        }

        private void LoadUserData () {
            txtUsername.Text = _currentUser.Username;
            txtFullName.Text = _currentUser.FullName;
            cboRole.SelectedItem = _currentUser.Role;
            swStatus.Checked = _currentUser.Status;
            UpdateStatusLabel (_currentUser.Status);
        }

        private void UpdateStatusLabel (bool status) {
            lblStatus.Text = status ? "Hoạt động" : "Đã khóa";
            lblStatus.ForeColor = status ? System.Drawing.Color.FromArgb (22, 163, 74) : System.Drawing.Color.FromArgb (220, 38, 38);
        }

        private void swStatus_CheckedChanged (object sender, EventArgs e) {
            UpdateStatusLabel (swStatus.Checked);
        }

        private void btnSave_Click (object sender, EventArgs e) {
            string fullName = txtFullName.Text.Trim ();
            string password = txtPassword.Text; // Có thể trống nếu không đổi
            string role = cboRole.SelectedItem?.ToString () ?? "Staff";
            bool status = swStatus.Checked;

            if( _userController.UpdateUser (_currentUser.UserID, password, fullName, role, status) )
            {
                MessageBox.Show ("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close ();
            }
            else
            {
                MessageBox.Show ("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click (object sender, EventArgs e) {
            this.Close ();
        }
    }
}
