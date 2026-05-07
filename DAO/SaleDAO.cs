using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class SaleDAO
    {
        // Hạn mức nợ mặc định cho tất cả khách hàng (vì SQL gốc không có cột CreditLimit)
        private const decimal GlobalCreditLimit = 10000000;

        public SaleDAO() { }

        public List<Order> GetAllOrders()
        {
            using (var context = new AppDbContext())
            {
                context.Configuration.ProxyCreationEnabled = false;
                return context.Orders.Include(o => o.Customer).Include(o => o.User).AsNoTracking().ToList();
            }
        }

        public Order GetOrderById(int orderId)
        {
            using (var context = new AppDbContext())
            {
                context.Configuration.ProxyCreationEnabled = false;
                return context.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.User)
                    .Include(o => o.OrderDetails.Select(od => od.ProductVariant.Product))
                    .Include(o => o.OrderDetails.Select(od => od.OrderDetailBatches.Select(odb => odb.Batch)))
                    .FirstOrDefault(o => o.OrderID == orderId);
            }
        }

        public bool CreateOrder(Order order, List<OrderDetail> details, decimal paidAmount)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // 1. Kiểm tra Hạn mức tín dụng (Sử dụng GlobalCreditLimit)
                        decimal newDebt = order.TotalAmount - paidAmount;
                        if (newDebt > 0)
                        {
                            var currentDebt = context.DebtTransactions.Where(t => t.CustomerID == order.CustomerID)
                                .ToList().Sum(t => (t.TransactionType == "DEBT" || t.TransactionType == "SALE" ? 1 : -1) * t.Amount);
                            
                            if ((currentDebt + newDebt) > GlobalCreditLimit)
                                throw new Exception($"Vượt hạn mức nợ cho phép ({GlobalCreditLimit:N0}đ)!");
                        }

                        // 2. Lưu Order & Trừ kho FEFO
                        order.OrderDate = DateTime.Now;
                        context.Orders.Add(order);
                        context.SaveChanges();

                        foreach (var detail in details)
                        {
                            detail.OrderID = order.OrderID;
                            context.OrderDetails.Add(detail);
                            context.SaveChanges();

                            int remaining = detail.OrderQuantity;
                            var batches = context.Batches.Where(b => b.VariantID == detail.VariantID && b.RemainingQuantity > 0)
                                .OrderBy(b => b.ExpiryDate).ToList();

                            foreach (var batch in batches)
                            {
                                if (remaining <= 0) break;
                                int pick = Math.Min(remaining, batch.RemainingQuantity);
                                batch.RemainingQuantity -= pick;

                                context.OrderDetailBatches.Add(new OrderDetailBatch { OrderDetailID = detail.OrderDetailID, BatchID = batch.BatchID, Quantity = pick });
                                context.InventoryTransactions.Add(new InventoryTransaction { BatchID = batch.BatchID, Quantity = -pick, TransactionType = "SELL", ReferenceID = order.OrderID });
                                remaining -= pick;
                            }
                            if (remaining > 0) throw new Exception("Kho không đủ hàng!");
                        }

                        // 3. Ghi nợ
                        if (newDebt > 0)
                        {
                            context.DebtTransactions.Add(new DebtTransaction { CustomerID = order.CustomerID, Amount = newDebt, TransactionType = "DEBT", ReferenceOrderID = order.OrderID, TransactionDate = DateTime.Now });
                        }

                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public bool ReturnOrder(int orderId, List<OrderDetailBatch> itemsToReturn)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var order = context.Orders.Find(orderId);
                        decimal refundTotal = 0;

                        foreach (var item in itemsToReturn)
                        {
                            var batch = context.Batches.Find(item.BatchID);
                            if (batch != null) batch.RemainingQuantity += item.Quantity;

                            var detail = context.OrderDetails.Find(item.OrderDetailID);
                            refundTotal += item.Quantity * (detail?.UnitPrice ?? 0);

                            context.InventoryTransactions.Add(new InventoryTransaction { BatchID = item.BatchID, Quantity = item.Quantity, TransactionType = "RETURN", ReferenceID = orderId, CreatedAt = DateTime.Now });
                        }

                        if (refundTotal > 0)
                        {
                            context.DebtTransactions.Add(new DebtTransaction { CustomerID = order.CustomerID, Amount = refundTotal, TransactionType = "REFUND", ReferenceOrderID = orderId, TransactionDate = DateTime.Now });
                        }

                        order.Status = "RETURNED";
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch { transaction.Rollback(); return false; }
                }
            }
        }
    }
}
