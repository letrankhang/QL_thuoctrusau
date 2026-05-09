using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;
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

        public Result<List<Order>> GetAllOrders()
        {
            try
            {
                var orders = _saleDAO.GetAllOrders();
                return Result<List<Order>>.Success(orders);
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "SaleBUS.GetAllOrders");
                return Result<List<Order>>.Failure("Lỗi lấy danh sách đơn hàng: " + ex.Message);
            }
        }

        public Result<Order> GetOrderById(int orderId)
        {
            try
            {
                var order = _saleDAO.GetOrderById(orderId);
                if (order == null) return Result<Order>.Failure("Không tìm thấy đơn hàng");
                return Result<Order>.Success(order);
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "SaleBUS.GetOrderById");
                return Result<Order>.Failure("Lỗi lấy thông tin đơn hàng: " + ex.Message);
            }
        }

        /// <summary>
        /// Thực hiện thanh toán và lưu đơn hàng
        /// </summary>
        public Result ProcessSale(Order order, List<OrderDetail> details, decimal paidAmount)
        {
            try
            {
                // Validate dữ liệu cơ bản
                if (order == null || details == null || details.Count == 0)
                {
                    return Result.Failure("Dữ liệu đơn hàng hoặc chi tiết trống");
                }

                if (order.CustomerID <= 0 || order.UserID <= 0)
                {
                    return Result.Failure("Mã khách hàng hoặc mã nhân viên không hợp lệ");
                }

                if (_saleDAO.CreateOrder(order, details, paidAmount))
                {
                    return Result.Success("Xử lý đơn hàng thành công");
                }
                return Result.Failure("Lỗi khi lưu đơn hàng vào cơ sở dữ liệu");
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "SaleBUS.ProcessSale");
                return Result.Failure("Lỗi hệ thống khi xử lý đơn hàng: " + ex.Message);
            }
        }

        public Result ReturnOrder(int orderId, List<OrderDetailBatch> itemsToReturn)
        {
            try
            {
                if (orderId <= 0 || itemsToReturn == null || itemsToReturn.Count == 0)
                {
                    return Result.Failure("Mã đơn hàng hoặc danh sách trả hàng không hợp lệ");
                }

                if (_saleDAO.ReturnOrder(orderId, itemsToReturn))
                {
                    return Result.Success("Trả hàng thành công");
                }
                return Result.Failure("Lỗi khi xử lý trả hàng trong cơ sở dữ liệu");
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "SaleBUS.ReturnOrder");
                return Result.Failure("Lỗi hệ thống khi trả hàng: " + ex.Message);
            }
        }

        public Result<List<Order>> GetOrdersByCustomer(int customerId)
        {
            try
            {
                var orders = _saleDAO.GetOrdersByCustomer(customerId);
                return Result<List<Order>>.Success(orders);
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "SaleBUS.GetOrdersByCustomer");
                return Result<List<Order>>.Failure("Lỗi lấy danh sách đơn hàng theo khách hàng: " + ex.Message);
            }
        }

        public Result<List<OrderDetail>> GetOrderDetails(int orderId)
        {
            try
            {
                var details = _saleDAO.GetDetailsByOrderId(orderId);
                return Result<List<OrderDetail>>.Success(details);
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "SaleBUS.GetOrderDetails");
                return Result<List<OrderDetail>>.Failure("Lỗi lấy chi tiết đơn hàng: " + ex.Message);
            }
        }

        public Result<List<Order>> GetInvoicesByCustomerID(int customerId)
        {
            try
            {
                var orders = _saleDAO.GetInvoicesByCustomerID(customerId);
                return Result<List<Order>>.Success(orders);
            }
            catch (Exception ex)
            {
                Logger.Log(ex, $"SaleBUS.GetInvoicesByCustomerID(customerId: {customerId})");
                return Result<List<Order>>.Failure("Lỗi lấy danh sách hóa đơn: " + ex.Message);
            }
        }
    }
}
