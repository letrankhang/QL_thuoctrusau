using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class BatchExportDAO
    {
        private AppDbContext db = new AppDbContext();

        public List<BatchViewModel> GetFullBatchData()
        {
            return (from b in db.Batches
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
                    }).ToList();
        }
    }
}
