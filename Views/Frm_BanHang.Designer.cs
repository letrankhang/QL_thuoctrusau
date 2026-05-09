namespace QL_CuaHangBanThuocTruSau.Views
{
    partial class Frm_BanHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dgvCart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlCheckout = new System.Windows.Forms.Panel();
            this.btnInventoryHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnViewOld = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveOnly = new Guna.UI2.WinForms.Guna2Button();
            this.btnSavePrint = new Guna.UI2.WinForms.Guna2Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.line1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnlCartHeader = new System.Windows.Forms.Panel();
            this.cboCustomer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlCheckout.SuspendLayout();
            this.pnlCartHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.dgvCart);
            this.pnlRight.Controls.Add(this.pnlCheckout);
            this.pnlRight.Controls.Add(this.pnlCartHeader);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(750, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(15);
            this.pnlRight.Size = new System.Drawing.Size(400, 700);
            this.pnlRight.TabIndex = 0;
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToResizeRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            this.dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgvCart.ColumnHeadersHeight = 30;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle24;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.Location = new System.Drawing.Point(15, 105);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidth = 62;
            this.dgvCart.RowTemplate.Height = 50;
            this.dgvCart.Size = new System.Drawing.Size(370, 310);
            this.dgvCart.TabIndex = 1;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.SteelBlue;
            this.dgvCart.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCart.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCart.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvCart.ThemeStyle.ReadOnly = false;
            this.dgvCart.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCart.ThemeStyle.RowsStyle.Height = 50;
            this.dgvCart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // pnlCheckout
            // 
            this.pnlCheckout.Controls.Add(this.btnInventoryHistory);
            this.pnlCheckout.Controls.Add(this.btnViewOld);
            this.pnlCheckout.Controls.Add(this.btnCancel);
            this.pnlCheckout.Controls.Add(this.btnSaveOnly);
            this.pnlCheckout.Controls.Add(this.btnSavePrint);
            this.pnlCheckout.Controls.Add(this.lblTotal);
            this.pnlCheckout.Controls.Add(this.lblTotalText);
            this.pnlCheckout.Controls.Add(this.line1);
            this.pnlCheckout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCheckout.Location = new System.Drawing.Point(15, 415);
            this.pnlCheckout.Name = "pnlCheckout";
            this.pnlCheckout.Size = new System.Drawing.Size(370, 270);
            this.pnlCheckout.TabIndex = 2;
            // 
            // btnInventoryHistory
            // 
            this.btnInventoryHistory.FillColor = System.Drawing.Color.SteelBlue;
            this.btnInventoryHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryHistory.ForeColor = System.Drawing.Color.White;
            this.btnInventoryHistory.Location = new System.Drawing.Point(264, 204);
            this.btnInventoryHistory.Name = "btnInventoryHistory";
            this.btnInventoryHistory.Size = new System.Drawing.Size(106, 53);
            this.btnInventoryHistory.TabIndex = 7;
            this.btnInventoryHistory.Text = "Lịch sử kho";
            this.btnInventoryHistory.Click += new System.EventHandler(this.btnInventoryHistory_Click);
            // 
            // btnViewOld
            // 
            this.btnViewOld.FillColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnViewOld.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewOld.ForeColor = System.Drawing.Color.Black;
            this.btnViewOld.Location = new System.Drawing.Point(140, 204);
            this.btnViewOld.Name = "btnViewOld";
            this.btnViewOld.Size = new System.Drawing.Size(101, 53);
            this.btnViewOld.TabIndex = 6;
            this.btnViewOld.Text = "Đơn cũ (F4)";
            this.btnViewOld.Click += new System.EventHandler(this.btnViewOld_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.RosyBrown;
            this.btnCancel.FillColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(0, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 53);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy đơn (F3)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveOnly
            // 
            this.btnSaveOnly.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSaveOnly.BorderThickness = 1;
            this.btnSaveOnly.FillColor = System.Drawing.Color.White;
            this.btnSaveOnly.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveOnly.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnSaveOnly.Location = new System.Drawing.Point(0, 137);
            this.btnSaveOnly.Name = "btnSaveOnly";
            this.btnSaveOnly.Size = new System.Drawing.Size(370, 49);
            this.btnSaveOnly.TabIndex = 4;
            this.btnSaveOnly.Text = "Ghi nợ / Lưu đơn (F5)";
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.FillColor = System.Drawing.Color.SteelBlue;
            this.btnSavePrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSavePrint.ForeColor = System.Drawing.Color.White;
            this.btnSavePrint.Location = new System.Drawing.Point(0, 65);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Size = new System.Drawing.Size(370, 50);
            this.btnSavePrint.TabIndex = 3;
            this.btnSavePrint.Text = "💳 Thanh toán (F2)";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotal.Location = new System.Drawing.Point(120, 15);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(247, 37);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "0 đ";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalText
            // 
            this.lblTotalText.AutoSize = true;
            this.lblTotalText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalText.Location = new System.Drawing.Point(4, 20);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(122, 32);
            this.lblTotalText.TabIndex = 1;
            this.lblTotalText.Text = "Tổng tiền:";
            // 
            // line1
            // 
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(370, 10);
            this.line1.TabIndex = 0;
            // 
            // pnlCartHeader
            // 
            this.pnlCartHeader.Controls.Add(this.label1);
            this.pnlCartHeader.Controls.Add(this.cboCustomer);
            this.pnlCartHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCartHeader.Location = new System.Drawing.Point(15, 15);
            this.pnlCartHeader.Name = "pnlCartHeader";
            this.pnlCartHeader.Size = new System.Drawing.Size(370, 90);
            this.pnlCartHeader.TabIndex = 0;
            // 
            // cboCustomer
            // 
            this.cboCustomer.BackColor = System.Drawing.Color.Transparent;
            this.cboCustomer.BorderColor = System.Drawing.Color.SteelBlue;
            this.cboCustomer.BorderThickness = 2;
            this.cboCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FocusedColor = System.Drawing.Color.Empty;
            this.cboCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCustomer.ItemHeight = 30;
            this.cboCustomer.Location = new System.Drawing.Point(0, 51);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(370, 36);
            this.cboCustomer.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlLeft.Controls.Add(this.flpProducts);
            this.pnlLeft.Controls.Add(this.pnlSearch);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(15);
            this.pnlLeft.Size = new System.Drawing.Size(750, 700);
            this.pnlLeft.TabIndex = 1;
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.Location = new System.Drawing.Point(15, 75);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Size = new System.Drawing.Size(720, 610);
            this.flpProducts.TabIndex = 1;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(15, 15);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(720, 60);
            this.pnlSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.CornflowerBlue;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "🔍 Tìm kiếm sản phẩm theo tên, mã (F1)...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(720, 45);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "🛒ĐƠN HÀNG HIỆN TẠI";
            // 
            // Frm_BanHang
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1150, 700);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Name = "Frm_BanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG BÁN HÀNG - POS";
            this.Load += new System.EventHandler(this.Frm_BanHang_Load_1);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlCheckout.ResumeLayout(false);
            this.pnlCheckout.PerformLayout();
            this.pnlCartHeader.ResumeLayout(false);
            this.pnlCartHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlCartHeader;
        private System.Windows.Forms.Panel pnlCheckout;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cboCustomer;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCart;
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Label lblTotal;
        private Guna.UI2.WinForms.Guna2Separator line1;
        private Guna.UI2.WinForms.Guna2Button btnSavePrint;
        private Guna.UI2.WinForms.Guna2Button btnSaveOnly;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnViewOld;
        private Guna.UI2.WinForms.Guna2Button btnInventoryHistory;
        private System.Windows.Forms.Label label1;
    }
}
