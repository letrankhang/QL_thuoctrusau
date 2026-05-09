using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Models;
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

            LoadDataToComboBox ();
            LoadLichSuNhap ();
        }

        // ===================== STYLE =====================

        private void StyleDgv (DataGridView dgv) {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb (220, 225, 235);
            dgv.BackgroundColor = Color.White;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ✅ Header xanh dương đậm giống bảng Sản phẩm
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb (52, 107, 163);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font ("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb (52, 107, 163);
            dgv.ColumnHeadersHeight = 42;

            // Row
            dgv.DefaultCellStyle.Font = new Font ("Segoe UI", 9.5f);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb (40, 40, 40);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb (210, 225, 245);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb (30, 30, 30);
            dgv.DefaultCellStyle.Padding = new Padding (4, 0, 4, 0);
            dgv.RowTemplate.Height = 36;

            // ✅ Alternating rows xám nhạt giống bảng Sản phẩm
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb (245, 247, 250);
        }

        // ===================== LOAD DỮ LIỆU =====================

        private void LoadDataToComboBox () {
            try
            {
                using( var db = new AppDbContext () )
                {
                    cboNhaCungCap.Items.Clear ();
                    var listSuppliers = db.Suppliers.ToList ();
                    foreach( var ncc in listSuppliers )
                    {
                        cboNhaCungCap.Items.Add (new CboItem { Text = ncc.Name, Value = ncc.SupplierID });
                    }

                    cboSanPham.Items.Clear ();
                    var listProducts = db.Products.ToList ();
                    foreach( var sp in listProducts )
                    {
                        cboSanPham.Items.Add (new CboItem { Text = sp.Name, Value = sp.ProductID });
                    }
                }
            }
            catch( Exception ex )
            {
                string errorMsg = "Lỗi bề mặt: " + ex.Message;
                if( ex.InnerException != null )
                    errorMsg += "\n\nLỗi bên trong:\n" + ex.InnerException.Message;
                MessageBox.Show (errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        // Tô màu theo status gốc tiếng Anh — đúng logic
                        switch( item.Status?.ToUpper () )
                        {
                            case "COMPLETED":
                            case "PAID":
                                dgvLichSuNhap.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb (198, 239, 206);
                                dgvLichSuNhap.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                                break;
                            case "PARTIAL":
                            case "UNPAID":
                                dgvLichSuNhap.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb (255, 235, 156);
                                dgvLichSuNhap.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkOrange;
                                break;
                            case "CANCELLED":
                                dgvLichSuNhap.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb (255, 199, 206);
                                dgvLichSuNhap.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
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

        // ===================== THÊM / XÓA DÒNG =====================

        private void btnThemDong_Click (object sender, EventArgs e) {
            if( cboSanPham.SelectedItem == null )
            {
                MessageBox.Show ("Vui lòng chọn sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CboItem spDuocChon = (CboItem) cboSanPham.SelectedItem;
            string tenSanPham = spDuocChon.Text;
            string tenNhaCungCap = cboNhaCungCap.Text;

            Frm_NhapChiTietSP frmChiTiet = new Frm_NhapChiTietSP ();

            if( frmChiTiet.ShowDialog () == DialogResult.OK )
            {
                int stt = dgvChiTietDonHang.Rows.Count + 1;
                decimal thanhTien = frmChiTiet.DonGia * frmChiTiet.SoLuong;

                int rowIndex = dgvChiTietDonHang.Rows.Add (
                    stt,
                    tenSanPham,
                    frmChiTiet.BienThe,
                    tenNhaCungCap,
                    frmChiTiet.DonGia,
                    frmChiTiet.SoLuong,
                    frmChiTiet.NSX.ToString ("dd/MM/yyyy"),
                    frmChiTiet.HSD.ToString ("dd/MM/yyyy"),
                    thanhTien
                );

                dgvChiTietDonHang.Rows[rowIndex].Tag = frmChiTiet.VariantID;
            }

            TinhTongTien ();
        }

        private void btnXoaDong_Click (object sender, EventArgs e) {
            if( dgvChiTietDonHang.SelectedRows.Count > 0 )
            {
                DialogResult dr = MessageBox.Show (
                    "Bạn có chắc chắn muốn xóa sản phẩm này khỏi danh sách?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if( dr == DialogResult.Yes )
                {
                    foreach( DataGridViewRow row in dgvChiTietDonHang.SelectedRows )
                    {
                        if( !row.IsNewRow )
                            dgvChiTietDonHang.Rows.Remove (row);
                    }
                    CapNhatLaiSTT ();
                }
            }
            else
            {
                MessageBox.Show ("Vui lòng chọn sản phẩm cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            TinhTongTien ();
        }

        // ===================== LÀM MỚI =====================

        private void btnLamMoi_Click (object sender, EventArgs e) {
            DialogResult dr = MessageBox.Show (
                "Bạn có chắc muốn làm mới toàn bộ phiếu nhập?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if( dr != DialogResult.Yes ) return;

            try
            {
                // Xóa bảng chi tiết
                dgvChiTietDonHang.Rows.Clear ();

                // Reset combobox
                if( cboNhaCungCap.Items.Count > 0 ) cboNhaCungCap.SelectedIndex = 0;
                if( cboSanPham.Items.Count > 0 ) cboSanPham.SelectedIndex = 0;

                // Reset textbox
                txtDaThanhToan.Clear ();
                txtTongGiaTriPhieu.Clear ();
                txtCongNo.Clear ();
                lblKetQua.Text = "0 VNĐ";

                // Reload lịch sử
                LoadLichSuNhap ();

                MessageBox.Show ("Đã làm mới phiếu nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch( Exception ex )
            {
                MessageBox.Show ("Lỗi làm mới: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if( dgvChiTietDonHang.Rows.Count == 0 )
            {
                MessageBox.Show ("Chưa có sản phẩm nào trong phiếu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if( cboNhaCungCap.SelectedItem == null )
            {
                MessageBox.Show ("Vui lòng chọn nhà cung cấp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using( var db = new AppDbContext () )
                {
                    CboItem nccSelected = (CboItem) cboNhaCungCap.SelectedItem;

                    decimal.TryParse (
                        txtTongGiaTriPhieu.Text.Replace (",", ""),
                        out decimal tongTien);

                    var hoaDon = new Import
                    {
                        SupplierID = nccSelected.Value,
                        ImportDate = dataNgay.Value,
                        TotalAmount = tongTien,
                        UserID = 1,
                        Status = "UNPAID"
                    };

                    db.Imports.Add (hoaDon);
                    db.SaveChanges ();

                    foreach( DataGridViewRow row in dgvChiTietDonHang.Rows )
                    {
                        if( row.IsNewRow || row.Tag == null ) continue;

                        bool okNSX = DateTime.TryParseExact (
                            row.Cells[6].Value?.ToString (), "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None,
                            out DateTime nsx);

                        bool okHSD = DateTime.TryParseExact (
                            row.Cells[7].Value?.ToString (), "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None,
                            out DateTime hsd);

                        if( !okNSX || !okHSD )
                        {
                            MessageBox.Show (
                                $"Dòng {row.Index + 1}: NSX hoặc HSD không đúng định dạng dd/MM/yyyy.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        db.Batches.Add (new Batch
                        {
                            ImportID = hoaDon.ImportID,
                            VariantID = (int) row.Tag,
                            InitialQuantity = Convert.ToInt32 (row.Cells[5].Value),
                            RemainingQuantity = Convert.ToInt32 (row.Cells[5].Value),
                            ImportPrice = Convert.ToDecimal (row.Cells[4].Value),
                            ManufactureDate = nsx,
                            ExpiryDate = hsd
                        });
                    }

                    decimal.TryParse (txtDaThanhToan.Text.Replace (",", ""), out decimal daThanhToan);

                    // ✅ Tạo DebtTransaction gốc loại PURCHASE để Frm_CongNo load được
                    db.DebtTransactions.Add (new DebtTransaction
                    {
                        SupplierID = nccSelected.Value,
                        TransactionType = "PURCHASE",
                        Amount = tongTien,
                        TransactionDate = dataNgay.Value,
                        ReferenceImportID = hoaDon.ImportID,
                        Note = $"Nhập hàng phiếu #{hoaDon.ImportID}"
                    });

                    // ✅ Nếu có thanh toán trước, ghi nhận thêm một giao dịch PAYMENT
                    if( daThanhToan > 0 )
                    {
                        db.DebtTransactions.Add (new DebtTransaction
                        {
                            SupplierID = nccSelected.Value,
                            TransactionType = "PAYMENT",
                            Amount = daThanhToan,
                            TransactionDate = dataNgay.Value,
                            ReferenceImportID = hoaDon.ImportID,
                            Note = $"Thanh toán trước cho phiếu nhập #{hoaDon.ImportID}"
                        });

                        // Cập nhật trạng thái phiếu nhập nếu thanh toán đủ hoặc một phần
                        if( daThanhToan >= tongTien )
                            hoaDon.Status = "COMPLETED";
                        else
                            hoaDon.Status = "PARTIAL";
                    }

                    db.SaveChanges ();

                    MessageBox.Show ("Lưu phiếu nhập thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvChiTietDonHang.Rows.Clear ();
                    txtDaThanhToan.Clear ();
                    TinhTongTien ();
                    LoadLichSuNhap ();
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show ("Lỗi khi lưu phiếu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click (object sender, EventArgs e) {
            if( dgvLichSuNhap.CurrentRow == null )
            {
                MessageBox.Show ("Vui lòng chọn một phiếu nhập để thanh toán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int importID = Convert.ToInt32 (dgvLichSuNhap.CurrentRow.Cells[0].Value);
            string supplierName = dgvLichSuNhap.CurrentRow.Cells[1].Value?.ToString ();
            string trangThai = dgvLichSuNhap.CurrentRow.Cells[5].Value?.ToString ();

            if( trangThai == "Hoàn thành" || trangThai == "Đã thanh toán" )
            {
                MessageBox.Show ("Phiếu nhập này đã thanh toán xong!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using( var db = new AppDbContext () )
                {
                    var phieu = db.Imports.FirstOrDefault (x => x.ImportID == importID);
                    if( phieu == null )
                    {
                        MessageBox.Show ("Không tìm thấy phiếu nhập!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    decimal tongTien = phieu.TotalAmount;

                    decimal daDaTra = db.DebtTransactions
                        .Where (x => x.ReferenceImportID == importID
                                 && x.TransactionType.ToLower () == "payment")
                        .Sum (x => (decimal?) x.Amount) ?? 0;

                    decimal conLai = tongTien - daDaTra;

                    if( conLai <= 0 )
                    {
                        MessageBox.Show ("Phiếu nhập này đã thanh toán đủ!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string input = Microsoft.VisualBasic.Interaction.InputBox (
                        $"Nhà cung cấp:  {supplierName}\n" +
                        $"Tổng tiền:     {tongTien:N0} đ\n" +
                        $"Đã thanh toán: {daDaTra:N0} đ\n" +
                        $"Còn lại:       {conLai:N0} đ\n\n" +
                        "Nhập số tiền thanh toán:",
                        "Thanh toán phiếu nhập",
                        conLai.ToString ());

                    if( string.IsNullOrWhiteSpace (input) ) return;

                    if( !decimal.TryParse (input, out decimal soTienTra) || soTienTra <= 0 )
                    {
                        MessageBox.Show ("Số tiền không hợp lệ!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if( soTienTra > conLai )
                    {
                        MessageBox.Show (
                            $"Số tiền nhập ({soTienTra:N0} đ) vượt quá số còn lại ({conLai:N0} đ)!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    db.DebtTransactions.Add (new DebtTransaction
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

                    db.SaveChanges ();

                    MessageBox.Show ($"Thanh toán {soTienTra:N0} đ thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLichSuNhap ();
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show ("Lỗi thanh toán: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== TÍNH TIỀN =====================

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

            lblKetQua.Text = string.Format ("{0:N0} VNĐ", tong);
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

        // ===================== TÌM KIẾM =====================

        private void btnTim_Click (object sender, EventArgs e) {
            try
            {
                using( var db = new AppDbContext () )
                {
                    string keyword = txtTimKiem.Text.Trim ().ToLower ();

                    var ds = db.Imports
                        .Where (x =>
                            x.ImportID.ToString ().Contains (keyword) ||
                            x.Supplier.Name.ToLower ().Contains (keyword) ||
                            x.User.FullName.ToLower ().Contains (keyword))
                        .Select (x => new
                        {
                            x.ImportID,
                            SupplierName = x.Supplier.Name,
                            UserName = x.User.FullName,
                            x.ImportDate,
                            x.TotalAmount,
                            x.Status
                        })
                        .ToList ();

                    dgvLichSuNhap.Rows.Clear ();

                    foreach( var item in ds )
                    {
                        dgvLichSuNhap.Rows.Add (
                            item.ImportID,
                            item.SupplierName,
                            item.UserName,
                            item.ImportDate?.ToString ("dd/MM/yyyy"),
                            item.TotalAmount.ToString ("N0"),
                            DichTrangThai (item.Status)
                        );
                    }
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show ("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== HELPER =====================

        private void CapNhatLaiSTT () {
            for( int i = 0; i < dgvChiTietDonHang.Rows.Count; i++ )
            {
                if( !dgvChiTietDonHang.Rows[i].IsNewRow )
                    dgvChiTietDonHang.Rows[i].Cells[0].Value = (i + 1).ToString ();
            }
        }

        private void btnLamMoi_Click_1 (object sender, EventArgs e) {
            DialogResult dr = MessageBox.Show (
        "Bạn có chắc muốn làm mới toàn bộ phiếu nhập?",
        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if( dr != DialogResult.Yes ) return;

            dgvChiTietDonHang.Rows.Clear ();
            cboNhaCungCap.SelectedIndex = 0;
            cboSanPham.SelectedIndex = 0;
            dataNgay.Value = DateTime.Now;
            txtDaThanhToan.Clear ();
            TinhTongTien (); // tự cập nhật txtTongGiaTriPhieu, txtCongNo, lblKetQua
            LoadLichSuNhap ();
        }
    }

    // Class phụ giúp ComboBox lưu cả Tên và ID
    public class CboItem {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString () => Text;
    }
}