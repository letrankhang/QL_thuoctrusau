using System;

namespace QL_CuaHangBanThuocTruSau.BUS {
    public class LogoutBUS {
        public bool PerformLogoutBusiness () {
            try
            {
                // Giả sử sau này bạn muốn ghi log vào Database khi user logout
                // LogDAO.Write("User logged out");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
