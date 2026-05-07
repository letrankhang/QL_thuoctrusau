using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class SaleBUS
    {
        private readonly SaleDAO _saleDAO;

        public SaleBUS()
        {
            _saleDAO = new SaleDAO();
        }

        public List<Order> GetAllOrders()

        {
            return _saleDAO.GetAllOrders();
        }

        public Order GetOrderById(int orderId)
        {
            return _saleDAO.GetOrderById(orderId);
        }

        /// <summary>
        /// Thực hiện thanh toán và lưu đơn hàng
        /// </summary>
        /// <param name="order">Thông tin đơn hàng (CustomerID, UserID, v.v.)</param>
        /// <param name="details">Danh sách chi tiết mặt hàng (VariantID, OrderQuantity, UnitPrice)</param>
        /// <param name="paidAmount">Số tiền khách đã trả</param>
        /// <returns>Thành công/Thất bại</returns>
        public bool ProcessSale(Order order, List<OrderDetail> details, decimal paidAmount)
        {
            try
            {
                // Validate dữ liệu cơ bản
                if (order == null || details == null || details.Count == 0)
                    return false;

                if (order.CustomerID <= 0 || order.UserID <= 0)
                    return false;

                return _saleDAO.CreateOrder(order, details, paidAmount);
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc xử lý thêm tùy yêu cầu
                Console.WriteLine("Lỗi tại BUS khi xử lý bán hàng: " + ex.Message);
                return false;
            }
        }

        public bool ReturnOrder(int orderId, List<OrderDetailBatch> itemsToReturn)
        {
            try
            {
                if (orderId <= 0 || itemsToReturn == null || itemsToReturn.Count == 0)
                    return false;

                return _saleDAO.ReturnOrder(orderId, itemsToReturn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tại BUS khi xử lý trả hàng: " + ex.Message);
                return false;
            }
        }
    }
}
