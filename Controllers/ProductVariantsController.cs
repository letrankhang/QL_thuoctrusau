using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Controllers
{
    public class ProductVariantController
    {
        private ProductVariantBUS bus = new ProductVariantBUS();

        public List<ProductVariant> layDanhSachTheoSP(int maSP)
        {
            return bus.layTheoSanPham(maSP);
        }

        public bool them(int maSP, string donVi, string hamLuong, string giaBanLe, string giaBanSi)
        {
            if (!parseGia(giaBanLe, "Giá bán lẻ", out decimal retailPrice)) 
                return false;

            if (!parseGia(giaBanSi, "Giá bán sỉ", out decimal wholesalePrice)) 
                return false;

            var bienThe = new ProductVariant
            {
                ProductID = maSP,
                Unit = donVi,
                Concentration = hamLuong,
                RetailPrice = retailPrice,
                WholesalePrice = wholesalePrice
            };

            bool ketQua = bus.them(bienThe, out string loi);
            if (!ketQua)
            {
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ketQua;
        }

        public bool sua(int maVariant, int maSP, string donVi, string hamLuong, string giaBanLe, string giaBanSi)
        {
            if (!parseGia(giaBanLe, "Giá bán lẻ", out decimal retailPrice)) 
                return false;

            if (!parseGia(giaBanSi, "Giá bán sỉ", out decimal wholesalePrice)) 
                return false;

            var bienThe = new ProductVariant
            {
                VariantID = maVariant,
                ProductID = maSP,
                Unit = donVi,
                Concentration = hamLuong,
                RetailPrice = retailPrice,
                WholesalePrice = wholesalePrice
            };

            bool ketQua = bus.sua(bienThe, out string loi);
            if (!ketQua)
            {
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ketQua;
        }

        public bool xoa(int maVariant)
        {
            var xacNhan = MessageBox.Show("Bạn có chắc muốn xóa biến thể này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes) 
                return false;

            bool ketQua = bus.xoa(maVariant, out string loi);
            if (!ketQua)
            {
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return ketQua;
        }

        public List<ProductVariant> timKiem(string keyword, int maSP)
        {
            return bus.timKiem(keyword, maSP);
        }

        private bool parseGia(string input, string tenTruong, out decimal gia)
        {
            if (!decimal.TryParse(input, out gia))
            {
                MessageBox.Show(tenTruong + " không hợp lệ! Vui lòng nhập số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}