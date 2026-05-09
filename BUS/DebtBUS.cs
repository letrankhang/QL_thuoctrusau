using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class DebtBUS
    {
        private DebtDAO dao = new DebtDAO();

        public List<DebtTransaction> GetAll()
        {
            return dao.GetAll();
        }

        public List<DebtTransaction> GetByCustomer(int customerID)
        {
            return dao.GetByCustomer(customerID);
        }

        public List<DebtTransaction> GetBySupplier(int supplierID)
        {
            return dao.GetBySupplier(supplierID);
        }

        public bool AddPayment(DebtTransaction trans, out string error)
        {
            if (trans.Amount <= 0)
            {
                error = "Số tiền thanh toán nợ phải lớn hơn 0!";
                return false;
            }
            return dao.AddTransaction(trans, out error);
        }
    }
}
