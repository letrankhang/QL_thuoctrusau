using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_LichSuKho : Form
    {
        private InventoryTransactionBUS _bus = new InventoryTransactionBUS();
        private List<InventoryTransaction> _allTransactions = new List<InventoryTransaction>();

        public Frm_LichSuKho()
        {
            InitializeComponent();
        }

        private void Frm_LichSuKho_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpDenNgay.Value = DateTime.Now;

            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "d/M/yyyy";

            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "d/M/yyyy";
            LoadFullData();
        }

        private void LoadFullData()
        {
            try
            {
                _allTransactions = _bus.GetAllTransactions();
                BindData(_allTransactions);
                DinhDangLuoi();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Frm_LichSuKho.LoadFullData");
                MessageBox.Show("Lỗi khi tải lịch sử kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindData(List<InventoryTransaction> transactions)
        {
            var displayList = transactions.Select(t => new
            {
                t.TransactionID,
                ProductName = t.Batch?.ProductVariant?.Product?.Name ?? "N/A",
                BatchNumber = t.BatchID,
                t.Quantity,
                Type = TranslateType(t.TransactionType),
                t.CreatedAt,
                t.ReferenceID
            }).ToList();

            dgvLichSu.DataSource = displayList;
        }

        private string TranslateType(string type)
        {
            switch (type?.ToUpper())
            {
                case "IMPORT": return "Nhập hàng";
                case "SALE": 
                case "SELL": return "Bán hàng";
                case "RETURN": return "Khách trả hàng";
                case "ADJUST": return "Điều chỉnh";
                default: return type ?? "Khác";
            }
        }

        private void DinhDangLuoi()
        {
            if (dgvLichSu.Columns.Count > 0)
            {
                if (dgvLichSu.Columns.Contains("TransactionID")) dgvLichSu.Columns["TransactionID"].HeaderText = "Mã GD";
                if (dgvLichSu.Columns.Contains("ProductName")) dgvLichSu.Columns["ProductName"].HeaderText = "Sản Phẩm";
                if (dgvLichSu.Columns.Contains("BatchNumber")) dgvLichSu.Columns["BatchNumber"].HeaderText = "Mã Lô";
                if (dgvLichSu.Columns.Contains("Quantity")) dgvLichSu.Columns["Quantity"].HeaderText = "Số Lượng";
                if (dgvLichSu.Columns.Contains("Type")) dgvLichSu.Columns["Type"].HeaderText = "Loại GD";
                if (dgvLichSu.Columns.Contains("CreatedAt")) dgvLichSu.Columns["CreatedAt"].HeaderText = "Thời Gian";
                if (dgvLichSu.Columns.Contains("ReferenceID")) dgvLichSu.Columns["ReferenceID"].HeaderText = "Mã Ref";

                if (dgvLichSu.Columns.Contains("CreatedAt"))
                    dgvLichSu.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                
                if (dgvLichSu.Columns.Contains("Quantity"))
                    dgvLichSu.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (dgvLichSu.Columns.Contains("CreatedAt"))
                    dgvLichSu.Columns["CreatedAt"].Width = 140;
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;
                DateTime denNgayCuoi = denNgay.Date.AddDays(1).AddSeconds(-1);

                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var filtered = _allTransactions.Where(t => t.CreatedAt >= tuNgay && t.CreatedAt <= denNgayCuoi).ToList();

                BindData(filtered);
                DinhDangLuoi();

                if (filtered.Count == 0)
                    MessageBox.Show("Không có giao dịch nào trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "btnLoc_Click");
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadFullData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                BindData(_allTransactions);
                DinhDangLuoi();
                return;
            }

            var filtered = _allTransactions.Where(t =>
                (t.Batch?.ProductVariant?.Product?.Name != null &&
                 t.Batch.ProductVariant.Product.Name.ToLower().Contains(keyword)) ||
                t.BatchID.ToString().Contains(keyword)
            ).ToList();

            BindData(filtered);
            DinhDangLuoi();
        }
    }
}
