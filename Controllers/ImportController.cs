using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.Controllers
{
    public class ImportController
    {
        private ImportBUS bus = new ImportBUS();

        public bool CreateImport(Import import, List<Batch> batches, out string error)
        {
            return bus.CreateImport(import, batches, out error);
        }

        public List<Import> GetAll()
        {
            return bus.GetAll();
        }
    }
}