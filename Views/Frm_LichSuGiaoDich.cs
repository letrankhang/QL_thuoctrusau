using System;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Views
{
    public partial class Frm_LichSuGiaoDich : Form
    {
        public Frm_LichSuGiaoDich(int customerId, string customerName)
        {
            InitializeComponent();
            this.Text = $"Lịch sử giao dịch - {customerName}";
            // Stub implementation
        }

        private void InitializeComponent()
        {
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}
