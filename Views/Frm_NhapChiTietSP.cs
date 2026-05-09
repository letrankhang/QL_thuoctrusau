using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_NhapChiTietSP : Form
    {
        public int VariantID { get; set; }
        public string BienThe { get; set; }
        public string HamLuong { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public DateTime NSX { get; set; }
        public DateTime HSD { get; set; }

        private List<ProductVariant> _dsBienThe;
        private List<BienTheItem> _dsBind;
        private ProductVariantBUS bus = new ProductVariantBUS();

        public Frm_NhapChiTietSP()
        {
            InitializeComponent();
        }

        private void Frm_NhapChiTietSP_Load(object sender, EventArgs e)
        {
            // ✅ Lưu list gốc để dùng lấy giá
            _dsBienThe = bus.layDanhSach();

            // ✅ Tạo list hiển thị Unit - Concentration
            _dsBind = _dsBienThe.Select(x => new BienTheItem
            {
                VariantID = x.VariantID,
                TenBienThe = $"{x.Unit} - {x.Concentration}"
            }).ToList();

            cboBienThe.DataSource = _dsBind;
            cboBienThe.DisplayMember = "TenBienThe";
            cboBienThe.ValueMember = "VariantID";

            cboBienThe.SelectedIndexChanged += cboBienThe_SelectedIndexChanged;
            if (cboBienThe.SelectedItem != null)
                cboBienThe_SelectedIndexChanged(null, null);
        }

        private void cboBienThe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboBienThe.SelectedItem == null) return;

                // ✅ Cast thẳng sang BienTheItem
                BienTheItem selected = (BienTheItem)cboBienThe.SelectedItem;
                ProductVariant bienThe = _dsBienThe.FirstOrDefault(x => x.VariantID == selected.VariantID);

                if (bienThe == null) return;

                lblGiaSi.Text = $"Giá bán sĩ: {bienThe.WholesalePrice:N0} đ";
                lblGiaLe.Text = $"Giá bán lẻ: {bienThe.RetailPrice:N0} đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load giá: " + ex.Message);
            }
        }

        private void btnXacNhan1_Click(object sender, EventArgs e)
        {
            decimal donGiaNhap;
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGiaNhap))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            // ✅ Cast thẳng sang BienTheItem
            BienTheItem selected = (BienTheItem)cboBienThe.SelectedItem;
            ProductVariant bienThe = _dsBienThe.FirstOrDefault(x => x.VariantID == selected.VariantID);

            if (bienThe == null) return;

            if (donGiaNhap >= bienThe.RetailPrice)
            {
                MessageBox.Show("Đơn giá nhập phải nhỏ hơn giá bán lẻ!");
                return;
            }
            if (donGiaNhap >= bienThe.WholesalePrice)
            {
                MessageBox.Show("Đơn giá nhập phải nhỏ hơn giá bán sỉ!");
                return;
            }
            if (txtHSD.Value.Date <= txtNSX.Value.Date)
            {
                MessageBox.Show("HSD phải lớn hơn NSX!");
                return;
            }

            VariantID = bienThe.VariantID;
            BienThe = $"{bienThe.Unit} - {bienThe.Concentration}";
            DonGia = donGiaNhap;
            SoLuong = int.Parse(txtSoLuong.Text);
            NSX = txtNSX.Value.Date;
            HSD = txtHSD.Value.Date;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lblGBL_Click(object sender, EventArgs e) { }
    }

    public class BienTheItem
    {
        public int VariantID { get; set; }
        public string TenBienThe { get; set; }
    }
}