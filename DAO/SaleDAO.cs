using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;
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
                try
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    return context.Orders.Include(o => o.Customer).Include(o => o.User).AsNoTracking().ToList();
                }
                catch (Exception ex)
                {
                    Logger.Log(ex, "SaleDAO.GetAllOrders");
                    return new List<Order>();
                }
            }
        }

        public Order GetOrderById(int orderId)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    return context.Orders
                        .Include(o => o.Customer)
                        .Include(o => o.User)
                        .Include(o => o.OrderDetails.Select(od => od.ProductVariant.Product))
                        .Include(o => o.OrderDetails.Select(od => od.OrderDetailBatches.Select(odb => odb.Batch)))
                        .Include(o => o.DebtTransactions)
                        .FirstOrDefault(o => o.OrderID == orderId);
                }
                catch (Exception ex)
                {
                    Logger.Log(ex, $"SaleDAO.GetOrderById(orderId: {orderId})");
                    return null;
                }
            }
        }
        // Trong lớp SaleDAO
        public List<Order> GetOrdersByCustomer(int customerId)
        {
            List<Order> list = new List<Order>();
            return list;
        }

        public List<OrderDetail> GetDetailsByOrderId(int orderId)
        {
            List<OrderDetail> list = new List<OrderDetail>();
            return list;
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
                            var debtList = context.DebtTransactions.Where(t => t.CustomerID == order.CustomerID).ToList();
                            var currentDebt = debtList.Sum(t => (t.TransactionType == "DEBT" || t.TransactionType == "SALE" ? 1 : -1) * t.Amount);

                            if ((currentDebt + newDebt) > GlobalCreditLimit)
                            {
                                Logger.LogError($"Vượt hạn mức nợ cho phép ({GlobalCreditLimit:N0}đ)!", "SaleDAO.CreateOrder");
                                return false;
                            }
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
                            if (remaining > 0)
                            {
                                Logger.LogError("Kho không đủ hàng cho variant ID: " + detail.VariantID, "SaleDAO.CreateOrder");
                                throw new Exception("Kho không đủ hàng!");
                            }
                        }

                        // 3. Ghi nợ & Thanh toán
                        // Luôn ghi nhận giao dịch SALE với tổng số tiền để theo dõi nợ gốc
                        context.DebtTransactions.Add(new DebtTransaction 
                        { 
                            CustomerID = order.CustomerID, 
                            Amount = order.TotalAmount, 
                            TransactionType = "SALE", 
                            ReferenceOrderID = order.OrderID, 
                            TransactionDate = DateTime.Now,
                            Note = $"Bán hàng đơn #{order.OrderID}"
                        });

                        // Nếu có thanh toán, ghi nhận giao dịch PAYMENT
                        if (paidAmount > 0)
                        {
                            context.DebtTransactions.Add(new DebtTransaction 
                            { 
                                CustomerID = order.CustomerID, 
                                Amount = paidAmount, 
                                TransactionType = "PAYMENT", 
                                ReferenceOrderID = order.OrderID, 
                                TransactionDate = DateTime.Now,
                                Note = $"Thanh toán cho đơn #{order.OrderID}"
                            });
                        }

                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Logger.Log(ex, "SaleDAO.CreateOrder");
                        return false;
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
                        if (order == null) return false;

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
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Logger.Log(ex, $"SaleDAO.ReturnOrder(orderId: {orderId})");
                        return false;
                    }
                }
            }
        }

        public List<Order> GetInvoicesByCustomerID(int customerId)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    return context.Orders
                        .Where(o => o.CustomerID == customerId)
                        .OrderByDescending(o => o.OrderDate)
                        .AsNoTracking()
                        .ToList();
                }
                catch (Exception ex)
                {
                    Logger.Log(ex, $"SaleDAO.GetInvoicesByCustomerID(customerId: {customerId})");
                    return new List<Order>();
                }
            }
        }
    }
}
