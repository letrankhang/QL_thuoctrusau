using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.Controllers
{
    public class ProductController
    {
        private ProductBUS sanPhamBus = new ProductBUS();
        private CategoryBUS loaiBus = new CategoryBUS();

        public List<Category> LayDanhSachLoai()
        {
            return loaiBus.layDanhSachLoai();
        }

        public List<Product> LayDanhSach()
        {
            return sanPhamBus.layDanhSach();
        }

        public List<Product> TimKiem(string tuKhoa)
        {
            return sanPhamBus.timKiem(tuKhoa);
        }

        public List<Product> LocTheoLoai(int maLoai)
        {
            if (maLoai == -1)
            {
                return sanPhamBus.layDanhSach();
            }

            return sanPhamBus.layDanhSach().Where(sanPham => sanPham.CategoryID == maLoai).ToList();
        }

        public bool Them(Product sanPham, out string loi)
        {
            loi = "";
            if (!KiemTraHopLe(sanPham, laThemMoi: true, out loi))
            {
                return false;
            }

            return sanPhamBus.them(sanPham, out loi);
        }

        public bool Sua(Product sanPham, out string loi)
        {
            loi = "";
            if (!KiemTraHopLe(sanPham, laThemMoi: false, out loi))
            {
                return false;
            }

            return sanPhamBus.sua(sanPham, out loi);
        }

        public bool Xoa(int maSanPham, out string loi)
        {
            loi = "";
            if (maSanPham <= 0)
            {
                loi = "Mã sản phẩm không hợp lệ!";
                return false;
            }

            return sanPhamBus.xoa(maSanPham, out loi);
        }

        private bool KiemTraHopLe(Product sanPham, bool laThemMoi, out string loi)
        {
            loi = "";
            if (sanPham.ProductID <= 0)
            {
                loi = "Mã sản phẩm phải là số nguyên dương!";
                return false;
            }

            if (laThemMoi)
            {
                bool trung = sanPhamBus.layDanhSach().Any(sp => sp.ProductID == sanPham.ProductID);
                if (trung)
                {
                    loi = "Mã sản phẩm " + sanPham.ProductID + " đã tồn tại!";
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(sanPham.Name))
            {
                loi = "Tên sản phẩm không được để trống!";
                return false;
            }

            if (sanPham.Name.Length > 100)
            {
                loi = "Tên sản phẩm không được vượt quá 100 ký tự!";
                return false;
            }

            if (sanPham.CategoryID == -1 || sanPham.CategoryID <= 0)
            {
                loi = "Vui lòng chọn loại sản phẩm hợp lệ!";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(sanPham.Description) && sanPham.Description.Length > 399)
            {
                loi = "Mô tả không được vượt quá 399 ký tự!";
                return false;
            }
            return true;
        }

        public List<Product> LayDanhSachKemBienThe()
        {
            return sanPhamBus.layDanhSachKemBienThe();
        }
    }
}