using QL_CuaHangBanThuocTruSau.BUS;
using System;

namespace QL_CuaHangBanThuocTruSau.Controllers {
    public class AddUserController {
        private readonly UserBUS _userBUS;

        public AddUserController () {
            _userBUS = new UserBUS ();
        }

        /// <summary>
        /// Xử lý thêm người dùng mới từ View
        /// </summary>
        /// <returns>Thông báo kết quả</returns>
        public string HandleAddUser (string username, string password, string fullName, string email, string role) {
            // 1. Kiểm tra ràng buộc dữ liệu cơ bản ở mức Controller
            if( string.IsNullOrWhiteSpace (username) )
                return "Tên đăng nhập không được để trống!";
            
            if( string.IsNullOrWhiteSpace (password) )
                return "Mật khẩu không được để trống!";

            if( password.Length < 6 )
                return "Mật khẩu phải có ít nhất 6 ký tự!";

            if( !string.IsNullOrWhiteSpace (email) && !email.Contains ("@") )
                return "Email không hợp lệ!";

            // 2. Gọi BUS để thực hiện nghiệp vụ
            bool isSuccess = _userBUS.AddNewUser (username, password, fullName, email, role);


            if( isSuccess )
            {
                return "SUCCESS";
            }
            
            return "Thêm người dùng thất bại! Có thể tên đăng nhập đã tồn tại hoặc có lỗi hệ thống.";
        }
    }
}
