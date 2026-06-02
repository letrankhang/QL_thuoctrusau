using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class BatchDAO
    {
        private AppDbContext db = new AppDbContext();

        private IQueryable<BatchViewModel> baseQuery()
        {
            return from b in db.Batches
                   join pv in db.ProductVariants on b.VariantID equals pv.VariantID
                   join p in db.Products on pv.ProductID equals p.ProductID
                   join i in db.Imports on b.ImportID equals i.ImportID
                   join s in db.Suppliers on i.SupplierID equals s.SupplierID

                   select new BatchViewModel
                   {
                       BatchID = b.BatchID,
                       ProductID = p.ProductID,   
                       SupplierID = s.SupplierID,
                       TenSanPham = p.Name,
                       BienThe = pv.Unit + " - " + pv.Concentration,
                       NhaCungCap = s.Name,
                       GiaNhap = b.ImportPrice,
                       SoLuongBanDau = b.InitialQuantity,
                       SoLuongConLai = b.RemainingQuantity,
                       NgaySanXuat = b.ManufactureDate,
                       HanSuDung = b.ExpiryDate
                   };
        }

        public List<BatchViewModel> layDanhSach()
        {
            return baseQuery().ToList();
        }

        public List<BatchViewModel> timKiem(string keyword)
        {
            string kw = keyword.ToLower();
            return baseQuery().Where(x => x.TenSanPham.ToLower().Contains(kw)|| x.NhaCungCap.ToLower().Contains(kw)).ToList();
        }

        public List<BatchViewModel> layDanhSachTheoFilter(int productID, int supplierID)
        {
            var query = baseQuery();

            if (productID != -1)
            {
                query = query.Where(x => x.ProductID == productID);
            }
                
            if (supplierID != -1)
            {
                query = query.Where(x => x.SupplierID == supplierID);
            }
            return query.ToList();
        }
    }
}