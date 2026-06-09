using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Utils;

namespace QL_CuaHangBanThuocTruSau.Controllers 
{
    public class LogoutController 
    {
        private LogoutBUS _logoutBUS;

        public LogoutController () 
        {
            _logoutBUS = new LogoutBUS();
        }

        public bool HandleLogout () 
        {
            bool businessResult = _logoutBUS.PerformLogoutBusiness ();

            if (businessResult)
            {
                // xóa session ứng dụng
                SessionManager.ClearSession ();
                return true;
            }

            return false;
        }
    }
}
