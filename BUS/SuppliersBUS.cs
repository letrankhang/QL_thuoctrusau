using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class SuppliersBUS
    {
        private SuppliersDAO nhaCungCapDao = new SuppliersDAO();

        public List<Supplier> layDanhSach()
        {
            return nhaCungCapDao.layDanhSach();
        }

        public List<Supplier> timKiem(string tuKhoa)
        {
            return nhaCungCapDao.timKiem(tuKhoa);
        }

        public bool them(Supplier nhaCungCap, out string loi)
        {
            return nhaCungCapDao.them(nhaCungCap, out loi);
        }

        public bool sua(Supplier nhaCungCap, out string loi)
        {
            return nhaCungCapDao.sua(nhaCungCap, out loi);
        }

        public bool xoa(int maNhaCungCap, out string loi)
        {
            return nhaCungCapDao.xoa(maNhaCungCap, out loi);
        }

        public bool kiemTraSoDienThoaiTonTai(string soDienThoai, int boQuaID = 0)
        {
            return nhaCungCapDao.kiemTraSoDienThoaiTonTai(soDienThoai, boQuaID);
        }
    }
}