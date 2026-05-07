using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class CustomerDAO
    {
        public CustomerDAO() { }

        public List<Customer> GetAll()
        {
            using (var context = new AppDbContext())
            {
                // Tắt ProxyCreation để tránh lỗi Lazy Loading khi bind vào UI
                context.Configuration.ProxyCreationEnabled = false;
                return context.Customers.AsNoTracking().ToList();
            }
        }

        public Customer GetById(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Configuration.ProxyCreationEnabled = false;
                return context.Customers.AsNoTracking().FirstOrDefault(c => c.CustomerID == id);
            }
        }

        public decimal GetTotalDebt(int customerId)
        {
            using (var context = new AppDbContext())
            {
                var transactions = context.DebtTransactions
                    .Where(t => t.CustomerID == customerId)
                    .ToList();

                decimal totalDebt = transactions
                    .Where(t => t.TransactionType == "DEBT" || t.TransactionType == "SALE")
                    .Sum(t => t.Amount);

                decimal totalPaid = transactions
                    .Where(t => t.TransactionType == "PAYMENT" || t.TransactionType == "REFUND")
                    .Sum(t => t.Amount);

                return totalDebt - totalPaid;
            }
        }

        public bool Add(Customer customer)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    customer.CreatedAt = DateTime.Now;
                    context.Customers.Add(customer);
                    return context.SaveChanges() > 0;
                }
                catch { return false; }
            }
        }

        public bool Update(Customer customer)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    var existing = context.Customers.Find(customer.CustomerID);
                    if (existing == null) return false;
                    existing.Name = customer.Name;
                    existing.Phone = customer.Phone;
                    existing.Address = customer.Address;
                    return context.SaveChanges() > 0;
                }
                catch { return false; }
            }
        }

        public bool Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    var customer = context.Customers.Find(id);
                    if (customer == null) return false;
                    if (context.Orders.Any(o => o.CustomerID == id)) return false;
                    context.Customers.Remove(customer);
                    return context.SaveChanges() > 0;
                }
                catch { return false; }
            }
        }
    }
}
