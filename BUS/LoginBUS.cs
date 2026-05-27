using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System;

namespace QL_CuaHangBanThuocTruSau.BUS {
    public class LoginBUS {
        private readonly LoginDAO _loginDAO;

        public LoginBUS () {
            _loginDAO = new LoginDAO ();
        }

        public string Authenticate (string username, string password) 
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return "EMPTY";

            User user = _loginDAO.GetUserByCredentials(username, password);

            if (user == null)
                return "INVALID";

            if (!user.Status)
                return "LOCKED";

            return "SUCCESS";
        }
    }
}
