using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class ProductVariantBUS
    {
        ProductVariantDAO dao = new ProductVariantDAO();

        public List<ProductVariant> layDanhSach()
        {
            return dao.layTatCa();
        }

        public List<ProductVariant> layTheoSanPham(int maSP)
        {
            return dao.layTheoSanPham(maSP);
        }

        private bool validateBienThe(ProductVariant bienThe, out string loi)
        {
            loi = "";

            if (bienThe.ProductID == 0)
            {
                loi = "Mã sản phẩm không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(bienThe.Unit))
            {
                loi = "Đơn vị tính không được để trống!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(bienThe.Concentration))
            {
                loi = "Hàm lượng không được để trống!";
                return false;
            }
            if (bienThe.RetailPrice <= 0)
            {
                loi = "Giá bán lẻ phải lớn hơn 0!";
                return false;
            }
            if (bienThe.WholesalePrice < 0)
            {
                loi = "Giá bán sỉ không được âm!";
                return false;
            }
            if (bienThe.WholesalePrice > bienThe.RetailPrice)
            {
                loi = "Giá bán sỉ không được cao hơn giá bán lẻ!";
                return false;
            }

            return true;
        }

        public bool them(ProductVariant bienThe, out string loi)
        {
            if (!validateBienThe(bienThe, out loi)) return false;
            return dao.themMoi(bienThe);
        }

        public bool sua(ProductVariant bienThe, out string loi)
        {
            if (!validateBienThe(bienThe, out loi)) return false;
            return dao.capNhat(bienThe);
        }

        public bool xoa(int maVariant, out string loi)
        {
            loi = "";
            if (maVariant == 0)
            {
                loi = "Vui lòng chọn biến thể cần xóa!";
                return false;
            }
            return dao.xoaTheoMa(maVariant);
        }

        public List<ProductVariant> timKiem(string keyword, int maSP)
        {
            return dao.layTheoSanPham(maSP)
                      .FindAll(v =>
                          v.Unit.ToLower().Contains(keyword.ToLower()) ||
                          (v.Concentration != null && v.Concentration.ToLower().Contains(keyword.ToLower())) ||
                          v.VariantID.ToString().Contains(keyword));
        }
    }
}