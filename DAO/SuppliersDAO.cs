using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class SuppliersDAO
    {
        AppDbContext db = new AppDbContext();

        public List<Supplier> layDanhSach()
        {
            return db.Suppliers.OrderBy(ncc => ncc.SupplierID).ToList();
        }

        public List<Supplier> timKiem(string tuKhoa)
        {
            if (tuKhoa == null)
            {
                tuKhoa = "";
            }
            tuKhoa = tuKhoa.Trim().ToLower();

            return db.Suppliers.Where(ncc => ncc.Name.ToLower().Contains(tuKhoa)
                                          || ncc.Phone.Contains(tuKhoa)
                                          || ncc.SupplierID.ToString().Contains(tuKhoa))
                     .OrderBy(ncc => ncc.SupplierID)
                     .ToList();
        }

        public bool them(Supplier nhaCungCap, out string loi)
        {
            loi = "";
            try
            {
                nhaCungCap.CreatedAt = DateTime.Now;
                db.Suppliers.Add(nhaCungCap);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                loi = "Lỗi khi thêm nhà cung cấp: " + ex.Message;
                return false;
            }
        }

        public bool sua(Supplier nhaCungCap, out string loi)
        {
            loi = "";
            try
            {
                var existing = db.Suppliers.Find(nhaCungCap.SupplierID);
                if (existing == null)
                {
                    loi = "Không tìm thấy nhà cung cấp cần sửa!";
                    return false;
                }

                existing.Name = nhaCungCap.Name;
                existing.Phone = nhaCungCap.Phone;
                existing.Address = nhaCungCap.Address;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                loi = "Lỗi khi sửa nhà cung cấp: " + ex.Message;
                return false;
            }
        }

        public bool xoa(int maNhaCungCap, out string loi)
        {
            loi = "";
            try
            {
                var nhaCungCap = db.Suppliers.Find(maNhaCungCap);
                if (nhaCungCap == null)
                {
                    loi = "Không tìm thấy nhà cung cấp cần xóa!";
                    return false;
                }

                db.Suppliers.Remove(nhaCungCap);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                loi = "Lỗi khi xóa nhà cung cấp: " + ex.Message;
                return false;
            }
        }

        public bool kiemTraSoDienThoaiTonTai(string soDienThoai, int boQuaID = 0)
        {
            return db.Suppliers.Any(ncc => ncc.Phone == soDienThoai && ncc.SupplierID != boQuaID);
        }
    }
}