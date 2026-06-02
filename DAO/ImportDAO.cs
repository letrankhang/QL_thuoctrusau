using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class ImportDAO
    {
        private AppDbContext db = new AppDbContext();

        public bool SaveImport(Import import, List<Batch> batches, out string error)
        {
            error = "";
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Imports.Add(import);
                    db.SaveChanges(); // Lấy ID cho Import

                    foreach (var batch in batches)
                    {
                        batch.ImportID = import.ImportID;
                        db.Batches.Add(batch);
                        db.SaveChanges(); // Lấy ID cho Batch

                        var invTrans = new InventoryTransaction
                        {
                            BatchID = batch.BatchID,
                            Quantity = batch.InitialQuantity,
                            TransactionType = "IMPORT",
                            ReferenceID = import.ImportID,
                            CreatedAt = DateTime.Now
                        };
                        db.InventoryTransactions.Add(invTrans);
                    }

                    // Xử lý công nợ NCC nếu cần (Giả định trả sau hoặc ghi nợ)
                    if (import.Status == "DEBT")
                    {
                        var debt = new DebtTransaction
                        {
                            SupplierID = import.SupplierID,
                            Amount = import.TotalAmount,
                            TransactionType = "PURCHASE",
                            ReferenceImportID = import.ImportID,
                            TransactionDate = DateTime.Now,
                            Note = $"Nhập hàng nợ đơn #{import.ImportID}"
                        };
                        db.DebtTransactions.Add(debt);
                    }

                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    error = ex.Message;
                    return false;
                }
            }
        }

        public List<Import> GetAll()
        {
            return db.Imports.Include(i => i.Supplier).Include(i => i.User).OrderByDescending(i => i.ImportDate).ToList();
        }
    }
}
