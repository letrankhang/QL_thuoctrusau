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
        private int _productID;

        public Frm_NhapChiTietSP(int productID)
        {
            InitializeComponent();
            _productID = productID;
        }

        private void Frm_NhapChiTietSP_Load(object sender, EventArgs e)
        {
            _dsBienThe = bus.layDanhSach();

            _dsBienThe = _dsBienThe.Where(x => x.ProductID == _productID).ToList();

            _dsBind = _dsBienThe.Select(x => new BienTheItem
            {
                VariantID = x.VariantID,
                TenBienThe = $"{x.Unit} - {x.Concentration}"
            }).ToList();

            _dsBind.Insert(0, new BienTheItem { VariantID = -1, TenBienThe = "-- Chọn biến thể --" });

            txtSoLuong.KeyPress += (s, ev) => {
                if (!char.IsDigit(ev.KeyChar) && ev.KeyChar != '\b')
                {
                    ev.Handled = true;
                    MessageBox.Show("Chỉ được nhập số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            cboBienThe.DataSource = _dsBind;
            cboBienThe.DisplayMember = "TenBienThe";
            cboBienThe.ValueMember = "VariantID";

            cboBienThe.SelectedIndexChanged += cboBienThe_SelectedIndexChanged;
            if (cboBienThe.SelectedItem != null)
                cboBienThe_SelectedIndexChanged(null, null);

            dtpNSX.Format = DateTimePickerFormat.Custom;
            dtpNSX.CustomFormat = "d/M/yyyy";

            dtpHSD.Format = DateTimePickerFormat.Custom;
            dtpHSD.CustomFormat = "d/M/yyyy";
        }

        private void cboBienThe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboBienThe.SelectedItem == null) return;

                BienTheItem selected = (BienTheItem)cboBienThe.SelectedItem;
                ProductVariant bienThe = _dsBienThe.FirstOrDefault(x => x.VariantID == selected.VariantID);

                if (bienThe == null) return;

                lblGiaSi.Text = $"Giá bán sỉ: {bienThe.WholesalePrice:N0}đ";
                lblGiaLe.Text = $"Giá bán lẻ: {bienThe.RetailPrice:N0}đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load giá: " + ex.Message);
            }
        }

        private void btnXacNhan1_Click(object sender, EventArgs e)
        {
            BienTheItem selected = (BienTheItem)cboBienThe.SelectedItem;
            if (selected == null || selected.VariantID == -1)
            {
                MessageBox.Show("Vui lòng chọn biến thể!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal donGiaNhap;
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGiaNhap))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

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
            if (dtpHSD.Value.Date <= dtpNSX.Value.Date)
            {
                MessageBox.Show("HSD phải lớn hơn NSX!");
                return;
            }

            VariantID = bienThe.VariantID;
            BienThe = $"{bienThe.Unit} - {bienThe.Concentration}";
            DonGia = donGiaNhap;
            SoLuong = int.Parse(txtSoLuong.Text);
            NSX = dtpNSX.Value.Date;
            HSD = dtpHSD.Value.Date;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class BienTheItem
    {
        public int VariantID { get; set; }
        public string TenBienThe { get; set; }
    }
}