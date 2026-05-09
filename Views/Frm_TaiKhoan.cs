using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views {
    public partial class Frm_TaiKhoan : Form {
        private readonly UserController _userController;
        private List<User> _allUsers;

        public Frm_TaiKhoan () {
            InitializeComponent ();
            _userController = new UserController ();

            // Đăng ký sự kiện
            this.Load += Frm_TaiKhoan_Load;
            this.dgvUsers.CellPainting += dgvUsers_CellPainting;
            this.txtSearch.TextChanged += txtSearch_TextChanged;
            this.dgvUsers.CellClick += dgvUsers_CellClick;

            this.cboLocChucVu.SelectedIndexChanged += ApplyFilter;
            this.cboLocTrangThai.SelectedIndexChanged += ApplyFilter;
            this.cboLocNgayTao.SelectedIndexChanged += ApplyFilter;
        }

        private void dgvUsers_CellClick (object sender, DataGridViewCellEventArgs e) {
            if( e.RowIndex < 0 ) return;

            string username = dgvUsers.Rows[e.RowIndex].Cells["colUsername"].Value.ToString ();

            // Xử lý Xóa
            if( e.ColumnIndex == dgvUsers.Columns["colDelete"].Index )
            {
                DialogResult dr = MessageBox.Show ($"Bạn có chắc chắn muốn vô hiệu hóa tài khoản '{username}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if( dr == DialogResult.Yes )
                {
                    if( _userController.DeleteUser (username) )
                    {
                        MessageBox.Show ("Đã vô hiệu hóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData ();
                    }
                    else
                    {
                        MessageBox.Show ("Không thể vô hiệu hóa tài khoản này (có thể là tài khoản của chính bạn)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Xử lý Sửa
            else if( e.ColumnIndex == dgvUsers.Columns["colEdit"].Index )
            {
                var user = _userController.GetUserByUsername (username);
                if( user != null )
                {
                    Frm_SuaTaiKhoan frm = new Frm_SuaTaiKhoan (user);
                    if( frm.ShowDialog () == DialogResult.OK )
                    {
                        LoadData ();
                    }
                }
            }
        }

        private void Frm_TaiKhoan_Load (object sender, EventArgs e) {
            LoadData ();
            InitFilters();
        }

        private void btnThemUser_Click (object sender, EventArgs e) {
            Frm_ThemTaiKhoan frm = new Frm_ThemTaiKhoan ();
            if( frm.ShowDialog () == DialogResult.OK )
            {
                LoadData (); // Refresh list
            }
        }

        private void LoadData () {
            _allUsers = _userController.GetUserList ();
            DisplayUsers (_allUsers);
        }

        private void DisplayUsers (List<User> users) {
            dgvUsers.Rows.Clear ();
            foreach( var user in users )
            {
                dgvUsers.Rows.Add (
                    null, // Avatar placeholder
                    user.Username,
                    user.FullName ?? "---",
                    user.Email ?? "---",
                    user.Role ?? "Nhân viên",
                    user.Status ? "Hoạt động" : "Đã khóa",
                    user.CreatedAt?.ToString ("dd/MM/yyyy HH:mm") ?? "---",
                    null, // Edit icon placeholder
                    null  // Delete icon placeholder
                );
            }
        }

        private void txtSearch_TextChanged (object sender, EventArgs e) {
            string keyword = txtSearch.Text.Trim ();
            var filtered = _userController.SearchUsers (keyword);
            DisplayUsers (filtered);
            ApplyFilter(sender, e);
        }

        private void dgvUsers_CellPainting (object sender, DataGridViewCellPaintingEventArgs e) {
            if( e.RowIndex < 0 ) return;

            // 1. Vẽ Avatar
            if( e.ColumnIndex == dgvUsers.Columns["colAvatar"].Index )
            {
                e.Paint (e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                var rect = e.CellBounds;
                int size = 32;
                var iconRect = new Rectangle (rect.X + (rect.Width - size) / 2, rect.Y + (rect.Height - size) / 2, size, size);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using( var brush = new SolidBrush (Color.FromArgb (242, 245, 250)) )
                {
                    e.Graphics.FillEllipse (brush, iconRect);
                }

                // Vẽ chữ cái đầu của Username làm avatar
                string initial = dgvUsers.Rows[e.RowIndex].Cells["colUsername"].Value.ToString ().Substring (0, 1).ToUpper ();
                using( var font = new Font ("Segoe UI", 10, FontStyle.Bold) )
                {
                    var textSize = e.Graphics.MeasureString (initial, font);
                    e.Graphics.DrawString (initial, font, Brushes.Gray,
                        iconRect.X + (size - textSize.Width) / 2,
                        iconRect.Y + (size - textSize.Height) / 2);
                }
                e.Handled = true;
            }

            // 2. Vẽ Badge cho Vai trò
            if( e.ColumnIndex == dgvUsers.Columns["colRole"].Index && e.Value != null )
            {
                e.Paint (e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                string role = e.Value.ToString ();
                Color backColor = role == "Admin" ? Color.FromArgb (243, 231, 255) : Color.FromArgb (232, 240, 254);
                Color textColor = role == "Admin" ? Color.FromArgb (147, 51, 234) : Color.FromArgb (37, 99, 235);

                DrawBadge (e.Graphics, e.CellBounds, role, backColor, textColor);
                e.Handled = true;
            }

            // 3. Vẽ Badge cho Trạng thái
            if( e.ColumnIndex == dgvUsers.Columns["colStatus"].Index && e.Value != null )
            {
                e.Paint (e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                string status = e.Value.ToString ();
                Color backColor = status == "Hoạt động" ? Color.FromArgb (220, 252, 231) : Color.FromArgb (254, 226, 226);
                Color textColor = status == "Hoạt động" ? Color.FromArgb (22, 163, 74) : Color.FromArgb (220, 38, 38);

                DrawBadge (e.Graphics, e.CellBounds, status, backColor, textColor);
                e.Handled = true;
            }

            // 4. Vẽ Action Icons (Sửa/Xóa)
            if( e.ColumnIndex == dgvUsers.Columns["colEdit"].Index || e.ColumnIndex == dgvUsers.Columns["colDelete"].Index )
            {
                e.Paint (e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                Image icon = e.ColumnIndex == dgvUsers.Columns["colEdit"].Index
                    ? Properties.Resources.pen
                    : Properties.Resources.icons8_trash_can_50;

                if( icon != null )
                {
                    // Tính toán kích thước icon adaptive: tối đa 24px hoặc 40% chiều cao cell
                    int iconSize = Math.Min (24, (int) (e.CellBounds.Height * 0.45));
                    int x = e.CellBounds.X + (e.CellBounds.Width - iconSize) / 2;
                    int y = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.DrawImage (icon, new Rectangle (x, y, iconSize, iconSize));
                }

                e.Handled = true;
            }
        }

        private void DrawBadge (Graphics g, Rectangle cellBounds, string text, Color backColor, Color textColor) {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using( var font = new Font ("Segoe UI", 8.5F, FontStyle.Bold) )
            {
                var textSize = g.MeasureString (text, font);
                int paddingH = 12;
                int paddingV = 4;
                var badgeRect = new Rectangle (
                    cellBounds.X + 10,
                    cellBounds.Y + (cellBounds.Height - (int) textSize.Height - paddingV * 2) / 2,
                    (int) textSize.Width + paddingH * 2,
                    (int) textSize.Height + paddingV * 2
                );

                using( var brush = new SolidBrush (backColor) )
                {
                    FillRoundedRectangle (g, brush, badgeRect, 6);
                }

                g.DrawString (text, font, new SolidBrush (textColor),
                    badgeRect.X + paddingH, badgeRect.Y + paddingV);
            }
        }

        private void FillRoundedRectangle (Graphics g, Brush brush, Rectangle rect, int radius) {
            using( var path = new GraphicsPath () )
            {
                path.AddArc (rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                path.AddArc (rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                path.AddArc (rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc (rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseFigure ();
                g.FillPath (brush, path);
            }
        }

        private void InitFilters()
        {
            cboLocChucVu.Items.Clear();
            cboLocChucVu.Items.AddRange(new[] { "Tất cả chức vụ", "Admin", "Staff" });
            cboLocChucVu.SelectedIndex = 0;

            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.AddRange(new[] { "Tất cả trạng thái", "Hoạt động", "Đã khóa" });
            cboLocTrangThai.SelectedIndex = 0;

            cboLocNgayTao.Items.Clear();
            cboLocNgayTao.Items.AddRange(new[] { "Tất cả ngày", "Hôm nay", "7 ngày qua", "30 ngày qua" });
            cboLocNgayTao.SelectedIndex = 0;
        }

        private void ApplyFilter(object sender, EventArgs e)
        {
            string chucVu = cboLocChucVu.SelectedItem?.ToString();
            string trangThai = cboLocTrangThai.SelectedItem?.ToString();
            string ngayTao = cboLocNgayTao.SelectedItem?.ToString();
            string keyword = txtSearch.Text.Trim();

            var result = _userController.SearchUsers(keyword);

            if (chucVu != "Tất cả chức vụ" && chucVu != null)
                result = result.FindAll(u => u.Role == chucVu);

            if (trangThai != "Tất cả trạng thái" && trangThai != null)
            {
                result = result.FindAll(u => {
                    string trangThaiUser = "Đã khóa";
                    if (u.Status) trangThaiUser = "Hoạt động";
                    return trangThaiUser == trangThai;
                });
            }

            if (ngayTao != "Tất cả ngày" && ngayTao != null)
            {
                DateTime fromDate = DateTime.Now;
                if (ngayTao == "Hôm nay") fromDate = DateTime.Today;
                if (ngayTao == "7 ngày qua") fromDate = DateTime.Now.AddDays(-7);
                if (ngayTao == "30 ngày qua") fromDate = DateTime.Now.AddDays(-30);

                result = result.FindAll(u => u.CreatedAt.HasValue && u.CreatedAt.Value >= fromDate);
            }

            DisplayUsers(result);
        }
    }
}
