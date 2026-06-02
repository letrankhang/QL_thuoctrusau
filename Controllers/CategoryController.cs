using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.Controllers
{
    public class CategoryController
    {
        private CategoryBUS bus = new CategoryBUS();

        public List<Category> layDanhSachLoai()
        {
            return bus.layDanhSachLoai();
        }

        public bool themMoiLoai(string ten, string moTa)
        {
            var loaiMoi = new Category
            {
                Name = ten.Trim(),
                Description = moTa.Trim()
            };

            return bus.themMoiLoai(loaiMoi);
        }

        public bool capNhatLoai(int maLoai, string ten, string moTa)
        {
            var loaiCapNhat = new Category
            {
                CategoryID = maLoai,
                Name = ten.Trim(),
                Description = moTa.Trim()
            };

            return bus.capNhatLoai(loaiCapNhat);
        }

        public bool xoaLoai(int maLoai)
        {
            return bus.xoaLoai(maLoai);
        }

        public bool kiemTraTenHopLe(string ten, int boQuaMa = 0)
        {
            return bus.kiemTraTenHopLe(ten, boQuaMa);
        }
    }
}