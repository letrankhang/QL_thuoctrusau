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
        // Hạn mức nợ mặc định cho tất cả khách hàng vì SQL gốc không có cột CreditLimit
        private const decimal GlobalCreditLimit = 10000000;
        private AppDbContext db = new AppDbContext();  

        public List<Order> GetAllOrders()
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Orders.Include(o => o.Customer).Include(o => o.User).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "SaleDAO.GetAllOrders");
                return new List<Order>();
            }
        }

        public Order GetOrderById(int orderId)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Orders
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
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Kiểm tra Hạn mức tín dụng (Sử dụng GlobalCreditLimit)
                    decimal newDebt = order.TotalAmount - paidAmount;
                    if (newDebt > 0)
                    {
                        var debtList = db.DebtTransactions.Where(t => t.CustomerID == order.CustomerID).ToList();
                        var currentDebt = debtList.Sum(t => (t.TransactionType == "DEBT" || t.TransactionType == "SALE" ? 1 : -1) * t.Amount);

                        if ((currentDebt + newDebt) > GlobalCreditLimit)
                        {
                            Logger.LogError($"Vượt hạn mức nợ cho phép ({GlobalCreditLimit:N0}đ)!", "SaleDAO.CreateOrder");
                            return false;
                        }
                    }

                    // Lưu Order & Trừ kho FEFO
                    order.OrderDate = DateTime.Now;
                    db.Orders.Add(order);
                    db.SaveChanges();

                    foreach (var detail in details)
                    {
                        detail.OrderID = order.OrderID;
                        db.OrderDetails.Add(detail);
                        db.SaveChanges();

                        int remaining = detail.OrderQuantity;
                        var batches = db.Batches.Where(b => b.VariantID == detail.VariantID && b.RemainingQuantity > 0)
                            .OrderBy(b => b.ExpiryDate).ToList();

                        foreach (var batch in batches)
                        {
                            if (remaining <= 0) break;
                            int pick = Math.Min(remaining, batch.RemainingQuantity);
                            batch.RemainingQuantity -= pick;

                            db.OrderDetailBatches.Add(new OrderDetailBatch { OrderDetailID = detail.OrderDetailID, BatchID = batch.BatchID, Quantity = pick });
                            db.InventoryTransactions.Add(new InventoryTransaction { BatchID = batch.BatchID, Quantity = -pick, TransactionType = "SELL", ReferenceID = order.OrderID });
                            remaining -= pick;
                        }
                        if (remaining > 0)
                        {
                            Logger.LogError("Kho không đủ hàng cho variant ID: " + detail.VariantID, "SaleDAO.CreateOrder");
                            throw new Exception("Kho không đủ hàng!");
                        }
                    }

                    // Luôn ghi nhận giao dịch SALE với tổng số tiền để theo dõi nợ gốc
                    db.DebtTransactions.Add(new DebtTransaction 
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
                        db.DebtTransactions.Add(new DebtTransaction 
                        { 
                            CustomerID = order.CustomerID, 
                            Amount = paidAmount, 
                            TransactionType = "PAYMENT", 
                            ReferenceOrderID = order.OrderID, 
                            TransactionDate = DateTime.Now,
                            Note = $"Thanh toán cho đơn #{order.OrderID}"
                        });
                    }

                    db.SaveChanges();
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

        public bool ReturnOrder(int orderId, List<OrderDetailBatch> itemsToReturn)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var order = db.Orders.Find(orderId);
                    if (order == null) return false;

                    decimal refundTotal = 0;

                    foreach (var item in itemsToReturn)
                    {
                        var batch = db.Batches.Find(item.BatchID);
                        if (batch != null) batch.RemainingQuantity += item.Quantity;

                        var detail = db.OrderDetails.Find(item.OrderDetailID);
                        refundTotal += item.Quantity * (detail?.UnitPrice ?? 0);

                        db.InventoryTransactions.Add(new InventoryTransaction { BatchID = item.BatchID, Quantity = item.Quantity, TransactionType = "RETURN", ReferenceID = orderId, CreatedAt = DateTime.Now });
                    }

                    if (refundTotal > 0)
                    {
                        db.DebtTransactions.Add(new DebtTransaction { CustomerID = order.CustomerID, Amount = refundTotal, TransactionType = "REFUND", ReferenceOrderID = orderId, TransactionDate = DateTime.Now });
                    }

                    order.Status = "RETURNED";
                    db.SaveChanges();
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

        public List<Order> GetInvoicesByCustomerID(int customerId)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Orders
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
