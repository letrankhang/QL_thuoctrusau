using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.ViewModels;
using System;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class BatchBUS
    {
        BatchDAO dao = new BatchDAO();

        private string tinhTrangThai(DateTime? hanSuDung)
        {
            if (hanSuDung == null)
                return "Không xác định";

            if (hanSuDung.Value < DateTime.Today)
                return "Hết hạn";

            if (hanSuDung.Value < DateTime.Today.AddDays(30))
                return "Sắp hết hạn";

            return "Còn hạn";
        }

        private List<BatchViewModel> applyTrangThai(List<BatchViewModel> danhSach)
        {
            for (int i = 0; i < danhSach.Count; i++)
            {
                danhSach[i].TrangThai = tinhTrangThai(danhSach[i].HanSuDung);
            }
            return danhSach;
        }

        public List<BatchViewModel> layDanhSach()
        {
            return applyTrangThai(dao.layDanhSach());
        }

        public List<BatchViewModel> timKiem(string keyword)
        {
            return applyTrangThai(dao.timKiem(keyword));
        }

        public List<BatchViewModel> layDanhSachTheoFilter(int productID, int supplierID, string trangThai)
        {
            var danhSach = applyTrangThai(dao.layDanhSachTheoFilter(productID, supplierID));

            if (trangThai == "Tất cả")
                return danhSach;

            var ketQua = new List<BatchViewModel>();
            for (int i = 0; i < danhSach.Count; i++)
            {
                if (danhSach[i].TrangThai == trangThai)
                    ketQua.Add(danhSach[i]);
            }
            return ketQua;
        }
    }
}