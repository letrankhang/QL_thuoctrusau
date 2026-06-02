using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.Controllers
{
    public class SuppliersController
    {
        private SuppliersBUS nhaCungCapBus = new SuppliersBUS();

        public List<Supplier> LayDanhSach()
        {
            return nhaCungCapBus.layDanhSach();
        }

        public List<Supplier> TimKiem(string tuKhoa)
        {
            return nhaCungCapBus.timKiem(tuKhoa);
        }

        public bool Them(Supplier nhaCungCap, out string loi)
        {
            loi = "";
            if (!KiemTraHopLe(nhaCungCap, laThemMoi: true, out loi))
            {
                return false;
            }

            return nhaCungCapBus.them(nhaCungCap, out loi);
        }

        public bool Sua(Supplier nhaCungCap, out string loi)
        {
            loi = "";
            if (!KiemTraHopLe(nhaCungCap, laThemMoi: false, out loi))
            {
                return false;
            }

            return nhaCungCapBus.sua(nhaCungCap, out loi);
        }

        public bool Xoa(int maNhaCungCap, out string loi)
        {
            loi = "";
            if (maNhaCungCap <= 0)
            {
                loi = "Mã nhà cung cấp không hợp lệ!";
                return false;
            }
            return nhaCungCapBus.xoa(maNhaCungCap, out loi);
        }

        private bool KiemTraHopLe(Supplier nhaCungCap, bool laThemMoi, out string loi)
        {
            loi = "";
            if (string.IsNullOrWhiteSpace(nhaCungCap.Name))
            {
                loi = "Tên nhà cung cấp không được để trống!";
                return false;
            }
            if (nhaCungCap.Name.Length > 100)
            {
                loi = "Tên nhà cung cấp không được vượt quá 100 ký tự!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nhaCungCap.Phone))
            {
                loi = "Số điện thoại không được để trống!";
                return false;
            }
            if (nhaCungCap.Phone.Length < 10 || nhaCungCap.Phone.Length > 11)
            {
                loi = "Số điện thoại phải từ 10 đến 11 chữ số!";
                return false;
            }

            for (int i = 0; i < nhaCungCap.Phone.Length; i++)
            {
                if (!char.IsDigit(nhaCungCap.Phone[i]))
                {
                    loi = "Số điện thoại chỉ được chứa chữ số!";
                    return false;
                }
            }

            int boQuaID = 0;
            if (!laThemMoi)
            {
                boQuaID = nhaCungCap.SupplierID;
            }
            if (nhaCungCapBus.kiemTraSoDienThoaiTonTai(nhaCungCap.Phone, boQuaID))
            {
                loi = "Số điện thoại " + nhaCungCap.Phone + " đã tồn tại!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nhaCungCap.Address))
            {
                loi = "Địa chỉ không được để trống!";
                return false;
            }
            if (nhaCungCap.Address.Length > 200)
            {
                loi = "Địa chỉ không được vượt quá 200 ký tự!";
                return false;
            }
            return true;
        }
    }
}