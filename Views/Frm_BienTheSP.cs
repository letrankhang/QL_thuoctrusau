using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_BienTheSP : Form
    {
        ProductVariantController controller = new ProductVariantController();
        private int maSanPham = 0;
        public Frm_BienTheSP(int maSP)
        {
            InitializeComponent();
            maSanPham = maSP;
        }

        private void Frm_BienTheSP_Load(object sender, EventArgs e)
        {
            khoiTaoDonViTinh();
            txtMaSP.Text = maSanPham.ToString();
            taiDuLieu();
        }

        private void khoiTaoDonViTinh()
        {
            cboDonViTinh.Items.Clear();
            cboDonViTinh.Items.AddRange(new string[]
            {
                "Chọn đơn vị", "Chai", "Gói", "Lít", "Thùng", "Hộp", "Bình"
            });
            cboDonViTinh.SelectedIndex = 0;
        }

        private void taiDuLieu()
        {
            List<ProductVariant> danhSach = controller.layDanhSachTheoSP(maSanPham);
            dgvBienThe.DataSource = null;
            dgvBienThe.DataSource = danhSach;

            if (dgvBienThe.Columns.Count > 0)
            {
                dgvBienThe.Columns["VariantID"].HeaderText = "Mã biến thể";
                dgvBienThe.Columns["ProductID"].HeaderText = "Mã sản phẩm";
                dgvBienThe.Columns["Unit"].HeaderText = "Đơn vị";
                dgvBienThe.Columns["Concentration"].HeaderText = "Hàm lượng";
                dgvBienThe.Columns["RetailPrice"].HeaderText = "Giá bán lẻ";
                dgvBienThe.Columns["WholesalePrice"].HeaderText = "Giá bán sỉ";

                string[] cotHienThi = { "VariantID", "ProductID", "Unit", "Concentration", "RetailPrice", "WholesalePrice" };

                for (int i = 0; i < dgvBienThe.Columns.Count; i++)
                {
                    bool laCotCanHien = false;
                    for (int j = 0; j < cotHienThi.Length; j++)
                    {
                        if (dgvBienThe.Columns[i].Name == cotHienThi[j])
                        {
                            laCotCanHien = true;
                            break;
                        }
                    }
                    dgvBienThe.Columns[i].Visible = laCotCanHien;
                }

                dgvBienThe.Columns["VariantID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBienThe.Columns["ProductID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBienThe.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBienThe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Seminbold", 9f);
                dgvBienThe.Columns["RetailPrice"].DefaultCellStyle.Format = "N0";
                dgvBienThe.Columns["WholesalePrice"].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboDonViTinh.SelectedIndex == 0 || cboDonViTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ketQua = controller.them(
                maSanPham,
                cboDonViTinh.Text,
                txtHamLuong.Text,
                txtGiaBanLe.Text,
                txtGiaBanSi.Text
            );

            if (ketQua)
            {
                MessageBox.Show("Thêm biến thể thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lamMoi();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtMaBienThe.Text))
            {
                MessageBox.Show("Vui lòng chọn biến thể cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboDonViTinh.SelectedIndex == 0 || cboDonViTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool layMa = int.TryParse(txtMaBienThe.Text, out int maVariant);
            if (!layMa)
            {
                MessageBox.Show("Mã biến thể không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ketQua = controller.sua(
                maVariant,
                maSanPham,
                cboDonViTinh.Text,
                txtHamLuong.Text,
                txtGiaBanLe.Text,
                txtGiaBanSi.Text
            );

            if (ketQua)
            {
                MessageBox.Show("Cập nhật biến thể thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lamMoi();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBienThe.Text))
            {
                MessageBox.Show("Vui lòng chọn biến thể cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool layMa = int.TryParse(txtMaBienThe.Text, out int maVariant);
            if (!layMa) return;

            bool ketQua = controller.xoa(maVariant);
            if (ketQua)
            {
                MessageBox.Show("Xóa biến thể thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lamMoi();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lamMoi();
        }

        private void dgvBienThe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvBienThe.Rows[e.RowIndex];
            txtMaBienThe.Text = row.Cells["VariantID"].Value.ToString();
            txtMaSP.Text = row.Cells["ProductID"].Value.ToString();
            cboDonViTinh.Text = row.Cells["Unit"].Value.ToString();
            txtHamLuong.Text = row.Cells["Concentration"].Value.ToString();
            txtGiaBanLe.Text = row.Cells["RetailPrice"].Value.ToString();
            txtGiaBanSi.Text = row.Cells["WholesalePrice"].Value.ToString();

            txtGiaBanLe.Text = string.Format("{0:N0}", row.Cells["RetailPrice"].Value);
            txtGiaBanSi.Text = string.Format("{0:N0}", row.Cells["WholesalePrice"].Value);
        }

        private void lamMoi()
        {
            txtMaBienThe.Enabled = true;
            txtMaBienThe.Clear();
            txtMaBienThe.Enabled = false;
            txtMaSP.Text = maSanPham.ToString();
            cboDonViTinh.SelectedIndex = 0;
            txtHamLuong.Clear();
            txtGiaBanLe.Clear();
            txtGiaBanSi.Clear();
            taiDuLieu();
        }
    }
}
