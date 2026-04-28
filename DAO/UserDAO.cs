using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace QL_CuaHangBanThuocTruSau.DAO {
    public class UserDAO {
        public UserDAO () { }

        //lấy toàn bộ thông tin người dùng
        public List<User> GetAllUsers () {
            using (var context = new AppDbContext())
            {
                try
                {
                    return context.Users.AsNoTracking().ToList ();
                }
                catch( Exception ex )
                {
                    Console.WriteLine ("Lỗi khi lấy danh sách user: " + ex.Message);
                    return new List<User> ();
                }
            }
        }

        /// Lấy thông tin chi tiết một người dùng theo ID
        public User GetUserById (int userId) {
            using (var context = new AppDbContext())
            {
                try
                {
                    return context.Users.AsNoTracking().FirstOrDefault (u => u.UserID == userId);
                }
                catch
                {
                    return null;
                }
            }
        }

        //kiểm tra người dùng có tồn tại ko
        public bool IsUsernameExists (string username) {
            using (var context = new AppDbContext())
            {
                return context.Users.Any (u => u.Username == username);
            }
        }

        public User GetUserByUsername (string username) {
            using (var context = new AppDbContext())
            {
                try
                {
                    return context.Users.AsNoTracking().FirstOrDefault (u => u.Username == username);
                }
                catch
                {
                    return null;
                }
            }
        }

        //thêm user mới trả về thành công hoặc ko thành công
        public bool AddUser (User user) {
            using (var context = new AppDbContext())
            {
                try
                {
                    if( user == null ) return false;
                    if( context.Users.Any (u => u.Username == user.Username) ) return false;

                    context.Users.Add (user);
                    context.SaveChanges ();
                    return true;
                }
                catch( Exception ex )
                {
                    Console.WriteLine ("Lỗi khi thêm user: " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Cập nhật thông tin người dùng đã tồn tại
        /// </summary>
        public bool UpdateUser (User user) {
            using (var context = new AppDbContext())
            {
                try
                {
                    if( user == null ) return false;

                    var existingUser = context.Users.FirstOrDefault (u => u.UserID == user.UserID);
                    if( existingUser != null )
                    {
                        existingUser.FullName = user.FullName;
                        existingUser.Role = user.Role;
                        existingUser.Status = user.Status;

                        if( !string.IsNullOrEmpty (user.Password) )
                        {
                            existingUser.Password = user.Password;
                        }

                        context.SaveChanges ();
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
        }

        /// <summary>
        /// Xóa mềm người dùng (Chuyển trạng thái Status sang false)
        /// </summary>
        public bool DeleteUser (int userId) {
            using (var context = new AppDbContext())
            {
                try
                {
                    var existingUser = context.Users.FirstOrDefault (u => u.UserID == userId);
                    if( existingUser == null ) return false;

                    existingUser.Status = false;
                    context.SaveChanges ();
                    return true;
                }
                catch( Exception ex )
                {
                    Console.WriteLine ("Lỗi khi xóa mềm user: " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Xóa vĩnh viễn người dùng khỏi database
        /// </summary>
        public bool HardDeleteUser (int userId) {
            using (var context = new AppDbContext())
            {
                try
                {
                    var user = context.Users.FirstOrDefault (u => u.UserID == userId);
                    if( user == null ) return false;

                    bool hasOrders = context.Orders.Any (o => o.UserID == userId);
                    bool hasImports = context.Imports.Any (i => i.UserID == userId);

                    if( hasOrders || hasImports )
                    {
                        return false;
                    }

                    context.Users.Remove (user);
                    context.SaveChanges ();
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
}
