using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Utils;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class BatchExportBUS
    {
        private BatchExportDAO _exportDAO = new BatchExportDAO();
        private BatchBUS _batchBUS = new BatchBUS(); 

        public void ExportBatches(string filePath, int productID = -1, int supplierID = -1, string trangThai = "Tất cả")
        {
            // Lấy dữ liệu thô từ DAO
            var allData = _exportDAO.GetFullBatchData();

            // Áp dụng logic lọc và tính trạng thái (Tận dụng code cũ để đảm bảo thống nhất)
            // Lưu ý: BatchBUS đã có method layDanhSachTheoFilter, ta có thể gọi trực tiếp nếu cần.
            // Ở đây tôi giả định bạn muốn xuất chính xác những gì theo Filter.
            var filteredData = _batchBUS.layDanhSachTheoFilter(productID, supplierID, trangThai);

            // Gọi Utils để thực hiện việc ghi file
            ExcelHelper.XuatExcelLoHang(filteredData, filePath);
        }
    }
}
