using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class CategoryBUS
    {
        CategoryDAO dao = new CategoryDAO();

        public List<Category> layDanhSachLoai()
        {
            return dao.layTatCaLoai();
        }

        public bool themMoiLoai(Category loai)
        {
            return dao.themMoiLoai(loai);
        }

        public bool capNhatLoai(Category loai)
        {
            return dao.capNhatLoai(loai);
        }

        public bool xoaLoai(int maLoai)
        {
            return dao.xoaTheoMa(maLoai);
        }

        public bool kiemTraTenHopLe(string ten, int boQuaMa = 0)
        {
            if (string.IsNullOrWhiteSpace(ten))
            {
                return false;
            }

            return !dao.tenDaTonTai(ten.Trim(), boQuaMa);
        }
    }
}