using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Linq;
using System.Collections.Generic;

public class SuppliersDAO
{
    public List<Supplier> layDanhSach()
    {
        using (var db = new AppDbContext()) 
        {
            return db.Suppliers.OrderBy(ncc => ncc.SupplierID).ToList();
        }
    }

    public List<Supplier> timKiem(string tuKhoa)
    {
        using (var db = new AppDbContext())
        {
            if (tuKhoa == null) tuKhoa = "";
            tuKhoa = tuKhoa.Trim().ToLower();
            return db.Suppliers.Where(ncc => ncc.Name.ToLower().Contains(tuKhoa)
                                          || ncc.Phone.Contains(tuKhoa)
                                          || ncc.SupplierID.ToString().Contains(tuKhoa))
                     .OrderBy(ncc => ncc.SupplierID).ToList();
        }
    }

    public bool them(Supplier nhaCungCap, out string loi)
    {
        loi = "";
        try
        {
            using (var db = new AppDbContext())
            {
                nhaCungCap.CreatedAt = DateTime.Now;
                db.Suppliers.Add(nhaCungCap);
                db.SaveChanges();
                return true;
            }
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
            using (var db = new AppDbContext())
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
            using (var db = new AppDbContext())
            {
                var nhaCungCap = db.Suppliers.Find(maNhaCungCap);
                if (nhaCungCap == null)
                {
                    loi = "Không tìm thấy nhà cung cấp cần xóa!";
                    return false;
                }
                bool coGD = db.Imports.Any(nh => nh.SupplierID == maNhaCungCap);
                if (coGD)
                {
                    loi = "Không thể xóa do nhà cung cấp này đã có đơn hàng!";
                    return false;
                }
                db.Suppliers.Remove(nhaCungCap);
                db.SaveChanges();
                return true;
            }
        }
        catch (Exception ex)
        {
            loi = "Lỗi khi xóa nhà cung cấp: " + ex.Message;
            return false;
        }
    }

    public bool kiemTraSoDienThoaiTonTai(string soDienThoai, int boQuaID = 0)
    {
        using (var db = new AppDbContext())
        {
            return db.Suppliers.Any(ncc => ncc.Phone == soDienThoai && ncc.SupplierID != boQuaID);
        }
    }
}