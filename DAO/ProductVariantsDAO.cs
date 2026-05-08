using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class ProductVariantDAO
    {
        AppDbContext db = new AppDbContext();

        public List<ProductVariant> layTatCa()
        {
            return db.ProductVariants.ToList();
        }

        public List<ProductVariant> layTheoSanPham(int maSP)
        {
            return db.ProductVariants.Where(v => v.ProductID == maSP).ToList();
        }

        public bool themMoi(ProductVariant bienThe)
        {
            db.ProductVariants.Add(bienThe);
            return db.SaveChanges() > 0;
        }

        public bool capNhat(ProductVariant bienThe)
        {
            var timThay = db.ProductVariants.Find(bienThe.VariantID);
            if (timThay == null)
            {
                return false;
            }
            timThay.ProductID = bienThe.ProductID;
            timThay.Unit = bienThe.Unit;
            timThay.Concentration = bienThe.Concentration;
            timThay.RetailPrice = bienThe.RetailPrice;
            timThay.WholesalePrice = bienThe.WholesalePrice;

            return db.SaveChanges() > 0;
        }

        public bool xoaTheoMa(int maVariant)
        {
            var timThay = db.ProductVariants.Find(maVariant);
            if (timThay == null)
            {
                return false;
            }

            db.ProductVariants.Remove(timThay);
            return db.SaveChanges() > 0;
        }

        public bool maDaTonTai(int maVariant)
        {
            return db.ProductVariants.Any(v => v.VariantID == maVariant);
        }
    }
}