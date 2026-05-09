using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_LichSuKho : Form
    {
        private readonly InventoryTransactionBUS _bus = new InventoryTransactionBUS();
        private List<InventoryTransaction> _allTransactions = new List<InventoryTransaction>();
        private const string PlaceholderText = "Tìm kiếm theo tên sản phẩm hoặc mã lô...";

        public Frm_LichSuKho()
        {
            InitializeComponent();
            SetupPlaceholder();
        }

        private void SetupPlaceholder()
        {
            txtTimKiem.Text = PlaceholderText;
            txtTimKiem.ForeColor = System.Drawing.Color.Gray;

            txtTimKiem.Enter += (s, e) =>
            {
                if (txtTimKiem.Text == PlaceholderText)
                {
                    txtTimKiem.Text = "";
                    txtTimKiem.ForeColor = System.Drawing.Color.Black;
                }
            };

            txtTimKiem.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    txtTimKiem.Text = PlaceholderText;
                    txtTimKiem.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        private void Frm_LichSuKho_Load(object sender, EventArgs e)
        {
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

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

            var filtered = _allTransactions.Where(t => t.CreatedAt >= tuNgay && t.CreatedAt <= denNgay).ToList();
            BindData(filtered);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == PlaceholderText || string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                if (_allTransactions.Count > 0 && dgvLichSu.Rows.Count != _allTransactions.Count)
                {
                    BindData(_allTransactions);
                }
                return;
            }

            string searchText = txtTimKiem.Text.ToLower();
            var filtered = _allTransactions.Where(t => 
                (t.Batch?.ProductVariant?.Product?.Name != null && t.Batch.ProductVariant.Product.Name.ToLower().Contains(searchText)) ||
                t.BatchID.ToString().Contains(searchText)
            ).ToList();

            BindData(filtered);
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
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadFullData();
            txtTimKiem.Text = PlaceholderText;
            txtTimKiem.ForeColor = System.Drawing.Color.Gray;
        }
    }
}
