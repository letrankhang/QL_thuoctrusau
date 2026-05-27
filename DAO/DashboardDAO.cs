using QL_CuaHangBanThuocTruSau.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class DashboardDAO
    {
        private readonly AppDbContext _context;

        public DashboardDAO()
        {
            _context = new AppDbContext();
        }

        public dynamic GetRevenueLast7Days()
        {
            var endDate = DateTime.Today;
            var startDate = endDate.AddDays(-6);

            var query = _context.Orders
                .Where(o => DbFunctions.TruncateTime(o.OrderDate) >= startDate && DbFunctions.TruncateTime(o.OrderDate) <= endDate)
                .GroupBy(o => DbFunctions.TruncateTime(o.OrderDate))
                .Select(g => new {
                    Date = g.Key.Value,
                    Revenue = g.Sum(o => o.TotalAmount),
                    OrderCount = g.Count(),
                    ProductCount = g.Sum(o => o.OrderDetails.Sum(od => (int?)od.OrderQuantity) ?? 0)
                })
                .OrderBy(g => g.Date)
                .ToList();

            // Đảm bảo đủ 7 ngày kể cả ngày không có dữ liệu
            var result = Enumerable.Range(0, 7)
                .Select(i => startDate.AddDays(i))
                .Select(date => new {
                    Date = date,
                    DateStr = date.ToString("dd/MM"),
                    Revenue = query.FirstOrDefault(q => q.Date == date)?.Revenue ?? 0,
                    ProductCount = query.FirstOrDefault(q => q.Date == date)?.ProductCount ?? 0
                })
                .ToList();

            return result;
        }

        public dynamic GetNearingExpiryProducts(int days = 30)
        {
            var thresholdDate = DateTime.Today.AddDays(days);
            var today = DateTime.Today; 

            var result = _context.Batches
                .Where(b => b.ExpiryDate >= today         
                         && b.ExpiryDate <= thresholdDate   
                         && b.RemainingQuantity > 0)
                .OrderBy(b => b.ExpiryDate)
                .Select(b => new {
                    ProductName = b.ProductVariant.Product.Name + " (" + b.ProductVariant.Unit + ")",
                    BatchID = b.BatchID,
                    ExpiryDate = b.ExpiryDate,
                    RemainingQuantity = b.RemainingQuantity
                })
                .ToList();

            return result;
        }

        public dynamic GetDashboardSummary()
        {
            var today = DateTime.Today;

            // Đơn COMPLETED: tính full
            var revenueCompleted = _context.Orders
                .Where(o => o.Status == "COMPLETED")
                .Sum(o => (decimal?)o.TotalAmount) ?? 0;

            // Đơn DEBT: chỉ tính phần khách đã trả (PAYMENT)
            var revenueDebt = _context.DebtTransactions
                .Where(t => t.CustomerID != null
                         && t.TransactionType == "PAYMENT"
                         && t.ReferenceOrderID != null
                         && t.Order.Status == "DEBT")
                .Sum(t => (decimal?)t.Amount) ?? 0;

            var totalRevenue = revenueCompleted + revenueDebt;

            var newOrdersToday = _context.Orders
                .Count(o => DbFunctions.TruncateTime(o.OrderDate) == today);

            var customerDebt = _context.DebtTransactions
                .Where(t => t.CustomerID != null)
                .AsEnumerable()
                .Sum(t => (t.TransactionType == "SALE" || t.TransactionType == "DEBT" ? 1 : -1) * t.Amount);

            var supplierDebt = _context.DebtTransactions
                .Where(t => t.SupplierID != null)
                .AsEnumerable()
                .Sum(t => (t.TransactionType == "PURCHASE" || t.TransactionType == "DEBT" ? 1 : -1) * t.Amount);

            var inventoryValue = _context.Batches
                .Where(b => b.RemainingQuantity > 0)
                .Sum(b => (decimal?)(b.RemainingQuantity * b.ImportPrice)) ?? 0;

            return new
            {
                TotalRevenue = totalRevenue,
                NewOrdersToday = newOrdersToday,
                CustomerDebt = customerDebt + supplierDebt,
                InventoryValue = inventoryValue
            };
        }
    }
}