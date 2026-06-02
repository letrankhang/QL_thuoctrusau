using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO 
{
    public class UserDAO 
    {
        private AppDbContext db = new AppDbContext();

        public List<User> GetAllUsers() 
        {
            try
            {
                return db.Users.AsNoTracking().ToList ();
            }
            catch (Exception ex)
            {
                Console.WriteLine ("Lỗi khi lấy danh sách user: " + ex.Message);
                return new List<User> ();
            }
        }

        public User GetUserById (int userId) 
        {
            try
            {
                return db.Users.AsNoTracking().FirstOrDefault (u => u.UserID == userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return null;
            }
        }

        // kiểm tra người dùng có tồn tại ko
        public bool IsUsernameExists (string username) 
        {
            return db.Users.Any(u => u.Username == username);
        }

        public User GetUserByUsername (string username) 
        {
            try
            {
                return db.Users.AsNoTracking().FirstOrDefault (u => u.Username == username);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return null;
            }
        }

        public User GetUserByEmailOrUsername (string identifier) 
        {
            try
            {
                return db.Users.AsNoTracking().FirstOrDefault (u => u.Username == identifier || u.Email == identifier);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return null;
            }
        }

        public bool UpdatePassword (int userId, string newPassword) 
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.UserID == userId);
                if (user == null) return false;

                user.Password = newPassword;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // thêm user mới trả về thành công hoặc ko thành công
        public bool AddUser (User user) 
        {
            try
            {
                if (user == null) return false;
                if (db.Users.Any(u => u.Username == user.Username)) return false;

                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine ("Lỗi khi thêm user: " + ex.Message);
                return false;
            }
        }

        public bool UpdateUser (User user) 
        {
            try
            {
                if( user == null ) return false;

                var existingUser = db.Users.FirstOrDefault (u => u.UserID == user.UserID);
                if( existingUser != null )
                {
                    existingUser.FullName = user.FullName;
                    existingUser.Email = user.Email;

                    existingUser.Role = user.Role;
                    existingUser.Status = user.Status;

                    if( !string.IsNullOrEmpty (user.Password) )
                    {
                        existingUser.Password = user.Password;
                    }

                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine ("Lỗi khi sửa thông tin user: " + ex.Message);
                return false;
            }
        }

        public bool DeleteUser (int userId) 
        {
            try
            {
                var existingUser = db.Users.FirstOrDefault (u => u.UserID == userId);
                if (existingUser == null) return false;

                existingUser.Status = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine ("Lỗi khi xóa mềm user: " + ex.Message);
                return false;
            }
        }

        public bool HardDeleteUser (int userId) 
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.UserID == userId);
                if (user == null) return false;

                bool hasOrders = db.Orders.Any(o => o.UserID == userId);
                bool hasImports = db.Imports.Any(i => i.UserID == userId);

                if (hasOrders || hasImports)
                {
                    return false;
                }

                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine ("Lỗi khi xóa vĩnh viễn user: " + ex.Message);
                return false;
            }
        }
    }
}
