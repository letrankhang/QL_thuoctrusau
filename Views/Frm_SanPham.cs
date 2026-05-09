using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_SanPham : Form
    {
        ProductController controller = new ProductController();

        private string maDangChon = "";
        private string duongDanAnh = "";

        public Frm_SanPham()
        {
            InitializeComponent();
        }

        private void Frm_SanPham_Load(object sender, EventArgs e)
        {
            btnXoaAnh.Visible = false;
            dgvSanPham.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colImagePath = new DataGridViewTextBoxColumn();
            colImagePath.DataPropertyName = "ImagePath";
            colImagePath.Name = "colImagePath";
            colImagePath.Visible = false;
            dgvSanPham.Columns.Add(colImagePath);

            loadDanhSach();
            loadLoai();

            cboLocChuCai.DataSource = new List<string> { "Sắp xếp theo tên", "A đến Z", "Z đến A" };
            cboLocChuCai.SelectedIndex = 0;
            cboLocChuCai.SelectedIndexChanged += (s, ev) => locTheoChuCai();
            cboLocTheoLoai.SelectedIndexChanged += (s, ev) => locTheoLoai();
        }

        public void loadLoai()
        {
            var danhSachLoai = controller.LayDanhSachLoai();

            danhSachLoai.Insert(0, new Category { CategoryID = -1, Name = "-- Chọn loại --" });

            cboLoai.DataSource = danhSachLoai;
            cboLoai.DisplayMember = "Name";
            cboLoai.ValueMember = "CategoryID";
            cboLoai.SelectedIndex = 0;

            var danhSachLoc = controller.LayDanhSachLoai();
            danhSachLoc.Insert(0, new Category { CategoryID = -1, Name = "Tất cả các loại" });

            cboLocTheoLoai.DataSource = danhSachLoc;
            cboLocTheoLoai.DisplayMember = "Name";
            cboLocTheoLoai.ValueMember = "CategoryID";
            cboLocTheoLoai.SelectedIndex = 0;
        }
        public void locTheoChuCai()
        {
            string chon = cboLocChuCai.SelectedItem?.ToString();
            var danhSach = controller.LayDanhSach();

            if (chon == "A đến Z")
            {
                dgvSanPham.DataSource = danhSach.OrderBy(sp => sp.Name).ToList();
            }
            else if (chon == "Z đến A")
            {
                dgvSanPham.DataSource = danhSach.OrderByDescending(sp => sp.Name).ToList();
            }   
            else
            {
                dgvSanPham.DataSource = danhSach;
            }
                
            lblTongSP.Text = dgvSanPham.Rows.Count.ToString();
        }

        public void locTheoLoai()
        {
            int loaiId = (int)cboLocTheoLoai.SelectedValue;

            dgvSanPham.DataSource = controller.LocTheoLoai(loaiId);

            lblTongSP.Text = dgvSanPham.Rows.Count.ToString();
        }

        public void loadDanhSach()
        {
            dgvSanPham.DataSource = controller.LayDanhSach();
            lblTongSP.Text = dgvSanPham.Rows.Count.ToString();

            dgvSanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null)
            {
                return;
            }

            var row = dgvSanPham.CurrentRow;

            maDangChon = row.Cells[0].Value?.ToString(); 
            txtMaSP.Text = row.Cells[0].Value?.ToString();
            txtTenSP.Text = row.Cells[1].Value?.ToString();
            cboLoai.SelectedValue = row.Cells[2].Value;
            txtMoTa.Text = row.Cells[3].Value?.ToString();
            txtMaSP.Enabled = false;

            duongDanAnh = row.Cells["colImagePath"].Value?.ToString();
            if (!string.IsNullOrEmpty(duongDanAnh) && File.Exists(duongDanAnh))
            {
                picAnhSP.Image = Image.FromFile(duongDanAnh);
                picAnhSP.SizeMode = PictureBoxSizeMode.Zoom;
                lblNoImage.Visible = false;
                btnXoaAnh.Visible = true;
            }
            else
            {
                picAnhSP.Image = null;
                lblNoImage.Visible = true;
                btnXoaAnh.Visible = false;
            }

            lblDangChon.Text = row.Cells[0].Value + " - " + row.Cells[1].Value;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaSP.Text, out int productId) || productId <= 0)
            {
                MessageBox.Show("Mã sản phẩm phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product sp = new Product
            {
                ProductID = productId,            
                Name = txtTenSP.Text,
                CategoryID = (int)cboLoai.SelectedValue,
                Description = txtMoTa.Text,
                ImagePath = duongDanAnh
            };

            string loi = "";
            if (controller.Them(sp, out loi))
            {
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhSach();
                lamMoi();
            }
            else
            {
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maDangChon))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product sp = new Product
            {
                ProductID = int.Parse(maDangChon),
                Name = txtTenSP.Text,
                CategoryID = (int)cboLoai.SelectedValue,
                Description = txtMoTa.Text,
                ImagePath = duongDanAnh
            };

            string loi = "";
            if (controller.Sua(sp, out loi))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhSach();
                lamMoi();
            }
            else
            {
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maDangChon))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var xacNhan = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan == DialogResult.No)
            {
                return;
            }

            string loi = "";
            if (controller.Xoa(int.Parse(maDangChon), out loi))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhSach();
                lamMoi();
            }
            else
            {
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lamMoi()
        {
            maDangChon = "";
            duongDanAnh = "";
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtMoTa.Text = "";
            cboLoai.SelectedIndex = 0;
            txtMaSP.Enabled = true;
            picAnhSP.Image = null;
            lblNoImage.Visible = true;
            btnXoaAnh.Visible = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lamMoi();
            dgvSanPham.ClearSelection();
            dgvSanPham.CurrentCell = null;
            lblDangChon.Text = "---";
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTim.Text.Trim();
            dgvSanPham.DataSource = controller.TimKiem(keyword);
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Chọn ảnh sản phẩm";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                duongDanAnh = ofd.FileName;
                picAnhSP.Image = Image.FromFile(duongDanAnh);   
                picAnhSP.SizeMode = PictureBoxSizeMode.Zoom;
                lblNoImage.Visible = false;
                btnXoaAnh.Visible = true;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = $"DanhSachSanPhamChiTiet_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Lấy toàn bộ danh sách kèm biến thể từ DB
                        var allProducts = controller.LayDanhSachKemBienThe();

                        // Lấy danh sách ID sản phẩm đang hiển thị trên DGV (đã qua lọc/tìm kiếm)
                        var visibleProductIDs = new HashSet<int>();
                        foreach (DataGridViewRow row in dgvSanPham.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                visibleProductIDs.Add(Convert.ToInt32(row.Cells[0].Value));
                            }
                        }

                        // Lọc danh sách chi tiết theo những gì đang hiển thị
                        var filteredData = allProducts.Where(p => visibleProductIDs.Contains(p.ProductID)).ToList();

                        ExcelHelper.XuatExcelSanPhamChiTiet(filteredData, sfd.FileName);
                        MessageBox.Show("Xuất file Excel chi tiết sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper.NhapExcel(new ProductBUS());
            loadDanhSach();
        }

        private void btnXuatReport_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            Frm_ThemLoai loai = new Frm_ThemLoai();
            loai.ShowDialog();
            loadLoai();
        }

        private void btnBienThe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maDangChon))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSP = int.Parse(maDangChon);
            Frm_BienTheSP bienTheSP = new Frm_BienTheSP(maSP);
            bienTheSP.ShowDialog();
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            duongDanAnh = "";
            picAnhSP.Image = null;
            lblNoImage.Visible = true;
            btnXoaAnh.Visible = false;
        }
    }
}
