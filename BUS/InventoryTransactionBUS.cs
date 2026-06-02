using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class InventoryTransactionBUS
    {
        private InventoryTransactionDAO dao = new InventoryTransactionDAO();

        public List<InventoryTransaction> GetAllTransactions()
        {
            return dao.GetAll();
        }
    }
}
