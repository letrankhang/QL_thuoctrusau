using System;

namespace QL_CuaHangBanThuocTruSau.ViewModels
{
    public class BatchViewModel
    {
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public int BatchID { get; set; }
        public string TenSanPham { get; set; }
        public string BienThe { get; set; }        // cột này sẽ kết hợp Unit (đơn vị) và Concentration (hàm lượng) cho gọn
        public string NhaCungCap { get; set; }
        public decimal GiaNhap { get; set; }
        public int SoLuongBanDau { get; set; }
        public int SoLuongConLai { get; set; }
        public DateTime? NgaySanXuat { get; set; }
        public DateTime? HanSuDung { get; set; }
        public string TrangThai { get; set; }
    }
}
