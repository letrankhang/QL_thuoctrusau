using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class InventoryTransactionDAO
    {
        private AppDbContext db = new AppDbContext();

        public List<InventoryTransaction> GetAll()
        {
            return db.InventoryTransactions
                .Include(t => t.Batch)
                .Include(t => t.Batch.ProductVariant)
                .Include(t => t.Batch.ProductVariant.Product)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();
        }

        public List<InventoryTransaction> GetByBatch(int batchID)
        {
            return db.InventoryTransactions
                .Where(t => t.BatchID == batchID)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();
        }
    }
}
