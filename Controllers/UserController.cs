using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.Controllers {
    public class UserController {
        private readonly UserBUS _userBUS;

        public UserController () {
            _userBUS = new UserBUS ();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách người dùng để hiển thị lên GridView
        /// </summary>
        public List<User> GetUserList () {
            return _userBUS.GetAllUsers ();
        }

        /// <summary>
        /// Lấy chi tiết thông tin một người dùng
        /// </summary>
        public User GetUserDetails (int userId) {
            return _userBUS.GetUserById (userId);
        }

        /// <summary>
        /// Tìm kiếm người dùng theo tên hoặc username
        /// </summary>
        public List<User> SearchUsers (string keyword) {
            var allUsers = _userBUS.GetAllUsers ();
            if( string.IsNullOrWhiteSpace (keyword) )
                return allUsers;

            keyword = keyword.ToLower ();
            return allUsers.Where (u => 
                u.Username.ToLower ().Contains (keyword) || 
                u.FullName.ToLower ().Contains (keyword)
            ).ToList ();
        }
    }
}
