using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class OrderDAO
    {
        private AppDbContext db = new AppDbContext();

        public bool SaveOrder(Order order, List<OrderDetail> details, out string error)
        {
            error = "";
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Orders.Add(order);
                    db.SaveChanges(); // Lấy ID cho Order

                    foreach (var detail in details)
                    {
                        detail.OrderID = order.OrderID;
                        db.OrderDetails.Add(detail);
                        db.SaveChanges(); // Lấy ID cho OrderDetail

                        // Xử lý trừ kho theo lô (FEFO - First Expired First Out)
                        int remainingToPick = detail.OrderQuantity;
                            
                        // Lấy danh sách lô còn hàng của biến thể này, ưu tiên hạn dùng gần nhất
                        var batches = db.Batches
                            .Where(b => b.VariantID == detail.VariantID && b.RemainingQuantity > 0)
                            .OrderBy(b => b.ExpiryDate)
                            .ToList();

                        if (batches.Sum(b => b.RemainingQuantity) < remainingToPick)
                        {
                            throw new Exception($"Sản phẩm {detail.VariantID} không đủ tồn kho!");
                        }

                        foreach (var batch in batches)
                        {
                            if (remainingToPick <= 0) break;

                            int pickQuantity = Math.Min(batch.RemainingQuantity, remainingToPick);
                                
                            // Lưu OrderDetailBatch
                            var odb = new OrderDetailBatch
                            {
                                OrderDetailID = detail.OrderDetailID,
                                BatchID = batch.BatchID,
                                Quantity = pickQuantity
                            };
                            db.OrderDetailBatches.Add(odb);

                            // Cập nhật số lượng lô
                            batch.RemainingQuantity -= pickQuantity;

                            var invTrans = new InventoryTransaction
                            {
                                BatchID = batch.BatchID,
                                Quantity = -pickQuantity,
                                TransactionType = "SALE",
                                ReferenceID = order.OrderID,
                                CreatedAt = DateTime.Now
                            };
                            db.InventoryTransactions.Add(invTrans);

                            remainingToPick -= pickQuantity;
                        }
                    }

                    // xử lý công nợ nếu status là 'DEBT' hoặc đơn hàng chưa thanh toán hết
                    if (order.Status == "DEBT")
                    {
                        var debt = new DebtTransaction
                        {
                            CustomerID = order.CustomerID,
                            Amount = order.TotalAmount,
                            TransactionType = "SALE",
                            ReferenceOrderID = order.OrderID,
                            TransactionDate = DateTime.Now,
                            Note = $"Bán nợ đơn hàng #{order.OrderID}"
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

        public List<Order> GetOrders()
        {
            return db.Orders.Include(o => o.Customer).Include(o => o.User).OrderByDescending(o => o.OrderDate).ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return db.Orders
                .Include(o => o.Customer)
                .Include(o => o.User)
                .Include(o => o.OrderDetails.Select(od => od.ProductVariant.Product))
                .Include(o => o.DebtTransactions)
                .FirstOrDefault(o => o.OrderID == orderId);
        }
    }
}
