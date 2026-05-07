namespace QL_CuaHangBanThuocTruSau.Views
{
    partial class Frm_BanHang
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cboCustomer;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblFinalPay;
        private Guna.UI2.WinForms.Guna2Button btnSavePrint;
        private Guna.UI2.WinForms.Guna2Button btnSaveOnly;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnViewOld;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlCheckout;
        private Guna.UI2.WinForms.Guna2Separator line1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboCustomer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvCart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblFinalPay = new System.Windows.Forms.Label();
            this.btnSavePrint = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveOnly = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnViewOld = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlCheckout = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.line1 = new Guna.UI2.WinForms.Guna2Separator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlCheckout.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(20, 15);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "F1: Tìm sản phẩm (Tên/Mã)...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(450, 40);
            this.txtSearch.TabIndex = 0;
            // 
            // cboCustomer
            // 
            this.cboCustomer.BackColor = System.Drawing.Color.Transparent;
            this.cboCustomer.BorderRadius = 8;
            this.cboCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FocusedColor = System.Drawing.Color.Empty;
            this.cboCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCustomer.ItemHeight = 30;
            this.cboCustomer.Location = new System.Drawing.Point(500, 15);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(300, 36);
            this.cboCustomer.TabIndex = 1;
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.Location = new System.Drawing.Point(20, 90);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidth = 62;
            this.dgvCart.Size = new System.Drawing.Size(730, 400);
            this.dgvCart.TabIndex = 1;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCart.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCart.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvCart.ThemeStyle.ReadOnly = false;
            this.dgvCart.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCart.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotal.ForeColor = System.Drawing.Color.Gray;
            this.lblTotal.Location = new System.Drawing.Point(20, 30);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(182, 30);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Tổng tiền hàng: 0";
            // 
            // lblFinalPay
            // 
            this.lblFinalPay.AutoSize = true;
            this.lblFinalPay.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblFinalPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblFinalPay.Location = new System.Drawing.Point(18, 70);
            this.lblFinalPay.Name = "lblFinalPay";
            this.lblFinalPay.Size = new System.Drawing.Size(303, 41);
            this.lblFinalPay.TabIndex = 1;
            this.lblFinalPay.Text = "KHÁCH PHẢI TRẢ: 0";
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.BorderRadius = 8;
            this.btnSavePrint.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSavePrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSavePrint.ForeColor = System.Drawing.Color.White;
            this.btnSavePrint.Location = new System.Drawing.Point(20, 321);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Size = new System.Drawing.Size(270, 45);
            this.btnSavePrint.TabIndex = 3;
            this.btnSavePrint.Text = "F2 - LƯU && IN HÓA ĐƠN";
            // 
            // btnSaveOnly
            // 
            this.btnSaveOnly.BorderRadius = 8;
            this.btnSaveOnly.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSaveOnly.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveOnly.ForeColor = System.Drawing.Color.White;
            this.btnSaveOnly.Location = new System.Drawing.Point(20, 392);
            this.btnSaveOnly.Name = "btnSaveOnly";
            this.btnSaveOnly.Size = new System.Drawing.Size(270, 45);
            this.btnSaveOnly.TabIndex = 4;
            this.btnSaveOnly.Text = "F5 - CHỈ LƯU ĐƠN (GHI NỢ)";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(41, 525);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(270, 45);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "F3 - HỦY ĐƠN HIỆN TẠI";
            // 
            // btnViewOld
            // 
            this.btnViewOld.BorderRadius = 8;
            this.btnViewOld.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnViewOld.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewOld.ForeColor = System.Drawing.Color.White;
            this.btnViewOld.Location = new System.Drawing.Point(392, 525);
            this.btnViewOld.Name = "btnViewOld";
            this.btnViewOld.Size = new System.Drawing.Size(270, 45);
            this.btnViewOld.TabIndex = 6;
            this.btnViewOld.Text = "F4 - XEM ĐƠN HÀNG CŨ";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Controls.Add(this.cboCustomer);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlCheckout
            // 
            this.pnlCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCheckout.BackColor = System.Drawing.Color.Transparent;
            this.pnlCheckout.Controls.Add(this.line1);
            this.pnlCheckout.Controls.Add(this.lblTotal);
            this.pnlCheckout.Controls.Add(this.lblFinalPay);
            this.pnlCheckout.Controls.Add(this.btnSavePrint);
            this.pnlCheckout.Controls.Add(this.btnSaveOnly);
            this.pnlCheckout.FillColor = System.Drawing.Color.White;
            this.pnlCheckout.Location = new System.Drawing.Point(770, 76);
            this.pnlCheckout.Name = "pnlCheckout";
            this.pnlCheckout.Radius = 10;
            this.pnlCheckout.ShadowColor = System.Drawing.Color.Black;
            this.pnlCheckout.ShadowShift = 8;
            this.pnlCheckout.Size = new System.Drawing.Size(330, 494);
            this.pnlCheckout.TabIndex = 2;
            // 
            // line1
            // 
            this.line1.Location = new System.Drawing.Point(20, 110);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(270, 10);
            this.line1.TabIndex = 2;
            // 
            // Frm_BanHang
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.btnViewOld);
            this.Controls.Add(this.pnlCheckout);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.pnlHeader);
            this.Name = "Frm_BanHang";
            this.Text = "HỆ THỐNG BÁN HÀNG - POS";
            this.Load += new System.EventHandler(this.Frm_BanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlCheckout.ResumeLayout(false);
            this.pnlCheckout.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
