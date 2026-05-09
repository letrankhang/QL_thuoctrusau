using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;
using System;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class CustomerBUS
    {
        private CustomerDAO khachHangDao = new CustomerDAO();

        public Result<List<Customer>> GetAllCustomers()
        {
            try
            {
                var list = khachHangDao.layDanhSach();
                return Result<List<Customer>>.Success(list);
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomerBUS.GetAllCustomers");
                return Result<List<Customer>>.Failure("Lỗi lấy danh sách khách hàng: " + ex.Message);
            }
        }

        public List<Customer> layDanhSach() => khachHangDao.layDanhSach();

        public List<Customer> timKiem(string tuKhoa) => khachHangDao.timKiem(tuKhoa);

        public Result<List<Customer>> SearchCustomers(string tuKhoa)
        {
            try
            {
                var list = khachHangDao.timKiem(tuKhoa);
                return Result<List<Customer>>.Success(list);
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomerBUS.SearchCustomers");
                return Result<List<Customer>>.Failure("Lỗi tìm kiếm khách hàng: " + ex.Message);
            }
        }

        public bool them(Customer khachHang, out string loi) => khachHangDao.them(khachHang, out loi);
        public bool sua(Customer khachHang, out string loi) => khachHangDao.sua(khachHang, out loi);
        public bool xoa(int maKhachHang, out string loi) => khachHangDao.xoa(maKhachHang, out loi);
        public bool kiemTraSoDienThoaiTonTai(string soDienThoai, int boQuaID = 0) => khachHangDao.kiemTraSoDienThoaiTonTai(soDienThoai, boQuaID);
    }
}
