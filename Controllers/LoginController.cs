using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;

namespace QL_CuaHangBanThuocTruSau.Controllers {
    public class LoginController {
        private readonly LoginBUS _loginBUS;
        private readonly LoginDAO _loginDAO;
        public LoginController () {
            _loginBUS = new LoginBUS ();
            _loginDAO = new LoginDAO();
        }

        /// <summary>
        /// Xử lý logic đăng nhập từ View
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Chuỗi thông báo kết quả (SUCCESS nếu thành công)</returns>
        public string HandleLogin (string username, string password) 
        {
            if (string.IsNullOrWhiteSpace(username))
                return "Vui lòng nhập tên đăng nhập!";

            if (string.IsNullOrWhiteSpace(password))
                return "Vui lòng nhập mật khẩu!";

            string result = _loginBUS.Authenticate(username, password);

            if (result == "SUCCESS")
            {
                User user = _loginDAO.GetUserByCredentials(username, password);
                SessionManager.SetSession(user);
                return "SUCCESS";
            }
            else if (result == "LOCKED")
                return "Tài khoản của bạn đã bị khóa. Vui lòng liên hệ quản trị viên!";

            else if (result == "INVALID")
                return "Tên đăng nhập hoặc mật khẩu không chính xác!";

            else
                return "Đã có lỗi xảy ra, vui lòng thử lại!";
        }
    }
}
