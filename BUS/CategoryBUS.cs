using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class CategoryBUS
    {
        CategoryDAO dao = new CategoryDAO();

        public List<Category> layDanhSachLoai()
        {
            return dao.layTatCaLoai();
        }
    }
}
