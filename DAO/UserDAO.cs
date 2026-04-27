using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO {
    public class UserDAO {
        private readonly AppDbContext _context;

        public UserDAO () {
            _context = new AppDbContext ();
        }

        //lấy toàn bộ thông tin người dùng
        public List<User> GetAllUsers () {
            try
            {
                return _context.Users.ToList ();
            }
            catch( Exception ex )
            {
                // ghi log ra màn hình 
                Console.WriteLine ("Lỗi khi lấy danh sách user: " + ex.Message);
                return new List<User> ();
            }
        }

        /// Lấy thông tin chi tiết một người dùng theo ID
        public User GetUserById (int userId) {
            try
            {
                return _context.Users.FirstOrDefault (u => u.UserID == userId);
            }
            catch
            {
                return null;
            }
        }

        //kiểm tra người dùng có tồn tại ko
        public bool IsUsernameExists (string username) {
            return _context.Users.Any (u => u.Username == username);
        }

        //thêm user mới trả về thành công hoặc ko thành công
        public bool AddUser (User user) {
            try
            {
                // Kiểm tra null
                if( user == null ) return false;

                // Kiểm tra trùng tên đăng nhập trước khi thêm
                if( IsUsernameExists (user.Username) )
                {
                    return false;
                }

                _context.Users.Add (user);
                _context.SaveChanges ();
                return true;
            }
            catch( Exception ex )
            {
                Console.WriteLine ("Lỗi khi thêm user: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin người dùng đã tồn tại
        /// </summary>
        public bool UpdateUser (User user) {
            try
            {
                if( user == null ) return false;

                var existingUser = _context.Users.FirstOrDefault (u => u.UserID == user.UserID);
                if( existingUser != null )
                {
                    existingUser.FullName = user.FullName;
                    existingUser.Role = user.Role;
                    existingUser.Status = user.Status;

                    // Chỉ cập nhật mật khẩu nếu nó được cung cấp (không trống)
                    if( !string.IsNullOrEmpty (user.Password) )
                    {
                        existingUser.Password = user.Password;
                    }

                    _context.SaveChanges ();
                    return true;
                }
                return false;
            }
            catch( Exception ex )
            {
                Console.WriteLine ("Lỗi khi sửa thông tin user: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Xóa mềm người dùng (Chuyển trạng thái Status sang false)
        /// </summary>
        public bool DeleteUser (int userId) {
            try
            {
                var existingUser = _context.Users.FirstOrDefault (u => u.UserID == userId);
                if( existingUser == null ) return false;

                existingUser.Status = false; // Vô hiệu hóa người dùng
                _context.SaveChanges ();
                return true;
            }
            catch( Exception ex )
            {
                Console.WriteLine ("Lỗi khi xóa mềm user: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Xóa vĩnh viễn người dùng khỏi database
        /// </summary>
        public bool HardDeleteUser (int userId) {
            try
            {
                var user = _context.Users.FirstOrDefault (u => u.UserID == userId);
                if( user == null ) return false;

                // Kiểm tra ràng buộc dữ liệu (nếu user đã có đơn hàng hoặc nhập hàng thì không được xóa vĩnh viễn)
                bool hasOrders = _context.Orders.Any (o => o.UserID == userId);
                bool hasImports = _context.Imports.Any (i => i.UserID == userId);

                if( hasOrders || hasImports )
                {
                    Console.WriteLine ("Không thể xóa vĩnh viễn user đã có lịch sử giao dịch. Hãy sử dụng xóa mềm.");
                    return false;
                }

                _context.Users.Remove (user);
                _context.SaveChanges ();
                return true;
            }
            catch( Exception ex )
            {
                Console.WriteLine ("Lỗi khi xóa vĩnh viễn user: " + ex.Message);
                return false;
            }
        }
    }
}