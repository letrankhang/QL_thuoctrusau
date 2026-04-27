using QL_CuaHangBanThuocTruSau.BUS;

namespace QL_CuaHangBanThuocTruSau.Controllers {
    public class DeleteUserController {
        private readonly UserBUS _userBUS;

        public DeleteUserController () {
            _userBUS = new UserBUS ();
        }

        /// <summary>
        /// Xử lý xóa mềm người dùng (Vô hiệu hóa)
        /// </summary>
        public string HandleSoftDelete (int userId) {
            bool result = _userBUS.DeleteUser (userId);
            if( result )
            {
                return "SUCCESS";
            }
            return "Vô hiệu hóa người dùng thất bại! Có thể bạn đang cố gắng vô hiệu hóa chính mình.";
        }

        /// <summary>
        /// Xóa vĩnh viễn người dùng
        /// </summary>
        public string HandleHardDelete (int userId) {
            bool result = _userBUS.HardDeleteUser (userId);
            if( result )
            {
                return "SUCCESS";
            }
            return "Xóa vĩnh viễn thất bại! User đã có giao dịch hoặc bạn đang xóa chính mình.";
        }
    }
}
