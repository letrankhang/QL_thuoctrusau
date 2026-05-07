using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO {
    public class LoginDAO {
        public LoginDAO () { }

        public User GetUserByCredentials (string username, string password) {
            using (var context = new AppDbContext())
            {
                try
                {
                    // Truy vấn người dùng từ database (So sánh trực tiếp Password)
                    return context.Users.FirstOrDefault (u =>
                        u.Username == username &&
                        u.Password == password &&
                        u.Status == true);
                }
                catch( Exception ex )
                {
                    Console.WriteLine("Lỗi Database: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
