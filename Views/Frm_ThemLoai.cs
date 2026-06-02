using QL_CuaHangBanThuocTruSau.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_ThemLoai : Form
    {
        private CategoryController controller = new CategoryController();
        int maDangChon = 0;

        public Frm_ThemLoai()
        {
            InitializeComponent();
            taiDuLieu();
        }

        public void taiDuLieu()
        {
            dgvLoai.DataSource = null;
            dgvLoai.DataSource = controller.layDanhSachLoai();

            if (dgvLoai.Columns.Count > 0)
            {
                dgvLoai.Columns[0].HeaderText = "Mã loại";
                dgvLoai.Columns[0].Width = 80;
                dgvLoai.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvLoai.Columns[1].HeaderText = "Tên loại";
                dgvLoai.Columns[1].Width = 150;
                dgvLoai.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvLoai.Columns[2].HeaderText = "Mô tả";
                dgvLoai.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvLoai.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                if (dgvLoai.Columns.Count > 3)
                {
                    for (int i = 3; i < dgvLoai.Columns.Count; i++)
                    {
                        dgvLoai.Columns[i].Visible = false;
                    }    
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!kiemTraHopLe(laThemMoi: true))
            {
                return;
            }

            if (controller.themMoiLoai(txtTenLoai.Text, txtMoTa.Text))
            {
                MessageBox.Show("Thêm loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lamMoi();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn loại cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!kiemTraHopLe(laThemMoi: false))
            {
                return;
            }

            if (controller.capNhatLoai(maDangChon, txtTenLoai.Text, txtMoTa.Text))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lamMoi();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn loại cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var xacNhan = MessageBox.Show("Bạn có chắc muốn xóa loại này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes) 
                return;

            if (controller.xoaLoai(maDangChon))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lamMoi();
            }
            else
            {
                MessageBox.Show("Xóa thất bại! Có thể loại này đang được sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lamMoi();
        }

        public void lamMoi()
        {
            txtMaLoai.Enabled = true;   
            txtMaLoai.Clear();         
            txtMaLoai.Enabled = false;
            dgvLoai.ClearSelection();
            dgvLoai.CurrentCell = null;
            txtTenLoai.Clear();
            txtMoTa.Clear();
            maDangChon = 0; 
            txtTenLoai.Focus();
            taiDuLieu();
        }

        private bool kiemTraHopLe(bool laThemMoi = true)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return false;
            }

            int boQuaMa = 0;
            if (!laThemMoi)
            {
                boQuaMa = maDangChon;
            }
                
            if (!controller.kiemTraTenHopLe(txtTenLoai.Text.Trim(), boQuaMa))
            {
                MessageBox.Show("Tên loại đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return false;
            }

            return true;
        }

        public void dgvLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = dgvLoai.Rows[e.RowIndex];

            maDangChon = Convert.ToInt32(row.Cells[0].Value);
            txtMaLoai.Text = maDangChon.ToString();
            txtTenLoai.Text = row.Cells[1].Value.ToString();

            if (row.Cells[2].Value != null)
            {
                txtMoTa.Text = row.Cells[2].Value.ToString();
            }
            else
            {
                txtMoTa.Text = "";
            }    
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_ThemLoai_Load(object sender, EventArgs e)
        {
            dgvLoai.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);
        }
    }
}
