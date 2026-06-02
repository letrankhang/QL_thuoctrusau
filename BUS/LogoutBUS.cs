using System;

namespace QL_CuaHangBanThuocTruSau.BUS 
{
    public class LogoutBUS 
    {
        public bool PerformLogoutBusiness () 
        {
            try
            {
                // TODO: Sau này nếu cần, có thể ghi log vào database
                // Ví dụ là: LogDAO.Write("User logged out");
                // Hiện tại chưa có nghiệp vụ thực sự, luôn trả về true
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
