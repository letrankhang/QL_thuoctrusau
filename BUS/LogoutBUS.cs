using System;

namespace QL_CuaHangBanThuocTruSau.BUS {
    public class LogoutBUS {
        /// <summary>
        /// Thực hiện các nghiệp vụ khi đăng xuất (ghi log, cập nhật trạng thái online...)
        /// </summary>
        /// <returns></returns>
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
