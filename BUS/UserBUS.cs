using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;
using System;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS {
    public class UserBUS {
        private readonly UserDAO _userDAO;

        public UserBUS () {
            _userDAO = new UserDAO ();
        }

        //thêm user mới
        public bool AddNewUser (string username, string password, string fullName, string email, string role) {
            if( string.IsNullOrEmpty (username) || string.IsNullOrEmpty (password) )
            {
                Console.WriteLine ("Tên đăng nhập và mật khẩu không được để trống!");
                return false;
            }

            if( _userDAO.IsUsernameExists (username) )
            {
                Console.WriteLine ("Tên đăng nhập đã tồn tại!");
                return false;
            }

            User newUser = new User
            {
                Username = username,
                Password = password,
                FullName = fullName,
                Email = email,
                Role = role,
                Status = true,
                CreatedAt = DateTime.Now
            };

            if( _userDAO.AddUser (newUser) )
            {
                Console.WriteLine ("Thêm thành công user " + username);
                return true;
            }
            else
            {
                Console.WriteLine ("Thêm thất bại user " + username);
                return false;
            }
        }

        // lấy danh sách user
        public List<User> GetAllUsers () {
            return _userDAO.GetAllUsers ();
        }

        // lấy thông tin user theo ID
        public User GetUserById (int userId) {
            return _userDAO.GetUserById (userId);
        }

        public User GetUserByUsername (string username) {
            return _userDAO.GetUserByUsername (username);
        }

        public User GetUserByEmailOrUsername (string identifier) {
            return _userDAO.GetUserByEmailOrUsername (identifier);
        }

        public bool ResetPassword (int userId, string newPassword) {
            if( string.IsNullOrWhiteSpace (newPassword) || newPassword.Length < 6 )
                return false;
            return _userDAO.UpdatePassword (userId, newPassword);
        }

        //cập nhật thông tin user
        public bool UpdateUserInfo (int userId, string password, string fullName, string email, string role, bool status) {
            User user = new User
            {
                UserID = userId,
                Password = password,
                FullName = fullName,
                Email = email,
                Role = role,
                Status = status
            };

            if( _userDAO.UpdateUser (user) )
            {
                Console.WriteLine ("Cập nhật thành công user ID: " + userId);
                return true;
            }
            else
            {
                Console.WriteLine ("Cập nhật thất bại user ID: " + userId);
                return false;
            }
        }

        //xóa mềm user (đổi trạng thái)
        public bool DeleteUser (int userId) {
            // Kiểm tra không cho phép tự xóa chính mình
            if( SessionManager.IsLoggedIn && SessionManager.CurrentUser.UserID == userId )
            {
                Console.WriteLine ("Bạn không thể tự vô hiệu hóa tài khoản của chính mình!");
                return false;
            }

            if( _userDAO.DeleteUser (userId) )
            {
                Console.WriteLine ("Đã vô hiệu hóa user ID: " + userId);
                return true;
            }
            return false;
        }

        //xóa vĩnh viễn user
        public bool HardDeleteUser (int userId) {
            // Kiểm tra không cho phép tự xóa chính mình
            if( SessionManager.IsLoggedIn && SessionManager.CurrentUser.UserID == userId )
            {
                Console.WriteLine ("Bạn không thể tự xóa tài khoản của chính mình!");
                return false;
            }

            if( _userDAO.HardDeleteUser (userId) )
            {
                Console.WriteLine ("Đã xóa vĩnh viễn user ID: " + userId);
                return true;
            }
            return false;
        }
    }
}
