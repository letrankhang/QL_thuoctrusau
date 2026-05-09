using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.Controllers
{
    public class OrderController
    {
        // Hàm lưu hóa đơn và trừ tồn kho theo lô (FEFO - Hạn dùng gần nhất trừ trước)
        public bool thanhToanHoaDon(Order donHang, List<OrderDetail> chiTietDon)
        {
            using (var db = new AppDbContext()) 
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // 1. Lưu thông tin hóa đơn chính
                        db.Orders.Add(donHang);
                        db.SaveChanges(); // Để lấy được ID của hóa đơn vừa tạo

                        // 2. Duyệt từng mặt hàng trong giỏ hàng
                        foreach (var item in chiTietDon)
                        {
                            item.OrderID = donHang.OrderID;
                            db.OrderDetails.Add(item);
                            db.SaveChanges(); // Lấy ID cho OrderDetail

                            // 3. LOGIC TRỪ KHO: Lấy các lô hàng của biến thể này, còn hàng, ưu tiên lô sắp hết hạn
                            var danhSachLo = db.Batches
                                .Where(b => b.VariantID == item.VariantID && b.RemainingQuantity > 0)
                                .OrderBy(b => b.ExpiryDate)
                                .ToList();

                            int soLuongCanBan = item.OrderQuantity;

                            foreach (var lo in danhSachLo)
                            {
                                if (soLuongCanBan <= 0) break;

                                int pickQuantity = Math.Min(lo.RemainingQuantity, soLuongCanBan);

                                // Lưu OrderDetailBatch
                                var odb = new OrderDetailBatch
                                {
                                    OrderDetailID = item.OrderDetailID,
                                    BatchID = lo.BatchID,
                                    Quantity = pickQuantity
                                };
                                db.OrderDetailBatches.Add(odb);

                                // Cập nhật số lượng lô
                                lo.RemainingQuantity -= pickQuantity;

                                // Ghi log giao dịch kho
                                var invTrans = new InventoryTransaction
                                {
                                    BatchID = lo.BatchID,
                                    Quantity = -pickQuantity,
                                    TransactionType = "SALE",
                                    ReferenceID = donHang.OrderID,
                                    CreatedAt = DateTime.Now
                                };
                                db.InventoryTransactions.Add(invTrans);

                                soLuongCanBan -= pickQuantity;
                            }

                            if (soLuongCanBan > 0)
                                throw new Exception("Không đủ hàng trong kho cho sản phẩm: " + item.VariantID);
                        }

                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        // Hàm lấy danh sách đơn hàng cũ (Dùng cho nút F4)
        public List<Order> layDanhSachDonCu()
        {
            using (var db = new AppDbContext())
            {
                return db.Orders.OrderByDescending(o => o.OrderDate).ToList();
            }
        }
    }
}