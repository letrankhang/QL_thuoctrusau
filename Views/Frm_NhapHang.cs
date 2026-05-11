using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views {
    public partial class Frm_NhapHang : Form {
        ImportController controller = new ImportController ();

        public Frm_NhapHang () {
            InitializeComponent ();
            this.Load += Frm_NhapHang_Load;
        }

        private string DichTrangThai (string status) {
            switch( status?.ToUpper () )
            {
                case "COMPLETED": return "Hoàn thành";
                case "PENDING": return "Chờ xử lý";
                case "CANCELLED": return "Đã hủy";
                case "PARTIAL": return "Thanh toán một phần";
                case "UNPAID": return "Chưa thanh toán";
                case "PAID": return "Đã thanh toán";
                default: return status ?? "";
            }
        }
        // ===================== LOAD =====================

        private void Frm_NhapHang_Load (object sender, EventArgs e) {
            StyleDgv (dgvChiTietDonHang);
            StyleDgv (dgvLichSuNhap);

            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.CustomFormat = "d/M/yyyy";

            LoadDataToComboBox ();
            LoadLichSuNhap ();
            LoadCboLocTheoTT();
            UpdateEmptyLabel();

            dgvLichSuNhap.Columns[0].Width = 80;   
            dgvLichSuNhap.Columns[1].Width = 220;  
            dgvLichSuNhap.Columns[2].Width = 150;  
            dgvLichSuNhap.Columns[3].Width = 100;  
            dgvLichSuNhap.Columns[4].Width = 120;  
            dgvLichSuNhap.Columns[5].Width = 200;

            dgvChiTietDonHang.CellClick += (s, ev) => dgvLichSuNhap.ClearSelection();
            dgvLichSuNhap.CellClick += (s, ev) => dgvChiTietDonHang.ClearSelection();
        }

        // ===================== STYLE =====================

        private void StyleDgv (DataGridView dgv) 
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 34;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgv.RowTemplate.Height = 34;
        }

        private void LoadDataToComboBox () {
            using (var db = new AppDbContext())
            {
                var listSuppliers = db.Suppliers.ToList();
                listSuppliers.Insert(0, new Supplier { SupplierID = 0, Name = "--- Chọn nhà cung cấp ---" });
                cboNhaCungCap.DataSource = listSuppliers;
                cboNhaCungCap.DisplayMember = "Name";
                cboNhaCungCap.ValueMember = "SupplierID";
                cboNhaCungCap.SelectedIndex = 0;

                var listProducts = db.Products.ToList();
                listProducts.Insert(0, new Product { ProductID = 0, Name = "--- Chọn sản phẩm ---" });
                cboSanPham.DataSource = listProducts;
                cboSanPham.DisplayMember = "Name";
                cboSanPham.ValueMember = "ProductID";
                cboSanPham.SelectedIndex = 0;
            }
        }

        private void LoadLichSuNhap () {

            try
            {
                using( var db = new AppDbContext () )
                {
                    var ds = db.Imports
                        .Select (x => new
                        {
                            x.ImportID,
                            SupplierName = x.Supplier.Name,
                            UserName = x.User.FullName,
                            x.ImportDate,
                            x.TotalAmount,
                            x.Status      // ← giữ status gốc tiếng Anh để tô màu
                        })
                        .ToList ();

                    dgvLichSuNhap.Rows.Clear ();

                    foreach( var item in ds )
                    {
                        int rowIndex = dgvLichSuNhap.Rows.Add (
                            item.ImportID,
                            item.SupplierName,
                            item.UserName,
                            item.ImportDate?.ToString ("dd/MM/yyyy"),
                            item.TotalAmount.ToString ("N0"),
                            DichTrangThai (item.Status)   // hiển thị tiếng Việt
                        );

                        var cellTrangThai = dgvLichSuNhap.Rows[rowIndex].Cells[5];

                        switch (item.Status?.ToUpper())
                        {
                            case "COMPLETED":
                            case "PAID":
                                cellTrangThai.Style.ForeColor = Color.FromArgb(0, 180, 80);
                                cellTrangThai.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                                break;
                            case "PARTIAL":
                            case "UNPAID":
                                cellTrangThai.Style.ForeColor = Color.FromArgb(255, 160, 0);
                                cellTrangThai.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                                break;
                            case "CANCELLED":
                                cellTrangThai.Style.ForeColor = Color.FromArgb(220, 50, 50);
                                cellTrangThai.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                                break;
                        }
                    }
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show ("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void UpdateEmptyLabel()
        {
            lblPhieu.Visible = dgvChiTietDonHang.Rows.Count == 0;
        }

        private void btnLamMoi_Click (object sender, EventArgs e) {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn làm mới toàn bộ phiếu nhập?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
                return;

            dgvChiTietDonHang.Rows.Clear();
            cboNhaCungCap.SelectedIndex = 0;
            cboSanPham.SelectedIndex = 0;
            dtpNgay.Value = DateTime.Now;
            txtDaThanhToan.Clear();
            TinhTongTien(); // tự cập nhật txtTongGiaTriPhieu, txtCongNo, lblKetQua
            LoadLichSuNhap();
            UpdateEmptyLabel();
        }

        // ===================== LƯU / THANH TOÁN =====================

        private void SaveOrderToDb (decimal soTienThanhToan) {
            if( dgvChiTietDonHang.Rows.Count == 0 || cboNhaCungCap.SelectedItem == null )
            {
                MessageBox.Show ("Vui lòng kiểm tra lại thông tin sản phẩm hoặc nhà cung cấp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using( var db = new AppDbContext () )
                {
                    CboItem nccSelected = (CboItem) cboNhaCungCap.SelectedItem;

                    var hoaDon = new Import ();
                    hoaDon.SupplierID = nccSelected.Value;
                    hoaDon.ImportDate = DateTime.Now;
                    decimal.TryParse (txtTongGiaTriPhieu.Text.Replace (",", ""), out decimal tongTien);
                    hoaDon.TotalAmount = tongTien;
                    hoaDon.UserID = 1;

                    db.Imports.Add (hoaDon);
                    db.SaveChanges ();

                    foreach( DataGridViewRow row in dgvChiTietDonHang.Rows )
                    {
                        if( !row.IsNewRow && row.Tag != null )
                        {
                            Batch batch = new Batch ();
                            batch.ImportID = hoaDon.ImportID;
                            batch.VariantID = (int) row.Tag;

                            int soLuong = Convert.ToInt32 (row.Cells[5].Value);
                            batch.InitialQuantity = soLuong;
                            batch.RemainingQuantity = soLuong;
                            batch.ImportPrice = Convert.ToDecimal (row.Cells[4].Value);

                            bool checkNSX = DateTime.TryParseExact (
                                row.Cells[6].Value?.ToString (), "dd/MM/yyyy",
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nsx);

                            bool checkHSD = DateTime.TryParseExact (
                                row.Cells[7].Value?.ToString (), "dd/MM/yyyy",
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime hsd);

                            if( !checkNSX || !checkHSD )
                            {
                                MessageBox.Show ("Ngày sản xuất hoặc hạn sử dụng không đúng định dạng dd/MM/yyyy",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            batch.ManufactureDate = nsx;
                            batch.ExpiryDate = hsd;

                            db.Batches.Add (batch);
                        }
                    }

                    db.SaveChanges ();
                    MessageBox.Show ("Đã lưu dữ liệu vào hệ thống thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới sau khi lưu
                    dgvChiTietDonHang.Rows.Clear ();
                    txtDaThanhToan.Clear ();
                    TinhTongTien ();
                    LoadLichSuNhap ();
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show ("Lỗi hệ thống: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuPhieu_Click (object sender, EventArgs e) {
            if (dgvChiTietDonHang.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong phiếu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboNhaCungCap.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Supplier nccSelected = (Supplier)cboNhaCungCap.SelectedItem;

            try
            {
                using (var db = new AppDbContext())
                {
                    decimal.TryParse(txtTongGiaTriPhieu.Text.Replace(",", ""), out decimal tongTien);

                    var hoaDon = new Import
                    {
                        SupplierID = nccSelected.SupplierID,
                        ImportDate = dtpNgay.Value,
                        TotalAmount = tongTien,
                        UserID = SessionManager.CurrentUser?.UserID ?? 1,
                        Status = "UNPAID"
                    };

                    db.Imports.Add(hoaDon);
                    db.SaveChanges();

                    foreach (DataGridViewRow row in dgvChiTietDonHang.Rows)
                    {
                        if (row.IsNewRow || row.Tag == null) continue;

                        bool okNSX = DateTime.TryParseExact(
                            row.Cells[6].Value?.ToString(), "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nsx);

                        bool okHSD = DateTime.TryParseExact(
                            row.Cells[7].Value?.ToString(), "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime hsd);

                        if (!okNSX || !okHSD)
                        {
                            MessageBox.Show($"Dòng {row.Index + 1}: NSX hoặc HSD không đúng định dạng dd/MM/yyyy.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        db.Batches.Add(new Batch
                        {
                            ImportID = hoaDon.ImportID,
                            VariantID = (int)row.Tag,
                            InitialQuantity = Convert.ToInt32(row.Cells[5].Value),
                            RemainingQuantity = Convert.ToInt32(row.Cells[5].Value),
                            ImportPrice = Convert.ToDecimal(row.Cells[4].Value),
                            ManufactureDate = nsx,
                            ExpiryDate = hsd
                        });
                    }

                    decimal.TryParse(txtDaThanhToan.Text.Replace(",", ""), out decimal daThanhToan);

                    db.DebtTransactions.Add(new DebtTransaction
                    {
                        SupplierID = nccSelected.SupplierID,
                        TransactionType = "PURCHASE",
                        Amount = tongTien,
                        TransactionDate = dtpNgay.Value,
                        ReferenceImportID = hoaDon.ImportID,
                        Note = $"Nhập hàng phiếu #{hoaDon.ImportID}"
                    });

                    if (daThanhToan > 0)
                    {
                        db.DebtTransactions.Add(new DebtTransaction
                        {
                            SupplierID = nccSelected.SupplierID,
                            TransactionType = "PAYMENT",
                            Amount = daThanhToan,
                            TransactionDate = dtpNgay.Value,
                            ReferenceImportID = hoaDon.ImportID,
                            Note = $"Thanh toán trước cho phiếu nhập #{hoaDon.ImportID}"
                        });

                        hoaDon.Status = daThanhToan >= tongTien ? "COMPLETED" : "PARTIAL";
                    }

                    db.SaveChanges();

                    MessageBox.Show("Lưu phiếu nhập thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvChiTietDonHang.Rows.Clear();
                    txtDaThanhToan.Clear();
                    TinhTongTien();
                    LoadLichSuNhap();
                    UpdateEmptyLabel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click (object sender, EventArgs e) {
            if (dgvLichSuNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để thanh toán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int importID = Convert.ToInt32(dgvLichSuNhap.CurrentRow.Cells[0].Value);
            string supplierName = dgvLichSuNhap.CurrentRow.Cells[1].Value?.ToString();
            string trangThai = dgvLichSuNhap.CurrentRow.Cells[5].Value?.ToString();

            if (trangThai == "Hoàn thành" || trangThai == "Đã thanh toán")
            {
                MessageBox.Show("Phiếu nhập này đã thanh toán xong!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    var phieu = db.Imports.FirstOrDefault(x => x.ImportID == importID);
                    if (phieu == null)
                    {
                        MessageBox.Show("Không tìm thấy phiếu nhập!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    decimal tongTien = phieu.TotalAmount;

                    decimal daDaTra = db.DebtTransactions
                        .Where(x => x.ReferenceImportID == importID
                                 && x.TransactionType.ToLower() == "payment")
                        .Sum(x => (decimal?)x.Amount) ?? 0;

                    decimal conLai = tongTien - daDaTra;

                    if (conLai <= 0)
                    {
                        MessageBox.Show("Phiếu nhập này đã thanh toán đủ!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string input = Microsoft.VisualBasic.Interaction.InputBox(
                        $"Nhà cung cấp:  {supplierName}\n" +
                        $"Tổng tiền:     {tongTien:N0}đ\n" +
                        $"Đã thanh toán: {daDaTra:N0}đ\n" +
                        $"Còn lại:       {conLai:N0}đ\n\n" +
                        "Nhập số tiền thanh toán:",
                        "Thanh toán phiếu nhập",
                        conLai.ToString());

                    if (string.IsNullOrWhiteSpace(input)) return;

                    if (!decimal.TryParse(input, out decimal soTienTra) || soTienTra <= 0)
                    {
                        MessageBox.Show("Số tiền không hợp lệ!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (soTienTra > conLai)
                    {
                        MessageBox.Show(
                            $"Số tiền nhập ({soTienTra:N0}đ) vượt quá số còn lại ({conLai:N0}đ)!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    db.DebtTransactions.Add(new DebtTransaction
                    {
                        SupplierID = phieu.SupplierID,
                        TransactionType = "PAYMENT",
                        Amount = soTienTra,
                        TransactionDate = DateTime.Now,
                        ReferenceImportID = importID,
                        Note = $"Thanh toán phiếu nhập #{importID}"
                    });

                    // Cập nhật trạng thái phiếu
                    phieu.Status = (daDaTra + soTienTra >= tongTien)
                        ? "COMPLETED"
                        : "PARTIAL";

                    db.SaveChanges();

                    MessageBox.Show($"Thanh toán {soTienTra:N0}đ thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLichSuNhap();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TinhTongTien () {
            decimal tong = 0;
            foreach( DataGridViewRow row in dgvChiTietDonHang.Rows )
            {
                if( !row.IsNewRow && row.Cells[8].Value != null )
                {
                    decimal.TryParse (row.Cells[8].Value.ToString (), out decimal thanhTien);
                    tong += thanhTien;
                }
            }

            lblKetQua.Text = string.Format ("{0:N0}VNĐ", tong);
            txtTongGiaTriPhieu.Text = tong.ToString ("N0");
            TinhCongNo ();
        }

        private void TinhCongNo () {
            decimal.TryParse (txtTongGiaTriPhieu.Text.Replace (",", ""), out decimal tongTien);
            decimal.TryParse (txtDaThanhToan.Text.Replace (",", ""), out decimal daTra);
            decimal no = tongTien - daTra;
            txtCongNo.Text = no.ToString ("N0");
        }

        private void txtDaThanhToan_TextChanged (object sender, EventArgs e) {
            TinhCongNo ();
        }

        private void dgvChiTietDonHang_CellContentClick (object sender, DataGridViewCellEventArgs e) {
            TinhTongTien ();
        }

        // ===================== HELPER =====================

        private void CapNhatLaiSTT () {
            for( int i = 0; i < dgvChiTietDonHang.Rows.Count; i++ )
            {
                if( !dgvChiTietDonHang.Rows[i].IsNewRow )
                    dgvChiTietDonHang.Rows[i].Cells[0].Value = (i + 1).ToString ();
            }
        }

        private void btnThemDong_Click(object sender, EventArgs e)
        {
            if (cboNhaCungCap.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboSanPham.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Supplier nccCheck = (Supplier)cboNhaCungCap.SelectedItem;
            Product spDuocChon = (Product)cboSanPham.SelectedItem;

            Frm_NhapChiTietSP frmChiTiet = new Frm_NhapChiTietSP(spDuocChon.ProductID);
            if (frmChiTiet.ShowDialog() == DialogResult.OK)
            {
                decimal thanhTien = frmChiTiet.DonGia * frmChiTiet.SoLuong;
                int rowIndex = dgvChiTietDonHang.Rows.Add(
                    dgvChiTietDonHang.Rows.Count + 1,
                    spDuocChon.Name,
                    frmChiTiet.BienThe,
                    nccCheck.Name,
                    frmChiTiet.DonGia,
                    frmChiTiet.SoLuong,
                    frmChiTiet.NSX.ToString("dd/MM/yyyy"),
                    frmChiTiet.HSD.ToString("dd/MM/yyyy"),
                    thanhTien
                );
                dgvChiTietDonHang.Rows[rowIndex].Tag = frmChiTiet.VariantID;
            }
            TinhTongTien();
            UpdateEmptyLabel();
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvChiTietDonHang.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa sản phẩm này khỏi danh sách?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvChiTietDonHang.SelectedRows)
                    {
                        if (!row.IsNewRow)
                            dgvChiTietDonHang.Rows.Remove(row);
                    }
                    CapNhatLaiSTT();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            UpdateEmptyLabel();
            TinhTongTien();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void cboLocTheoTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void LocDuLieu()
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            string trangThaiLoc = cboLocTheoTT.SelectedValue?.ToString() ?? "ALL";

            try
            {
                using (var db = new AppDbContext())
                {
                    var ds = db.Imports
                        .Select(x => new
                        {
                            x.ImportID,
                            SupplierName = x.Supplier.Name,
                            UserName = x.User.FullName,
                            x.ImportDate,
                            x.TotalAmount,
                            x.Status
                        })
                        .ToList();

                    if (trangThaiLoc != "ALL")
                        ds = ds.Where(x => x.Status?.ToUpper() == trangThaiLoc).ToList();

                    if (!string.IsNullOrEmpty(tuKhoa))
                        ds = ds.Where(x =>
                            x.SupplierName.ToLower().Contains(tuKhoa) ||
                            x.ImportID.ToString().Contains(tuKhoa) ||
                            x.UserName.ToLower().Contains(tuKhoa)
                        ).ToList();

                    dgvLichSuNhap.Rows.Clear();

                    foreach (var item in ds)
                    {
                        int rowIndex = dgvLichSuNhap.Rows.Add(
                            item.ImportID,
                            item.SupplierName,
                            item.UserName,
                            item.ImportDate?.ToString("dd/MM/yyyy"),
                            item.TotalAmount.ToString("N0"),
                            DichTrangThai(item.Status)
                        );

                        var cell = dgvLichSuNhap.Rows[rowIndex].Cells[5];
                        switch (item.Status?.ToUpper())
                        {
                            case "COMPLETED":
                            case "PAID":
                                cell.Style.ForeColor = Color.FromArgb(0, 180, 80);
                                cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                                break;
                            case "PARTIAL":
                            case "UNPAID":
                                cell.Style.ForeColor = Color.FromArgb(255, 160, 0);
                                cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                                break;
                            case "CANCELLED":
                                cell.Style.ForeColor = Color.FromArgb(220, 50, 50);
                                cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCboLocTheoTT()
        {
            var dsTrangThai = new[]
            {
                new { Text = "Tất cả trạng thái", Value = "ALL" },
                new { Text = "Hoàn thành", Value = "COMPLETED" },
                new { Text = "Chưa thanh toán", Value = "UNPAID" },
                new { Text = "Thanh toán một phần", Value = "PARTIAL" }
            };

            cboLocTheoTT.DataSource = dsTrangThai;
            cboLocTheoTT.DisplayMember = "Text";
            cboLocTheoTT.ValueMember = "Value";
            cboLocTheoTT.SelectedIndex = 0;
            cboLocTheoTT.DropDownWidth = 200;
            cboLocTheoTT.SelectedIndexChanged += (s, ev) => LocDuLieu();
        }
    }

    // Class phụ giúp ComboBox lưu cả Tên và ID
    public class CboItem {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString () => Text;
    }
}