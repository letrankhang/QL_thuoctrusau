using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    using QL_CuaHangBanThuocTruSau.DAO;
    using QL_CuaHangBanThuocTruSau.Models;
    using System.Security.Cryptography;

    public class ProductBUS
    {
        ProductDAO dao = new ProductDAO();

        public List<Product> layDanhSach()
        {
            return dao.layTatCa();
        }

        public bool them(Product sp, out string loi)
        {
            loi = "";
            if (sp.ProductID == 0)
            {
                loi = "Mã sản phẩm không được để trống!";
                return false;
            }

            if (string.IsNullOrEmpty(sp.Name))
            {
                loi = "Tên sản phẩm không được để trống!";
                return false;
            } 
                
            if (dao.maDaTonTai(sp.ProductID))
            {
                loi = "Mã sản phẩm đã tồn tại!";
                return false;
            }

            return dao.themMoi(sp);
        }

        public bool sua(Product sp, out string loi)
        {
            loi = "";
            if (string.IsNullOrEmpty(sp.Name))
            {
                loi = "Tên sản phẩm không được để trống!";
                return false;
            }

            return dao.capNhat(sp);
        }

        public bool xoa(int maSP, out string loi)
        {
            loi = "";
            if (maSP == 0)
            {
                loi = "Vui lòng chọn sản phẩm cần xóa!";
                return false;
            }

            return dao.xoaTheoMa(maSP);
        }

        public List<Product> timKiem(string keyword)
        {
            return dao.layTatCa().FindAll(s => s.Name.ToLower().Contains(keyword.ToLower())
                                         || s.ProductID.ToString().Contains(keyword.ToLower()));
        }

        public List<Product> layDanhSachKemBienThe()
        {
            return dao.layTatCaKemBienThe();
        }
    }
}