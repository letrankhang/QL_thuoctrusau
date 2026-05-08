using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class CategoryDAO
    {
        AppDbContext db = new AppDbContext();

        public List<Category> layTatCaLoai()
        {
            return db.Categories.ToList();
        }

        public bool themMoiLoai(Category loai)
        {
            db.Categories.Add(loai);
            return db.SaveChanges() > 0;
        }

        public bool capNhatLoai(Category loai)
        {
            var timThay = db.Categories.Find(loai.CategoryID);
            if (timThay == null)
            {
                return false;
            }
            
            timThay.Name = loai.Name;
            timThay.Description = loai.Description;
            return db.SaveChanges() > 0;
        }

        public bool xoaTheoMa(int maLoai)
        {
            var timThay = db.Categories.Find(maLoai);
            if (timThay == null)
            {
                return false;
            }

            db.Categories.Remove(timThay);
            return db.SaveChanges() > 0;
        }

        public bool tenDaTonTai(string ten, int boQuaMa = 0)
        {
            return db.Categories.Any(c =>
                c.Name.ToLower() == ten.ToLower() &&
                c.CategoryID != boQuaMa);
        }
    }
}

