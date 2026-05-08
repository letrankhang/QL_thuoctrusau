using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.ViewModels;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.Controllers
{
    public class BatchController
    {
        BatchBUS bus = new BatchBUS();
        ProductBUS productBUS = new ProductBUS();
        SuppliersBUS suppliersBUS = new SuppliersBUS();

        public List<BatchViewModel> layDanhSach()
        {
            return bus.layDanhSach();
        }

        public List<BatchViewModel> timKiem(string keyword)
        {
            return bus.timKiem(keyword);
        }

        public List<BatchViewModel> layDanhSachTheoFilter(int productID, int supplierID, string trangThai)
        {
            return bus.layDanhSachTheoFilter(productID, supplierID, trangThai);
        }

        public List<Product> layDanhSachSanPham()
        {
            return productBUS.layDanhSach();
        }

        public List<Supplier> layDanhSachNhaCungCap()
        {
            return suppliersBUS.layDanhSach();
        }
    }
}