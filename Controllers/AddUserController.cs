using QL_CuaHangBanThuocTruSau.BUS;

namespace QL_CuaHangBanThuocTruSau.Controllers 
{
    public class AddUserController 
    {
        private UserBUS _userBUS;

        public AddUserController () 
        {
            _userBUS = new UserBUS ();
        }

        public string HandleAddUser (string username, string password, string fullName, string email, string role) 
        {
            if ( string.IsNullOrWhiteSpace (username) )
                return "Tên đăng nhập không được để trống!";
            
            if ( string.IsNullOrWhiteSpace (password) )
                return "Mật khẩu không được để trống!";

            if ( password.Length < 6 )
                return "Mật khẩu phải có ít nhất 6 ký tự!";

            if ( !string.IsNullOrWhiteSpace (email) && !email.Contains ("@") )
                return "Email không hợp lệ!";

            // Gọi BUS thực hiện nghiệp vụ
            bool isSuccess = _userBUS.AddNewUser (username, password, fullName, email, role);


            if( isSuccess )
            {
                return "SUCCESS";
            }
            
            return "Thêm người dùng thất bại! Có thể tên đăng nhập đã tồn tại hoặc có lỗi hệ thống.";
        }
    }
}
