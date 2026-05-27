using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Utils;

namespace QL_CuaHangBanThuocTruSau.Controllers {
    public class LogoutController {
        private readonly LogoutBUS _logoutBUS;

        public LogoutController () {
            _logoutBUS = new LogoutBUS ();
        }

        public bool HandleLogout () {
            // Gọi BUS nếu cần xử lý nghiệp vụ (ví dụ: ghi log thời gian thoát)
            bool businessResult = _logoutBUS.PerformLogoutBusiness ();

            if( businessResult )
            {
                // Xóa Session ứng dụng
                SessionManager.ClearSession ();
                return true;
            }

            return false;
        }
    }
}
