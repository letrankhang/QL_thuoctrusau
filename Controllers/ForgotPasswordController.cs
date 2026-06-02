using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Utils;
using System;

namespace QL_CuaHangBanThuocTruSau.Controllers 
{
    public class ForgotPasswordController 
    {
        private UserBUS _userBUS;
        private string _verificationCode;
        private int _currentUserId;
        private string _userEmail;

        public ForgotPasswordController () 
        {
            _userBUS = new UserBUS ();
        }

        public string IdentifyUser (string identifier) 
        {
            if( string.IsNullOrWhiteSpace (identifier) )
                return "Vui lòng nhập Email hoặc Tên tài khoản!";

            var user = _userBUS.GetUserByEmailOrUsername (identifier);
            if( user == null )
                return "Không tìm thấy tài khoản trong hệ thống!";

            if( string.IsNullOrEmpty (user.Email) )
                return "Tài khoản này chưa cập nhật Email, vui lòng liên hệ Admin!";

            _currentUserId = user.UserID;
            _userEmail = user.Email;

            Random rand = new Random ();
            _verificationCode = rand.Next (100000, 999999).ToString ();
            
            // Gửi mã qua Email thực tế
            bool isSent = EmailHelper.SendVerificationCode(_userEmail, _verificationCode);
            
            if (isSent)
                return "SUCCESS";

            else
                return "Không thể gửi email xác thực. Vui lòng kiểm tra lại kết nối internet hoặc cấu hình SMTP!";
        }

        public string GetMaskedEmail() 
        {
            if (string.IsNullOrEmpty(_userEmail)) 
                return "";

            var parts = _userEmail.Split('@');
            if (parts.Length != 2) 
                return _userEmail;

            string name = parts[0];
            if (name.Length <= 3) 
                return "***@" + parts[1];

            return name.Substring(0, 3) + "****@" + parts[1];
        }

        public string GetSimulatedCode() => _verificationCode;

        public bool VerifyCode (string inputCode) 
        {
            return inputCode == _verificationCode;
        }

        public string ResetPassword (string newPassword, string confirmPassword) 
        {
            if( string.IsNullOrWhiteSpace (newPassword) )
                return "Mật khẩu mới không được để trống!";

            if( newPassword.Length < 6 )
                return "Mật khẩu phải có ít nhất 6 ký tự!";

            if( newPassword != confirmPassword )
                return "Mật khẩu xác nhận không khớp!";

            if( _userBUS.ResetPassword (_currentUserId, newPassword) )
                return "SUCCESS";

            return "Có lỗi xảy ra khi đặt lại mật khẩu!";
        }
    }
}
