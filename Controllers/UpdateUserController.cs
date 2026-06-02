using QL_CuaHangBanThuocTruSau.BUS;

namespace QL_CuaHangBanThuocTruSau.Controllers 
{
    public class UpdateUserController 
    {
        private UserBUS _userBUS;

        public UpdateUserController () 
        {
            _userBUS = new UserBUS ();
        }

        public string HandleUpdateUser (int userId, string password, string fullName, string email, string role, bool status) 
        {
            if (string.IsNullOrWhiteSpace (fullName))
                return "Họ và tên không được để trống!";

            if (!string.IsNullOrWhiteSpace (email) && !email.Contains ("@"))
                return "Email không hợp lệ!";

            if (!string.IsNullOrEmpty (password) && password.Length < 6)
                return "Mật khẩu mới phải có ít nhất 6 ký tự!";

            bool result = _userBUS.UpdateUserInfo (userId, password, fullName, email, role, status);

            if (result)
            {
                return "SUCCESS";
            }
            return "Cập nhật thông tin thất bại!";
        }
    }
}
