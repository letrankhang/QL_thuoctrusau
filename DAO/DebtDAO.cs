using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class DebtDAO
    {
        public List<DebtTransaction> GetAll()
        {
            using (var db = new AppDbContext())
            {
                return db.DebtTransactions
                    .Include(d => d.Customer)
                    .Include(d => d.Supplier)
                    .Include(d => d.Order)
                    .Include(d => d.Import)
                    .OrderByDescending(d => d.TransactionDate)
                    .ToList();
            }
        }

        public List<DebtTransaction> GetByCustomer(int customerID)
        {
            using (var db = new AppDbContext())
            {
                return db.DebtTransactions
                    .Where(d => d.CustomerID == customerID)
                    .OrderByDescending(d => d.TransactionDate)
                    .ToList();
            }
        }

        public List<DebtTransaction> GetBySupplier(int supplierID)
        {
            using (var db = new AppDbContext())
            {
                return db.DebtTransactions
                    .Where(d => d.SupplierID == supplierID)
                    .OrderByDescending(d => d.TransactionDate)
                    .ToList();
            }
        }

        public bool AddTransaction(DebtTransaction trans, out string error)
        {
            error = "";
            try
            {
                using (var db = new AppDbContext())
                {
                    db.DebtTransactions.Add(trans);
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
