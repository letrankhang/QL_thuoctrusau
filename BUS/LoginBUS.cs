using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System;

namespace QL_CuaHangBanThuocTruSau.BUS {
    public class LoginBUS {
        private readonly LoginDAO _loginDAO;

        public LoginBUS () {
            _loginDAO = new LoginDAO ();
        }

        /// <summary>
        /// Nghiệp vụ xác thực người dùng
        /// </summary>
        public User Authenticate (string username, string password) {
            if( string.IsNullOrEmpty (username) || string.IsNullOrEmpty (password) )
            {
                return null;
            }

            // Gọi DAO để truy vấn database
            return _loginDAO.GetUserByCredentials (username, password);
        }
    }
}
