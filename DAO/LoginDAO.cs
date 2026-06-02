using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO 
{
    public class LoginDAO 
    {
        private AppDbContext db = new AppDbContext();

        public User GetUserByCredentials (string username, string password) 
        {
            try
            {
                // sẽ truy vấn người dùng từ database (So sánh trực tiếp Password)
                return db.Users.FirstOrDefault (u =>
                    u.Username == username &&
                    u.Password == password);
            }
            catch( Exception ex )
            {
                Console.WriteLine("Lỗi đăng nhập: " + ex.Message);
                return null;
            }
        }
    }
}