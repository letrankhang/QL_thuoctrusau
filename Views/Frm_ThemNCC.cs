using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_ThemNCC : Form
    {
        private SuppliersController controller = new SuppliersController();
        private Supplier nhaCungCapCanSua = null;

        public Frm_ThemNCC()
        {
            InitializeComponent();
        }

        public Frm_ThemNCC(Supplier nhaCungCap)
        {
            InitializeComponent();
            nhaCungCapCanSua = nhaCungCap;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string loi = "";
            Supplier ncc = new Supplier
            {
                Name = txtTen.Text,
                Phone = txtSDT.Text,
                Address = txtDiaChi.Text
            };

            bool thanhCong = controller.Them(ncc, out loi);

            if (thanhCong)
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_ThemNCC_Load_1(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}