using QL_CuaHangBanThuocTruSau.BUS;
using System;

namespace QL_CuaHangBanThuocTruSau.Controllers {
    public class UpdateUserController {
        private readonly UserBUS _userBUS;

        public UpdateUserController () {
            _userBUS = new UserBUS ();
        }

        /// <summary>
        /// Xử lý cập nhật thông tin người dùng
        /// </summary>
        public string HandleUpdateUser (int userId, string password, string fullName, string email, string role, bool status) {
            // 1. Validation
            if( string.IsNullOrWhiteSpace (fullName) )
                return "Họ tên không được để trống!";

            if( !string.IsNullOrWhiteSpace (email) && !email.Contains ("@") )
                return "Email không hợp lệ!";

            // Mật khẩu có thể để trống nếu không muốn đổi, nhưng nếu nhập thì phải >= 6 ký tự
            if( !string.IsNullOrEmpty (password) && password.Length < 6 )
                return "Mật khẩu mới phải có ít nhất 6 ký tự!";

            // 2. Gọi BUS
            bool result = _userBUS.UpdateUserInfo (userId, password, fullName, email, role, status);


            if( result )
            {
                return "SUCCESS";
            }

            return "Cập nhật thông tin thất bại!";
        }
    }
}
