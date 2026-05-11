using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class CustomerDAO
    {
        private AppDbContext db = new AppDbContext();

        public List<Customer> layDanhSach()
        {
            return db.Customers.OrderBy(c => c.CustomerID).ToList();
        }

        public List<Customer> timKiem(string tuKhoa)
        {
            if (string.IsNullOrEmpty(tuKhoa))
            {
                tuKhoa = "";
            }
            tuKhoa = tuKhoa.Trim().ToLower();

            return db.Customers.Where(c => c.Name.ToLower().Contains(tuKhoa)
                                          || c.Phone.Contains(tuKhoa)
                                          || c.CustomerID.ToString().Contains(tuKhoa))
                     .OrderBy(c => c.CustomerID)
                     .ToList();
        }

        public bool them(Customer khachHang, out string loi)
        {
            loi = "";
            try
            {
                khachHang.CreatedAt = DateTime.Now;
                db.Customers.Add(khachHang);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                loi = "Lỗi khi thêm khách hàng: " + ex.Message;
                return false;
            }
        }

        public bool sua(Customer khachHang, out string loi)
        {
            loi = "";
            try
            {
                var existing = db.Customers.Find(khachHang.CustomerID);
                if (existing == null)
                {
                    loi = "Không tìm thấy khách hàng cần sửa!";
                    return false;
                }

                existing.Name = khachHang.Name;
                existing.Phone = khachHang.Phone;
                existing.Address = khachHang.Address;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                loi = "Lỗi khi sửa khách hàng: " + ex.Message;
                return false;
            }
        }

        public bool xoa(int maKhachHang, out string loi)
        {
            loi = "";
            try
            {
                var khachHang = db.Customers.Find(maKhachHang);
                if (khachHang == null)
                {
                    loi = "Không tìm thấy khách hàng cần xóa!";
                    return false;
                }

                // Kiểm tra xem khách hàng có đơn hàng hoặc giao dịch nợ không trước khi xóa
                bool hasOrders = db.Orders.Any(o => o.CustomerID == maKhachHang);
                bool hasDebt = db.DebtTransactions.Any(d => d.CustomerID == maKhachHang);

                if (hasOrders || hasDebt)
                {
                    loi = "Không thể xóa khách hàng này vì đã có dữ liệu đơn hàng hoặc công nợ liên quan!";
                    return false;
                }

                db.Customers.Remove(khachHang);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                loi = "Lỗi khi xóa khách hàng: " + ex.Message;
                return false;
            }
        }

        public bool kiemTraSoDienThoaiTonTai(string soDienThoai, int boQuaID = 0)
        {
            return db.Customers.Any(c => c.Phone == soDienThoai && c.CustomerID != boQuaID);
        }

        public List<Customer> locTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            DateTime batDau = tuNgay.Date;
            DateTime ketThuc = denNgay.Date.AddDays(1);

            return db.Customers
                     .Where(c => c.CreatedAt >= batDau && c.CreatedAt < ketThuc)
                     .OrderBy(c => c.CustomerID)
                     .ToList();
        }
    }
}
