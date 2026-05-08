using QL_CuaHangBanThuocTruSau.Models;

namespace QL_CuaHangBanThuocTruSau.Utils
{
    public static class SessionManager
    {
        // Lưu trữ thông tin người dùng hiện tại
        public static User CurrentUser { get; private set; }

        // Kiểm tra xem đã đăng nhập chưa
        public static bool IsLoggedIn
        {
            get { return CurrentUser != null; }
        }

        // Thiết lập session khi đăng nhập thành công
        public static void SetSession(User user)
        {
            CurrentUser = user;
        }

        // Xóa session khi đăng xuất
        public static void ClearSession()
        {
            CurrentUser = null;
        }

        // Ví dụ một hàm kiểm tra quyền Admin
        public static bool IsAdmin()
        {
            return IsLoggedIn && string.Equals(CurrentUser.Role, "ADMIN", System.StringComparison.OrdinalIgnoreCase);
        }

        // Kiểm tra quyền theo tên Role bất kỳ
        public static bool HasRole(string roleName)
        {
            return IsLoggedIn && CurrentUser.Role == roleName;
        }
    }
}