using QL_CuaHangBanThuocTruSau.Controllers;
using System;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_DANGNHAP : Form
    {
        private readonly LoginController _loginController;

        public Frm_DANGNHAP()
        {
            InitializeComponent();
            _loginController = new LoginController();
        }

        private void Frm_DANGNHAP_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string result = _loginController.HandleLogin(txtTenTK.Text, txtMK.Text);

            if (result == "SUCCESS")
            {
                MessageBox.Show("Đăng nhập thành công!");
                Frm_TRANGCHU trangChu = new Frm_TRANGCHU();
                trangChu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
