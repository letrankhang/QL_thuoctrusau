using QL_CuaHangBanThuocTruSau.Controllers;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_NCC : Form
    {
        SuppliersController controller = new SuppliersController();
        private int maDangChon = 0;

        public Frm_NCC()
        {
            InitializeComponent();
        }

        public void loadDanhSach()
        {
            dgvNCC.DataSource = controller.LayDanhSach();
            lblTongNCC.Text = dgvNCC.Rows.Count.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Frm_ThemNCC frmThem = new Frm_ThemNCC();
            if (frmThem.ShowDialog() == DialogResult.OK)
            {
                loadDanhSach();
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (dgvNCC.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvNCC.CurrentRow;
            Supplier ncc = new Supplier
            {
                SupplierID = Convert.ToInt32(row.Cells[0].Value),
                Name = row.Cells[1].Value?.ToString(),
                Phone = row.Cells[2].Value?.ToString(),
                Address = row.Cells[3].Value?.ToString()
            };

            Frm_SuaNCC frmSua = new Frm_SuaNCC(ncc);
            if (frmSua.ShowDialog() == DialogResult.OK)
            {
                loadDanhSach();
            }      
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (dgvNCC.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var xacNhan = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan == DialogResult.No)
            {
                return;
            }

            string loi = "";
            if (controller.Xoa(maDangChon, out loi))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhSach();
                maDangChon = 0;
                lblDangChon.Text = "---";
            }
            else
            {
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            maDangChon = 0;
            lblDangChon.Text = "---";
            loadDanhSach();
            dgvNCC.ClearSelection();
            dgvNCC.CurrentCell = null;
        }


        private void Frm_NCC_Load_1(object sender, EventArgs e)
        {
            dgvNCC.AutoGenerateColumns = false;

            dgvNCC.Columns["colNgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            cboLoc.Items.Clear();
            cboLoc.Items.Add("Tất cả các ngày");
            cboLoc.Items.Add("Hôm nay");
            cboLoc.Items.Add("Tuần này");
            cboLoc.Items.Add("Tháng này");
            cboLoc.SelectedIndex = 0;
            loadDanhSach();
        }

        private void dgvNCC_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvNCC.CurrentRow == null)
            {
                return;
            }

            var row = dgvNCC.CurrentRow;
            maDangChon = Convert.ToInt32(row.Cells[0].Value);
            lblDangChon.Text = row.Cells[0].Value + " - " + row.Cells[1].Value;
        }

        private void txtTim_TextChanged_1(object sender, EventArgs e)
        {
            dgvNCC.DataSource = controller.TimKiem(txtTim.Text.Trim());
            lblTongNCC.Text = dgvNCC.Rows.Count.ToString();
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loc = cboLoc.SelectedItem?.ToString();

            DateTime homNay = DateTime.Today;
            var danhSach = controller.LayDanhSach();

            if (loc == "Hôm nay")
            {
                danhSach = danhSach.Where(x => x.CreatedAt.HasValue && x.CreatedAt.Value.Date == homNay).ToList();
            }
            else if (loc == "Tuần này")
            {
                DateTime dauTuan = homNay.AddDays(-(int)homNay.DayOfWeek + 1);
                danhSach = danhSach.Where(x => x.CreatedAt.HasValue && x.CreatedAt.Value.Date >= dauTuan).ToList();
            }
            else if (loc == "Tháng này")
            {
                danhSach = danhSach.Where(x => x.CreatedAt.HasValue && x.CreatedAt.Value.Month == homNay.Month && x.CreatedAt.Value.Year == homNay.Year).ToList();
            }

            dgvNCC.DataSource = danhSach;
            lblTongNCC.Text = dgvNCC.Rows.Count.ToString();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = $"DanhSachNhaCungCap_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var danhSach = (List<Supplier>)dgvNCC.DataSource;
                        Utils.ExcelHelper.XuatExcelNCC(danhSach, sfd.FileName);
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
