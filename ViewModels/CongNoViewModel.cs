using System;

namespace QL_CuaHangBanThuocTruSau.ViewModels
{
    public class CongNoViewModel
    {
        public int? OrderID { get; set; }
        public string PartnerName { get; set; }
        public string LoaiNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingDebt { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Status { get; set; }
        public string StaffName { get; set; }
    }
}
