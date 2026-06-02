using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_SuaNCC : Form
    {
        private SuppliersController controller = new SuppliersController();
        private Supplier nhaCungCapCanSua;

        public Frm_SuaNCC(Supplier nhaCungCap)
        {
            InitializeComponent();
            nhaCungCapCanSua = nhaCungCap;
        }

        private void Frm_SuaNCC_Load(object sender, EventArgs e)
        {
            txtMaNCC.Text = nhaCungCapCanSua.SupplierID.ToString();
            txtTen.Text = nhaCungCapCanSua.Name;
            txtSDT.Text = nhaCungCapCanSua.Phone;
            txtDiaChi.Text = nhaCungCapCanSua.Address;
            txtMaNCC.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string loi = "";
            Supplier ncc = new Supplier
            {
                SupplierID = nhaCungCapCanSua.SupplierID,
                Name = txtTen.Text,
                Phone = txtSDT.Text,
                Address = txtDiaChi.Text
            };

            bool thanhCong = controller.Sua(ncc, out loi);

            if (thanhCong)
            {
                MessageBox.Show("Sửa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
