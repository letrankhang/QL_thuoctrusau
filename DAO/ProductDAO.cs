using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class ProductDAO
    {
        AppDbContext db = new AppDbContext();

        public List<Product> layTatCa()
        {
            return db.Products.ToList();
        }

        public bool themMoi(Product sp)
        {
            db.Products.Add(sp);
            return db.SaveChanges() > 0;
        }

        public bool capNhat(Product sp)
        {
            var timThay = db.Products.Find(sp.ProductID);
            if (timThay == null)
            {
                return false;
            }

            timThay.Name = sp.Name;
            timThay.CategoryID = sp.CategoryID;
            timThay.Description = sp.Description;
            timThay.ImagePath = sp.ImagePath;
            return db.SaveChanges() > 0;
        }

        public bool xoaTheoMa(int maSP)
        {
            var timThay = db.Products.Find(maSP);
            if (timThay == null)
            {
                return false;
            }

            db.Products.Remove(timThay);
            return db.SaveChanges() > 0;
        }

        public bool maDaTonTai(int maSP)
        {
            return db.Products.Any(s => s.ProductID == maSP);
        }

        public List<Product> layTatCaKemBienThe()
        {
            return db.Products.Include(p => p.Category).Include(p => p.ProductVariants).ToList();
        }
    }
}