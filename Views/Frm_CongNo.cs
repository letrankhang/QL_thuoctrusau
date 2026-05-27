using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_CongNo : Form
    {
        private bool isLoaded = false;
        private int _currentPage = 1;
        private int _pageSize = 14;
        private int _totalRows = 0;
        private System.Collections.Generic.List<ViewModels.CongNoViewModel> _fullFilteredList = new System.Collections.Generic.List<ViewModels.CongNoViewModel>();


        private void StyleDgv(DataGridView dgv)
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

        private void SetupColumns()
        {
            dgvCongNo.Columns.Clear();

            dgvCongNo.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã đơn hàng",
                DataPropertyName = "OrderID",
                Name = "OrderID",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter },
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            dgvCongNo.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên đối tác",
                DataPropertyName = "PartnerName",
                Name = "PartnerName"
            });

            dgvCongNo.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Loại nợ",
                DataPropertyName = "LoaiNo",
                Name = "LoaiNo",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter },
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            dgvCongNo.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tổng công nợ",
                DataPropertyName = "TotalAmount",
                Name = "TotalAmount",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleLeft },
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            dgvCongNo.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đã thanh toán",
                DataPropertyName = "PaidAmount",
                Name = "PaidAmount",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleLeft },
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            dgvCongNo.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Còn lại",
                DataPropertyName = "RemainingDebt",
                Name = "RemainingDebt",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleLeft },
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            dgvCongNo.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày lập",
                DataPropertyName = "OrderDate",
                Name = "OrderDate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy", Alignment = DataGridViewContentAlignment.MiddleCenter },
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            dgvCongNo.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Trạng thái",
                DataPropertyName = "Status",
                Name = "Status",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter },
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });
            dgvCongNo.Columns["PartnerName"].FillWeight = 180;
            dgvCongNo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public Frm_CongNo()
        {
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents()
        {
            this.Load += Frm_CongNo_Load;
            cboLocKhachHang.SelectedIndexChanged += CboLocKhachHang_SelectedIndexChanged;
            cboTrangThai.SelectedIndexChanged += (s, e) => { if (isLoaded) { _currentPage = 1; LoadData(); } };
            dtpTuNgay.ValueChanged += (s, e) => { if (isLoaded) { _currentPage = 1; LoadData(); } };
            dtpDenNgay.ValueChanged += (s, e) => { if (isLoaded) { _currentPage = 1; LoadData(); } };
            btnNext.Click += BtnNext_Click;
            btnPrev.Click += BtnPrev_Click;
            dgvCongNo.DataBindingComplete += (s, e) => ToMauDong();
        }

        private void Frm_CongNo_Load(object sender, EventArgs e)
        {
            StyleDgv(dgvCongNo);

            dgvCongNo.AutoGenerateColumns = false;
            dgvCongNo.AllowUserToAddRows = false;

            SetupColumns();

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Tất cả trạng thái");
            cboTrangThai.Items.Add("Chưa thanh toán");
            cboTrangThai.Items.Add("Thanh toán một phần");
            cboTrangThai.Items.Add("Đã thanh toán");
            cboTrangThai.SelectedIndex = 0;

            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "d/M/yyyy";

            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "d/M/yyyy";

            LoadCustomers();

            isLoaded = true;

            LoadData();
            CanhBaoNoQuaHan();
        }

        private void LoadCustomers()
        {
            cboLocKhachHang.Items.Clear();
            cboLocKhachHang.Items.Add("Tất cả khách hàng");
            cboLocKhachHang.DropDownWidth = 400;
            cboTrangThai.DropDownWidth = 220;
            try
            {
                using (var db = new AppDbContext())
                {
                    var customerNames = db.Customers.Select(c => c.Name).ToList();
                    var supplierNames = db.Suppliers.Select(s => s.Name).ToList();

                    var allNames = customerNames.Concat(supplierNames)
                        .Distinct().OrderBy(x => x).ToList();

                    foreach (var name in allNames)
                        if (!string.IsNullOrEmpty(name))
                            cboLocKhachHang.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách đối tác: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cboLocKhachHang.Items.Count > 0)
                cboLocKhachHang.SelectedIndex = 0;
        }

        private void LoadData()
        {
            int savedPage = _currentPage;
            try
            {
                using (var db = new AppDbContext())
                {
                    string keyword = (txtTimKiem.Text ?? "").Trim().ToLower();
                    string doiTacFilter = cboLocKhachHang.SelectedItem?.ToString() ?? "Tất cả khách hàng";
                    string trangThai = cboTrangThai.SelectedItem?.ToString() ?? "Tất cả trạng thái";
                    DateTime tuNgay = dtpTuNgay.Value.Date;
                    DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

                    var baseTransactions = db.DebtTransactions
                        .Include(d => d.Customer)
                        .Include(d => d.Supplier)
                        .Include(d => d.Order.User)   // Load User cho đơn hàng
                        .Include(d => d.Import.User)  // Load User cho phiếu nhập
                        .Where(d => (d.TransactionType.ToUpper() == "SALE" || 
                                     d.TransactionType.ToUpper() == "PURCHASE" || 
                                     d.TransactionType.ToUpper() == "DEBT")
                                 && d.TransactionDate >= tuNgay
                                 && d.TransactionDate < denNgay)
                        .ToList();

                    var combined = baseTransactions.Select(t => {
                        decimal totalDebtAmount = t.Amount;
                        decimal paidAmount = 0;
                        string staff = "N/A";

                        if (t.ReferenceOrderID != null)
                        {
                            paidAmount = db.DebtTransactions
                                .Where(p => p.TransactionType.ToUpper() == "PAYMENT" && p.ReferenceOrderID == t.ReferenceOrderID)
                                .Sum(p => (decimal?)p.Amount) ?? 0;
                            staff = t.Order?.User?.FullName ?? "N/A";
                        }
                        else if (t.ReferenceImportID != null)
                        {
                            paidAmount = db.DebtTransactions
                                .Where(p => p.TransactionType.ToUpper() == "PAYMENT" && p.ReferenceImportID == t.ReferenceImportID)
                                .Sum(p => (decimal?)p.Amount) ?? 0;
                            staff = t.Import?.User?.FullName ?? "N/A";
                        }

                        decimal remaining = totalDebtAmount - paidAmount;

                        return new ViewModels.CongNoViewModel
                        {
                            OrderID = t.ReferenceOrderID ?? t.ReferenceImportID,
                            PartnerName = t.Customer?.Name ?? t.Supplier?.Name ?? "N/A",
                            TotalAmount = totalDebtAmount,
                            PaidAmount = paidAmount,
                            RemainingDebt = remaining,
                            OrderDate = t.TransactionDate,
                            LoaiNo = (t.TransactionType.ToUpper() == "PURCHASE") ? "Nhà cung cấp" : "Khách hàng",
                            Status = remaining <= 0 ? "Đã thanh toán"
                                   : remaining < totalDebtAmount ? "Thanh toán một phần"
                                   : "Chưa thanh toán",
                            StaffName = staff
                        };
                    }).ToList();

                    // ── BỘ LỌC ──
                    var filtered = combined.AsEnumerable();

                    if (!string.IsNullOrEmpty(keyword))
                        filtered = filtered.Where(x => 
                            x.OrderID.ToString().Contains(keyword) || 
                            x.PartnerName.ToLower().Contains(keyword));

                    if (doiTacFilter != "Tất cả khách hàng")
                        filtered = filtered.Where(x => x.PartnerName == doiTacFilter);

                    if (trangThai != "Tất cả trạng thái")
                        filtered = filtered.Where(x => x.Status == trangThai);

                    var finalResult = filtered.OrderByDescending(x => x.OrderDate).ToList();

                    _totalRows = finalResult.Count;
                    _fullFilteredList = finalResult; // Lưu lại danh sách đầy đủ đã lọc

                    dgvCongNo.DataSource = finalResult
                        .Skip((_currentPage - 1) * _pageSize)
                        .Take(_pageSize)
                        .ToList();

                    // Lưu lại danh sách đã lọc để xuất Excel nếu cần (hoặc lấy trực tiếp từ DataSource)
                    // Ở đây ta tính toán tổng dựa trên finalResult (đã lọc nhưng chưa phân trang)
                    decimal tongNoKhach = finalResult.Where(x => x.LoaiNo == "Khách hàng").Sum(x => x.RemainingDebt);
                    decimal tongNoNCC = finalResult.Where(x => x.LoaiNo == "Nhà cung cấp").Sum(x => x.RemainingDebt);
                    
                    lblTongCongNoValue.Text = (tongNoKhach + tongNoNCC).ToString("N0");
                    lblNoPhaiThuValue.Text = tongNoKhach.ToString("N0");
                    lblDaThanhToanValue.Text = tongNoNCC.ToString("N0");
                    
                    // Cập nhật text label cho trực quan
                    lblNoPhaiThuTitle.Text = "Khách nợ (Phải thu)";
                    lblDaThanhToanTitle.Text = "Nợ NCC (Phải trả)";
                    lblTongCongNoTitle.Text = "Tổng công nợ";
                    
                    lblNoPhaiThuValue.ForeColor = Color.FromArgb(0, 120, 215); // Xanh dương cho phải thu
                    lblDaThanhToanValue.ForeColor = Color.FromArgb(0, 192, 0); // Đỏ cho phải trả

                    UpdatePagingInfo();
                    ToMauDong();
                }
            }
            catch (Exception ex)
            {
                _currentPage = savedPage;
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToMauDong()
        {
            foreach (DataGridViewRow r in dgvCongNo.Rows)
            {
                if (r.IsNewRow) 
                    continue;

                string status = r.Cells["Status"].Value?.ToString() ?? "";
                bool quaHan = r.Cells["OrderDate"].Value is DateTime dt && (DateTime.Now - dt).TotalDays > 30;

                r.Cells["Status"].Style.Font = new System.Drawing.Font("Segoe UI", 9.5f, FontStyle.Bold);

                if (status == "Đã thanh toán")
                    r.Cells["Status"].Style.ForeColor = Color.FromArgb(0, 150, 60);

                else if (status == "Thanh toán một phần")
                    r.Cells["Status"].Style.ForeColor = Color.FromArgb(200, 120, 0);

                else if (quaHan)
                    r.Cells["Status"].Style.ForeColor = Color.DarkRed;

                else
                    r.Cells["Status"].Style.ForeColor = Color.FromArgb(200, 80, 0);
            }
        }

        private void CanhBaoNoQuaHan()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var ngayQuaHan = DateTime.Now.AddDays(-30);

                    var dsQuaHan = db.DebtTransactions
                        .Include(x => x.Customer)
                        .Include(x => x.Supplier)
                        .Where(x => (x.TransactionType.ToUpper() == "SALE" ||
                                     x.TransactionType.ToUpper() == "PURCHASE")
                                 && x.TransactionDate < ngayQuaHan
                                 && x.Amount > 0)
                        .Select(x => new
                        {
                            TenDoiTac = x.Customer != null ? x.Customer.Name
                                      : x.Supplier != null ? x.Supplier.Name : "N/A",
                            Amount = x.Amount,
                            OrderDate = x.TransactionDate,
                            LoaiNo = x.TransactionType.ToUpper() == "SALE" ? "Khách hàng" : "Nhà cung cấp"
                        })
                        .ToList();

                    if (dsQuaHan.Any())
                    {
                        string msg = $"⚠️ Có {dsQuaHan.Count} khoản nợ quá hạn (> 30 ngày):\n\n";
                        foreach (var item in dsQuaHan.Take(5))
                            msg += $"• [{item.LoaiNo}] {item.TenDoiTac} — {item.Amount:N0} đ — {item.OrderDate:dd/MM/yyyy}\n";

                        if (dsQuaHan.Count > 5)
                            msg += $"... và {dsQuaHan.Count - 5} khoản khác.";

                        MessageBox.Show(msg, "Cảnh báo nợ quá hạn",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra nợ quá hạn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePagingInfo()
        {
            int start = _totalRows == 0 ? 0 : (_currentPage - 1) * _pageSize + 1;
            int end = Math.Min(_currentPage * _pageSize, _totalRows);
            lblPageInfo.Text = $"{start}-{end} of {_totalRows} items";

            int totalPages = _pageSize == 0 ? 1 : (_totalRows + _pageSize - 1) / _pageSize;
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < totalPages;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int totalPages = (_totalRows + _pageSize - 1) / _pageSize;
                if (_currentPage < totalPages) { _currentPage++; LoadData(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển trang tiếp: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentPage > 1) { _currentPage--; LoadData(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển trang trước: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            _currentPage = 1;
            LoadData();
        }

        private void CboLocKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            _currentPage = 1;
            LoadData();
        }

        private void btnThuNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCongNo.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một dòng để thu/trả nợ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string orderID = dgvCongNo.CurrentRow.Cells["OrderID"].Value?.ToString();
                string partnerName = dgvCongNo.CurrentRow.Cells["PartnerName"].Value?.ToString();
                string loaiNo = dgvCongNo.CurrentRow.Cells["LoaiNo"].Value?.ToString();
                decimal remaining = Convert.ToDecimal(dgvCongNo.CurrentRow.Cells["RemainingDebt"].Value ?? 0);

                if (remaining <= 0)
                {
                    MessageBox.Show("Khoản nợ này đã thanh toán đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string hanhDong = loaiNo == "Khách hàng" ? "Thu nợ" : "Trả nợ";
                decimal soTienThu = 0;

                Form frmInput = new Form
                {
                    Width = 400,
                    Height = 274,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = hanhDong,
                    StartPosition = FormStartPosition.CenterParent,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    BackColor = Color.White,
                    Font = new Font("Segoe UI", 10)
                };

                Label lblConLai = new Label
                {
                    Left = 20,
                    Top = 13,
                    Width = 345,
                    Height = 30,
                    Text = $"Còn phải {(loaiNo == "Khách hàng" ? "thu" : "trả")}: {remaining:N0} VNĐ",
                    Font = new Font("Segoe UI", 13, FontStyle.Bold),
                    ForeColor = Color.FromArgb(70, 130, 180)
                };

                Label lblLoaiNo = new Label
                {
                    Left = 20,
                    Top = 50,
                    Width = 345,
                    Height = 20,
                    Text = "Loại nợ: " + loaiNo,
                    ForeColor = Color.FromArgb(60, 60, 60)
                };

                Label lblDoiTac = new Label
                {
                    Left = 20,
                    Top = 73,  // 50 + 23
                    Width = 345,
                    Height = 20,
                    Text = "Đối tác: " + partnerName,
                    ForeColor = Color.FromArgb(60, 60, 60)
                };

                Label lblNhap = new Label
                {
                    Left = 20,
                    Top = 100,  // 75 + 23
                    Width = 345,
                    Height = 20,
                    Text = "Số tiền " + hanhDong.ToLower() + ":",
                    ForeColor = Color.FromArgb(60, 60, 60)
                };

                Guna.UI2.WinForms.Guna2TextBox txtTien = new Guna.UI2.WinForms.Guna2TextBox
                {
                    Left = 15,
                    Top = 96,
                    Width = 248,
                    Height = 24,
                    Text = remaining.ToString("0"),
                    Font = new Font("Segoe UI", 12),
                    BorderColor = Color.FromArgb(200, 200, 200),
                    BorderRadius = 6
                };
                txtTien.KeyPress += (s, ev) =>
                {
                    if (!char.IsDigit(ev.KeyChar) && ev.KeyChar != '\b')
                        ev.Handled = true;
                };

                Guna.UI2.WinForms.Guna2Button btnOK = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = "Xác nhận",
                    Left = 20,
                    Top = 172,
                    Width = 164,
                    Height = 40,
                    FillColor = Color.FromArgb(70, 130, 180),
                    ForeColor = Color.White,
                    BorderRadius = 6,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };

                Guna.UI2.WinForms.Guna2Button btnCancel = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = "Hủy",
                    Left = 199,
                    Top = 172,
                    Width = 164,
                    Height = 40,
                    FillColor = Color.FromArgb(224, 224, 224),
                    ForeColor = Color.FromArgb(128, 128, 128),
                    BorderRadius = 6,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };

                btnOK.Click += (s, ev) =>
                {
                    string clean = txtTien.Text.Replace(",", "").Replace(".", "");
                    if (!decimal.TryParse(clean, out decimal so) || so <= 0)
                    {
                        MessageBox.Show("Số tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (so > remaining)
                    {
                        MessageBox.Show($"Số tiền ({so:N0}) vượt quá số còn nợ ({remaining:N0})!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    soTienThu = so;
                    frmInput.DialogResult = DialogResult.OK;
                    frmInput.Close();
                };
                btnCancel.Click += (s, ev) => frmInput.Close();

                frmInput.Controls.AddRange(new Control[] { lblConLai, lblLoaiNo, lblDoiTac, lblNhap, txtTien, btnOK, btnCancel });
                frmInput.AcceptButton = btnOK;
                frmInput.CancelButton = btnCancel;

                if (frmInput.ShowDialog() != DialogResult.OK) return;

                using (var db = new AppDbContext())
                {
                    using (var dbTran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var payment = new DebtTransaction
                            {
                                TransactionType = "PAYMENT",
                                Amount = soTienThu,
                                TransactionDate = DateTime.Now
                            };

                            if (loaiNo == "Khách hàng")
                            {
                                int id = int.Parse(orderID);
                                payment.ReferenceOrderID = id;
                                payment.Note = $"Thu nợ đơn hàng #{orderID}";

                                var order = db.Orders.Find(id);
                                if (order != null)
                                {
                                    payment.CustomerID = order.CustomerID;
                                    if (soTienThu >= remaining)
                                        order.Status = "COMPLETED";
                                }
                            }
                            else
                            {
                                int id = int.Parse(orderID);
                                payment.ReferenceImportID = id;
                                payment.Note = $"Trả nợ phiếu nhập #{orderID}";

                                var original = db.DebtTransactions
                                    .FirstOrDefault(x => x.ReferenceImportID == id
                                                      && x.TransactionType.ToUpper() == "PURCHASE");
                                if (original != null)
                                    payment.SupplierID = original.SupplierID;

                                var phieuNhap = db.Imports.Find(id);
                                if (phieuNhap != null)
                                {
                                    decimal tongTien = phieuNhap.TotalAmount;
                                    decimal daDaTra = db.DebtTransactions
                                        .Where(x => x.ReferenceImportID == id
                                                 && x.TransactionType.ToUpper() == "PAYMENT")
                                        .Sum(x => (decimal?)x.Amount) ?? 0;

                                    phieuNhap.Status = (daDaTra + soTienThu >= tongTien)
                                        ? "COMPLETED"
                                        : "PARTIAL";
                                }
                            }

                            db.DebtTransactions.Add(payment);
                            db.SaveChanges();
                            dbTran.Commit();

                            MessageBox.Show($"{hanhDong} {soTienThu:N0}đ thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            dbTran.Rollback();
                            throw;
                        }
                    }
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi giao dịch: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (_fullFilteredList == null || _fullFilteredList.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var saveDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = $"CongNo_{DateTime.Now:ddMMyyyy_HHmm}.xlsx"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Utils.ExcelHelper.XuatExcelCongNo(_fullFilteredList, saveDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}