using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.DAO {
    public class LoginDAO {
        private readonly AppDbContext _context;

        public LoginDAO () {
            _context = new AppDbContext ();
        }
        public User GetUserByCredentials (string username, string password) {
            try
            {
                // Truy vấn người dùng từ database (So sánh trực tiếp Password)
                return _context.Users.FirstOrDefault (u =>
                    u.Username == username &&
                    u.Password == password &&
                    u.Status == true);
            }
            catch( Exception )
            {

                return null;
            }
        }
    }
}