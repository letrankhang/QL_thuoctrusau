using Guna.UI2.WinForms;
using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_LoHang : Form
    {
        BatchController controller = new BatchController();
        BatchExportBUS exportBUS = new BatchExportBUS();
        private Guna2Button btnDangChon = null;
        private string trangThaiDangChon = "Tất cả";

        public Frm_LoHang()
        {
            InitializeComponent();
        }

        private void Frm_LoHang_Load(object sender, EventArgs e)
        {
            dgvLoHang.AutoGenerateColumns = false;
            btnTrangThai.Visible = false;
            lblDangChon.Text = "---";
            khoiTaoMauBtn();

            cboLocTheoSP.SelectedIndexChanged -= cboLocTheoSP_SelectedIndexChanged;
            cboLocTheoNCC.SelectedIndexChanged -= cboLocTheoNCC_SelectedIndexChanged;

            loadCboSanPham();
            loadCboNhaCungCap();

            cboLocTheoSP.SelectedIndexChanged += cboLocTheoSP_SelectedIndexChanged;
            cboLocTheoNCC.SelectedIndexChanged += cboLocTheoNCC_SelectedIndexChanged;

            taiDuLieu();
            chonBtn(btnTatCa);
        }

        private void khoiTaoMauBtn()
        {
            // Tham khảo màu HTML
            btnTatCa.FillColor = ColorTranslator.FromHtml("#E9ECEF");
            btnTatCa.ForeColor = ColorTranslator.FromHtml("#495057");
            btnTatCa.BorderColor = ColorTranslator.FromHtml("#CED4DA");
            btnTatCa.BorderThickness = 1;

            btnConHan.FillColor = ColorTranslator.FromHtml("#D4EDDA");
            btnConHan.ForeColor = ColorTranslator.FromHtml("#155724");
            btnConHan.BorderColor = ColorTranslator.FromHtml("#B8DAC6");
            btnConHan.BorderThickness = 1;

            btnGanHet.FillColor = ColorTranslator.FromHtml("#FFF3CD");
            btnGanHet.ForeColor = ColorTranslator.FromHtml("#856404");
            btnGanHet.BorderColor = ColorTranslator.FromHtml("#FDE68A");
            btnGanHet.BorderThickness = 1;

            btnHetHan.FillColor = ColorTranslator.FromHtml("#F8D7DA");
            btnHetHan.ForeColor = ColorTranslator.FromHtml("#721C24");
            btnHetHan.BorderColor = ColorTranslator.FromHtml("#F0AAB5");
            btnHetHan.BorderThickness = 1;
        }

        private void loadCboSanPham()
        {
            var danhSach = controller.layDanhSachSanPham();
            danhSach.Insert(0, new Product { ProductID = -1, Name = "Tất cả sản phẩm" });
            cboLocTheoSP.DataSource = danhSach;
            cboLocTheoSP.DisplayMember = "Name";
            cboLocTheoSP.ValueMember = "ProductID";
            cboLocTheoSP.SelectedIndex = 0;
            cboLocTheoSP.DropDownWidth = 200;
        }

        private void loadCboNhaCungCap()
        {
            var danhSach = controller.layDanhSachNhaCungCap();
            danhSach.Insert(0, new Supplier { SupplierID = -1, Name = "Tất cả NCC" });
            cboLocTheoNCC.DataSource = danhSach;
            cboLocTheoNCC.DisplayMember = "Name";
            cboLocTheoNCC.ValueMember = "SupplierID";
            cboLocTheoNCC.SelectedIndex = 0;
            cboLocTheoNCC.DropDownWidth = 400;
        }

        private void taiDuLieu()
        {
            int productID = ((Product)cboLocTheoSP.SelectedItem).ProductID;
            int supplierID = ((Supplier)cboLocTheoNCC.SelectedItem).SupplierID;

            List<BatchViewModel> danhSach = controller.layDanhSachTheoFilter(productID, supplierID, trangThaiDangChon);
            dgvLoHang.DataSource = null;
            dgvLoHang.DataSource = danhSach;
            lblTongLoHang.Text = danhSach.Count.ToString();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTim.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                taiDuLieu();
                return;
            }
            int productID = ((Product)cboLocTheoSP.SelectedItem).ProductID;
            int supplierID = ((Supplier)cboLocTheoNCC.SelectedItem).SupplierID;
            List<BatchViewModel> danhSach = controller.timKiem(keyword);
            dgvLoHang.DataSource = null;
            dgvLoHang.DataSource = danhSach;
            lblTongLoHang.Text = danhSach.Count.ToString();
        }

        private void cboLocTheoSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            taiDuLieu();
        }

        private void cboLocTheoNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            taiDuLieu();
        }

        private void chonBtn(Guna2Button btn)
        {
            khoiTaoMauBtn();
            btn.BorderThickness = 2;
            btn.BorderColor = btn.ForeColor;

            btnDangChon = btn;
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            trangThaiDangChon = "Tất cả";
            chonBtn(btnTatCa);
            taiDuLieu();
        }

        private void btnConHan_Click(object sender, EventArgs e)
        {
            trangThaiDangChon = "Còn hạn";
            chonBtn(btnConHan);
            taiDuLieu();
        }

        private void btnGanHet_Click(object sender, EventArgs e)
        {
            trangThaiDangChon = "Sắp hết hạn";
            chonBtn(btnGanHet);
            taiDuLieu();
        }

        private void btnHetHan_Click(object sender, EventArgs e)
        {
            trangThaiDangChon = "Hết hạn";
            chonBtn(btnHetHan);
            taiDuLieu();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = $"BaoCaoLoHang_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Lấy các giá trị lọc hiện tại trên Form
                        int productID = ((Product)cboLocTheoSP.SelectedItem).ProductID;
                        int supplierID = ((Supplier)cboLocTheoNCC.SelectedItem).SupplierID;

                        // Gọi BUS thực hiện quy trình xuất
                        exportBUS.ExportBatches(sfd.FileName, productID, supplierID, trangThaiDangChon);

                        MessageBox.Show("Xuất báo cáo Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            trangThaiDangChon = "Tất cả";
            cboLocTheoSP.SelectedIndex = 0;
            cboLocTheoNCC.SelectedIndex = 0;
            txtTim.Clear();
            chonBtn(btnTatCa);
            taiDuLieu();
            xoaChiTiet();
            btnTrangThai.Visible = false;
            lblDangChon.Text = "---";

        }

        private void dgvLoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLoHang.Rows[e.RowIndex];

            lblMaLo.Text = row.Cells[0].Value?.ToString();
            lblTenSP.Text = row.Cells[1].Value?.ToString();
            lblBienThe.Text = row.Cells[2].Value?.ToString();
            lblNCC.Text = row.Cells[3].Value?.ToString();
            lblGiaNhap.Text = string.Format("{0:N0} đ", row.Cells[4].Value);
            lblSLBanDau.Text = row.Cells[5].Value?.ToString();
            lblSLConLai.Text = row.Cells[6].Value?.ToString();
            lblNSX.Text = string.Format("{0:dd/MM/yyyy}", row.Cells[7].Value);
            lblHSD.Text = string.Format("{0:dd/MM/yyyy}", row.Cells[8].Value);

            string trangThai = row.Cells[9].Value?.ToString();
            hienThiTrangThai(trangThai);

            lblDangChon.Text = row.Cells[0].Value + " - " + row.Cells[1].Value;
        }

        private void hienThiTrangThai(string trangThai)
        {
            btnTrangThai.Visible = true;
            btnTrangThai.Text = trangThai;

            if (trangThai == "Hết hạn")
            {
                btnTrangThai.FillColor = ColorTranslator.FromHtml("#F8D7DA");
                btnTrangThai.ForeColor = ColorTranslator.FromHtml("#721C24");
                btnTrangThai.BorderColor = ColorTranslator.FromHtml("#F0AAB5");
            }
            else if (trangThai == "Sắp hết hạn")
            {
                btnTrangThai.FillColor = ColorTranslator.FromHtml("#FFF3CD");
                btnTrangThai.ForeColor = ColorTranslator.FromHtml("#856404");
                btnTrangThai.BorderColor = ColorTranslator.FromHtml("#FDE68A");
            }
            else if (trangThai == "Còn hạn")
            {
                btnTrangThai.FillColor = ColorTranslator.FromHtml("#D4EDDA");
                btnTrangThai.ForeColor = ColorTranslator.FromHtml("#155724");
                btnTrangThai.BorderColor = ColorTranslator.FromHtml("#B8DAC6");
            }
            else
            {
                btnTrangThai.FillColor = ColorTranslator.FromHtml("#D4EDDA");
                btnTrangThai.ForeColor = ColorTranslator.FromHtml("#155724");
                btnTrangThai.BorderColor = ColorTranslator.FromHtml("#B8DAC6");
            }
        }

        private void xoaChiTiet()
        {
            lblMaLo.Text = "...";
            lblTenSP.Text = "...";
            lblBienThe.Text = "...";
            lblNCC.Text = "...";
            lblGiaNhap.Text = "...";
            lblSLBanDau.Text = "...";
            lblSLConLai.Text = "...";
            lblNSX.Text = "...";
            lblHSD.Text = "...";
            btnTrangThai.Visible = false;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
