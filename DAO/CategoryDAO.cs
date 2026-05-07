using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class CategoryDAO
    {
        AppDbContext db = new AppDbContext();

        public List<Category> layTatCaLoai()
        {
            return db.Categories.ToList();
        }
    }
}
