using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;

namespace QL_CuaHangBanThuocTruSau.Controllers {
    public class LoginController {
        private readonly LoginBUS _loginBUS;

        public LoginController () {
            _loginBUS = new LoginBUS ();
        }

        /// <summary>
        /// Xử lý logic đăng nhập từ View
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Chuỗi thông báo kết quả (SUCCESS nếu thành công)</returns>
        public string HandleLogin (string username, string password) {
            // 1. Kiểm tra sơ bộ (Validation UI)
            if( string.IsNullOrEmpty (username) || string.IsNullOrEmpty (password) )
            {
                return "Tên đăng nhập và mật khẩu không được để trống!";
            }

            // 2. Gọi BUS để thực hiện nghiệp vụ xác thực
            User user = _loginBUS.Authenticate (username, password);

            if( user != null )
            {
                // 3. Xử lý trạng thái ứng dụng sau khi nghiệp vụ thành công
                SessionManager.SetSession (user);
                return "SUCCESS";
            }

            return "Tên đăng nhập hoặc mật khẩu không chính xác!";
        }
    }
}
