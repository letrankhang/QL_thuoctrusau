using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class ImportBUS
    {
        private ImportDAO dao = new ImportDAO();

        public bool CreateImport(Import import, List<Batch> batches, out string error)
        {
            if (import.SupplierID == 0)
            {
                error = "Vui lòng chọn nhà cung cấp!";
                return false;
            }
            if (batches == null || batches.Count == 0)
            {
                error = "Đơn nhập hàng phải có ít nhất một sản phẩm!";
                return false;
            }
            return dao.SaveImport(import, batches, out error);
        }

        public List<Import> GetAll()
        {
            return dao.GetAll();
        }
    }
}
