using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class OrderBUS
    {
        private OrderDAO dao = new OrderDAO();

        public bool CreateOrder(Order order, List<OrderDetail> details, out string error)
        {
            if (order.CustomerID == 0)
            {
                error = "Vui lòng chọn khách hàng!";
                return false;
            }
            if (details == null || details.Count == 0)
            {
                error = "Đơn hàng phải có ít nhất một sản phẩm!";
                return false;
            }
            return dao.SaveOrder(order, details, out error);
        }

        public List<Order> GetAllOrders()
        {
            return dao.GetOrders();
        }

        public Order GetOrderById(int id)
        {
            return dao.GetOrderById(id);
        }
    }
}
