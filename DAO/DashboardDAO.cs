using QL_CuaHangBanThuocTruSau.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class DashboardDAO
    {
        public DashboardDAO() { }

        public List<object> GetRevenueLast7Days()
        {
            using (var context = new AppDbContext())
            {
                var endDate = DateTime.Today;
                var startDate = endDate.AddDays(-6);

                var query = context.Orders
                    .Where(o => DbFunctions.TruncateTime(o.OrderDate) >= startDate && DbFunctions.TruncateTime(o.OrderDate) <= endDate)
                    .GroupBy(o => DbFunctions.TruncateTime(o.OrderDate))
                    .Select(g => new
                    {
                        Date = g.Key.Value,
                        Revenue = g.Sum(o => o.TotalAmount),
                        OrderCount = g.Count(),
                        ProductCount = g.Sum(o => o.OrderDetails.Sum(od => (int?)od.OrderQuantity) ?? 0)
                    })
                    .OrderBy(g => g.Date)
                    .ToList();

                var result = Enumerable.Range(0, 7)
                    .Select(i => startDate.AddDays(i))
                    .Select(date => (object)new
                    {
                        Date = date,
                        DateStr = date.ToString("dd/MM"),
                        Revenue = query.FirstOrDefault(q => q.Date == date)?.Revenue ?? 0,
                        ProductCount = query.FirstOrDefault(q => q.Date == date)?.ProductCount ?? 0
                    })
                    .ToList();

                return result;
            }
        }

        public List<object> GetNearingExpiryProducts(int days = 30)
        {
            using (var context = new AppDbContext())
            {
                var thresholdDate = DateTime.Today.AddDays(days);
                return context.Batches
                    .Where(b => b.ExpiryDate <= thresholdDate && b.RemainingQuantity > 0)
                    .OrderBy(b => b.ExpiryDate)
                    .Select(b => (object)new
                    {
                        ProductName = b.ProductVariant.Product.Name + " (" + b.ProductVariant.Unit + ")",
                        BatchID = b.BatchID,
                        ExpiryDate = b.ExpiryDate,
                        RemainingQuantity = b.RemainingQuantity
                    })
                    .ToList();
            }
        }

        public object GetDashboardSummary()
        {
            using (var context = new AppDbContext())
            {
                var today = DateTime.Today;

                var totalRevenue = context.Orders.Sum(o => (decimal?)o.TotalAmount) ?? 0;
                var newOrdersToday = context.Orders.Count(o => DbFunctions.TruncateTime(o.OrderDate) == today);

                var customerDebt = context.DebtTransactions
                    .Where(t => t.CustomerID != null)
                    .ToList()
                    .Sum(t => (t.TransactionType == "DEBT" || t.TransactionType == "SALE" ? 1 : -1) * t.Amount);

                var inventoryValue = context.Batches
                    .Where(b => b.RemainingQuantity > 0)
                    .Sum(b => (decimal?)(b.RemainingQuantity * b.ImportPrice)) ?? 0;

                return new
                {
                    TotalRevenue = totalRevenue,
                    NewOrdersToday = newOrdersToday,
                    CustomerDebt = customerDebt,
                    InventoryValue = inventoryValue
                };
            }
        }
    }
}
