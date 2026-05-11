using Guna.UI2.WinForms;
using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_TRANGCHU : Form
    {
        LogoutController _logoutController;
        private System.Windows.Forms.Timer clock;
        public Frm_TRANGCHU()
        {
            InitializeComponent();
            _logoutController = new LogoutController();
            this.FormClosed += Frm_TRANGCHU_FormClosed;
        }

        private void Frm_TRANGCHU_Load(object sender, EventArgs e)
        {
            UpdateUserInfo();
            ApplyPermissions();

            // Nếu là Admin thì mở Dashboard, ngược lại mở Quản lý Sản phẩm
            if (SessionManager.IsAdmin())
            {
                SetActiveButton(btnTongQuan);
                OpenChildForm(new Dashboard(), "TỔNG QUAN");
            }
            else
            {
                SetActiveButton(btnSanPham);
                OpenChildForm(new Frm_SanPham(), "QUẢN LÝ SẢN PHẨM");
            }

            clock = new System.Windows.Forms.Timer();
            clock.Interval = 1000;
            clock.Tick += (s, ev) => lblGreeting.Text = FormatGreeting();
            clock.Start();
        }

        private void ApplyPermissions()
        {
            if (!SessionManager.IsAdmin())
            {
                btnTongQuan.Visible = false;
                btnTaiKhoan.Visible = false;
            }
        }
        private void SetActiveButton(Guna2Button btn)
        {
            Guna2Button[] buttons = { btnTongQuan, btnBanHang, btnNhapHang, btnLoHang, btnSanPham, btnNCC, btnKhachHang, btnCongNo, btnTaiKhoan };
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].FillColor = Color.FromArgb(250, 250, 250);
                buttons[i].ForeColor = Color.Black;
                buttons[i].BorderThickness = 1;
                buttons[i].BorderColor = Color.White;
                buttons[i].HoverState.FillColor = Color.FromArgb(240, 240, 240);
                buttons[i].HoverState.ForeColor = Color.Black;
            }
            btn.FillColor = Color.SteelBlue;
            btn.ForeColor = Color.White;
            btn.BorderThickness = 1;
            btn.BorderColor = Color.SteelBlue;
            btn.HoverState.FillColor = Color.SteelBlue;
            btn.HoverState.ForeColor = Color.White;
        }
        private string FormatGreeting()
        {
            System.Globalization.CultureInfo vi = new System.Globalization.CultureInfo("vi-VN");
            return DateTime.Now.ToString("HH:mm:ss | dddd, dd/MM/yyyy", vi) + "  |  Xin chào, "
                + SessionManager.CurrentUser.FullName
                + " (" + SessionManager.CurrentUser.Role + ")";
        }

        private void UpdateUserInfo()
        {
            if (SessionManager.IsLoggedIn)
            {
                lblGreeting.Text = FormatGreeting();
                veAvatar(SessionManager.CurrentUser.FullName, SessionManager.CurrentUser.Role);
            }
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm, string title)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            lblInterfaceName.Text = title;
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsAdmin()) return;
            SetActiveButton(btnTaiKhoan);
            OpenChildForm(new Frm_TaiKhoan(), "QUẢN LÝ TÀI KHOẢN");
        }

        private void Frm_TRANGCHU_FormClosed(object sender, FormClosedEventArgs e)
        {
            clock?.Stop();
            clock?.Dispose();

            if (!isLoggingOut)
            {
                Application.Exit();
            }
        }

        private bool isLoggingOut = false;

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (_logoutController.HandleLogout())
                {
                    isLoggingOut = true;
                    Frm_DANGNHAP loginForm = new Frm_DANGNHAP();
                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra khi đăng xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsAdmin()) return;
            SetActiveButton(btnTongQuan);
            OpenChildForm(new Dashboard(), "TỔNG QUAN");
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnSanPham);
            OpenChildForm(new Frm_SanPham(), "QUẢN LÝ SẢN PHẨM");
        }

        private void btnLoHang_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnLoHang);
            OpenChildForm(new Frm_LoHang(), "QUẢN LÝ LÔ HÀNG");
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnNCC);
            OpenChildForm(new Frm_NCC(), "QUẢN LÝ NHÀ CUNG CẤP");
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnBanHang);
            OpenChildForm(new Frm_BanHang(), "BÁN HÀNG");
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnNhapHang);
            OpenChildForm(new Frm_NhapHang(), "NHẬP HÀNG");

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnKhachHang);
            OpenChildForm(new Frm_KhachHang(), "QUẢN LÝ KHÁCH HÀNG");
        }

        private void btnCongNo_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnCongNo);
            OpenChildForm(new Frm_CongNo(), "QUẢN LÝ CÔNG NỢ");
        }

        private void veAvatar(string hoTen, string role)
        {
            string chu = hoTen.Trim().Split(' ')[hoTen.Trim().Split(' ').Length - 1][0].ToString().ToUpper();
            Color bgColor = role == "Admin" ? Color.SteelBlue : Color.MediumSeaGreen;

            Bitmap bmp = new Bitmap(pb_Avatar.Width, pb_Avatar.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.FillEllipse(new SolidBrush(bgColor), 0, 0, pb_Avatar.Width - 1, pb_Avatar.Height - 1);

                Font font = new Font("Segoe UI", pb_Avatar.Width / 3f, FontStyle.Bold);
                SizeF size = g.MeasureString(chu, font);
                g.DrawString(chu, font, Brushes.White,(pb_Avatar.Width - size.Width) / 2f, (pb_Avatar.Height - size.Height) / 2f);
            }
            pb_Avatar.Image = bmp;
            pb_Avatar.Region = new Region(new System.Drawing.Drawing2D.GraphicsPath());

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pb_Avatar.Width - 1, pb_Avatar.Height - 1);
            pb_Avatar.Region = new Region(path);
        }
    }
}

