using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class CustomerBUS
    {
        private readonly CustomerDAO _customerDAO;

        public CustomerBUS()
        {
            _customerDAO = new CustomerDAO();
        }

        public List<Customer> GetAllCustomers() => _customerDAO.GetAll();

        public List<Customer> GetList() => _customerDAO.GetAll();

        public Customer GetCustomerById(int id) => _customerDAO.GetById(id);

        public decimal GetCurrentDebt(int customerId) => _customerDAO.GetTotalDebt(customerId);

        public bool AddCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name)) return false;
            return _customerDAO.Add(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer.CustomerID <= 0 || string.IsNullOrWhiteSpace(customer.Name)) return false;
            return _customerDAO.Update(customer);
        }

        public bool DeleteCustomer(int id) => _customerDAO.Delete(id);

        public bool RemoveCustomer(int id) => _customerDAO.Delete(id);

        /// <summary>
        /// Hàm xử lý chung cho Thêm/Sửa để tương thích UI cũ
        /// </summary>
        public string HandleCustomer(Customer customer, string action)
        {
            bool result = false;
            if (action == "ADD") result = AddCustomer(customer);
            else if (action == "UPDATE") result = UpdateCustomer(customer);

            return result ? "Thành công" : "Thất bại (Vui lòng kiểm tra dữ liệu hoặc khách hàng đã có giao dịch)";
        }
    }
}
