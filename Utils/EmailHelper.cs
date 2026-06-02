using System;
using System.Net;
using System.Net.Mail;

namespace QL_CuaHangBanThuocTruSau.Utils 
{
    public static class EmailHelper 
    {
        private const string Host = "smtp.gmail.com";
        private const int Port = 587;
        private const string FromEmail = "ttrankhang2405@gmail.com"; // Thay bằng email
        private const string AppPassword = "ozwm cird dacd xtgo"; // Thay bằng mật khẩu ứng dụng 

        public static bool SendVerificationCode (string toEmail, string code) 
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(FromEmail, "Hệ Thống Quản Lý Cửa Hàng");
                mail.To.Add (toEmail);
                mail.Subject = "Mã xác thực đặt lại mật khẩu - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                mail.Body = $@"
                    <div style='font-family: Arial, sans-serif; padding: 20px; border: 1px solid #ddd; border-radius: 10px; max-width: 500px;'>
                        <h2 style='color: #2c3e50; text-align: center;'>Xác Thực Tài Khoản</h2>
                        <p>Chào bạn,</p>
                        <p>Bạn vừa yêu cầu đặt lại mật khẩu cho tài khoản tại <b>Cửa hàng thuốc trừ sâu</b>.</p>
                        <div style='background-color: #f8f9fa; padding: 15px; text-align: center; border-radius: 5px; margin: 20px 0;'>
                            <span style='font-size: 32px; font-weight: bold; color: #e74c3c; letter-spacing: 5px;'>{code}</span>
                        </div>
                        <p style='color: #7f8c8d; font-size: 13px;'>Mã xác thực này có hiệu lực trong vòng 5 phút. Nếu bạn không thực hiện yêu cầu này, vui lòng bỏ qua email này.</p>
                        <hr style='border: 0; border-top: 1px solid #eee; margin: 20px 0;'/>
                        <p style='font-size: 12px; color: #bdc3c7; text-align: center;'>© {DateTime.Now.Year} QL Cửa Hàng Thuốc Trừ Sâu. All rights reserved.</p>
                    </div>";
                mail.IsBodyHtml = true;

                using (var smtp = new SmtpClient(Host, Port))
                {
                    smtp.Credentials = new NetworkCredential(FromEmail, AppPassword);
                    smtp.EnableSsl = true;
                    smtp.Send (mail);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine ("Lỗi gửi Email: " + ex.Message);
                return false;
            }
        }
    }
}
