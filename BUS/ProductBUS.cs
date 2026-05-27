using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_CuaHangBanThuocTruSau.Utils;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    using QL_CuaHangBanThuocTruSau.DAO;
    using QL_CuaHangBanThuocTruSau.Models;
    using QL_CuaHangBanThuocTruSau.Context;

    public class ProductBUS
    {
        ProductDAO dao = new ProductDAO();
        ProductVariantDAO variantDao = new ProductVariantDAO();
        AppDbContext db = new AppDbContext();

        public Result<List<ProductVariant>> GetAllProductVariants()
        {
            try
            {
                var list = variantDao.layTatCa();
                foreach (var item in list)
                {
                    if (item.Product == null)
                        item.Product = db.Products.Find(item.ProductID);
                }
                return Result<List<ProductVariant>>.Success(list);
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "ProductBUS.GetAllProductVariants");
                return Result<List<ProductVariant>>.Failure("Lỗi lấy danh sách biến thể sản phẩm: " + ex.Message);
            }
        }

        public Result<List<ProductVariant>> SearchProducts(string keyword)
        {
            try
            {
                var list = variantDao.layTatCa()
                    .Where(v => (v.Product?.Name != null && v.Product.Name.ToLower().Contains(keyword.ToLower())) ||
                                v.Unit.ToLower().Contains(keyword.ToLower()))
                    .ToList();
                return Result<List<ProductVariant>>.Success(list);
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "ProductBUS.SearchProducts");
                return Result<List<ProductVariant>>.Failure("Lỗi tìm kiếm sản phẩm: " + ex.Message);
            }
        }

        public Result<int> GetStockQuantity(int variantId)
        {
            try
            {
                int totalStock = db.Batches
                    .Where(b => b.VariantID == variantId)
                    .Sum(b => (int?)b.RemainingQuantity) ?? 0;
                return Result<int>.Success(totalStock);
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "ProductBUS.GetStockQuantity");
                return Result<int>.Failure("Lỗi lấy số lượng tồn kho: " + ex.Message);
            }
        }

        public List<Product> layDanhSach() => dao.layTatCa();

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