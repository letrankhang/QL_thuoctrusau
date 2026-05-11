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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dgvCart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlCheckout = new System.Windows.Forms.Panel();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnInventoryHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnViewOld = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveOnly = new Guna.UI2.WinForms.Guna2Button();
            this.btnSavePrint = new Guna.UI2.WinForms.Guna2Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.pnlCartHeader = new System.Windows.Forms.Panel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.cboCustomer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cboLocTheoLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboLocTheoGia = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblHTGioHang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.pnlCheckout.SuspendLayout();
            this.pnlCartHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.lblHTGioHang);
            this.pnlRight.Controls.Add(this.dgvCart);
            this.pnlRight.Controls.Add(this.guna2Panel2);
            this.pnlRight.Controls.Add(this.pnlCartHeader);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1089, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(15, 0, 15, 15);
            this.pnlRight.Size = new System.Drawing.Size(536, 767);
            this.pnlRight.TabIndex = 0;
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToResizeColumns = false;
            this.dgvCart.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.ColumnHeadersHeight = 38;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.dgvCart.Location = new System.Drawing.Point(15, 114);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidth = 62;
            this.dgvCart.RowTemplate.Height = 52;
            this.dgvCart.Size = new System.Drawing.Size(506, 372);
            this.dgvCart.TabIndex = 1;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.dgvCart.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCart.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.dgvCart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCart.ThemeStyle.HeaderStyle.Height = 38;
            this.dgvCart.ThemeStyle.ReadOnly = false;
            this.dgvCart.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvCart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.dgvCart.ThemeStyle.RowsStyle.Height = 52;
            this.dgvCart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.dgvCart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.pnlCheckout);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel2.Location = new System.Drawing.Point(15, 486);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.guna2Panel2.Size = new System.Drawing.Size(506, 266);
            this.guna2Panel2.TabIndex = 3;
            // 
            // pnlCheckout
            // 
            this.pnlCheckout.Controls.Add(this.guna2Separator3);
            this.pnlCheckout.Controls.Add(this.guna2Separator2);
            this.pnlCheckout.Controls.Add(this.btnInventoryHistory);
            this.pnlCheckout.Controls.Add(this.btnViewOld);
            this.pnlCheckout.Controls.Add(this.btnCancel);
            this.pnlCheckout.Controls.Add(this.btnSaveOnly);
            this.pnlCheckout.Controls.Add(this.btnSavePrint);
            this.pnlCheckout.Controls.Add(this.lblTotal);
            this.pnlCheckout.Controls.Add(this.lblTotalText);
            this.pnlCheckout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCheckout.Location = new System.Drawing.Point(0, 10);
            this.pnlCheckout.Name = "pnlCheckout";
            this.pnlCheckout.Size = new System.Drawing.Size(506, 256);
            this.pnlCheckout.TabIndex = 2;
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Separator3.FillThickness = 2;
            this.guna2Separator3.Location = new System.Drawing.Point(14, 139);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(475, 27);
            this.guna2Separator3.TabIndex = 9;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Separator2.FillThickness = 2;
            this.guna2Separator2.Location = new System.Drawing.Point(281, 100);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(26, 10);
            this.guna2Separator2.TabIndex = 8;
            // 
            // btnInventoryHistory
            // 
            this.btnInventoryHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnInventoryHistory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInventoryHistory.BorderRadius = 10;
            this.btnInventoryHistory.FillColor = System.Drawing.Color.SteelBlue;
            this.btnInventoryHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 8.920354F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryHistory.ForeColor = System.Drawing.Color.White;
            this.btnInventoryHistory.Image = global::QL_CuaHangBanThuocTruSau.Properties.Resources.historical;
            this.btnInventoryHistory.ImageSize = new System.Drawing.Size(25, 25);
            this.btnInventoryHistory.Location = new System.Drawing.Point(239, 172);
            this.btnInventoryHistory.Name = "btnInventoryHistory";
            this.btnInventoryHistory.Size = new System.Drawing.Size(250, 53);
            this.btnInventoryHistory.TabIndex = 7;
            this.btnInventoryHistory.Text = "Lịch sử kho";
            this.btnInventoryHistory.Click += new System.EventHandler(this.btnInventoryHistory_Click);
            // 
            // btnViewOld
            // 
            this.btnViewOld.BackColor = System.Drawing.Color.Transparent;
            this.btnViewOld.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnViewOld.BorderRadius = 10;
            this.btnViewOld.FillColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnViewOld.Font = new System.Drawing.Font("Segoe UI Semibold", 8.920354F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewOld.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnViewOld.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnViewOld.Location = new System.Drawing.Point(14, 172);
            this.btnViewOld.Name = "btnViewOld";
            this.btnViewOld.Size = new System.Drawing.Size(101, 53);
            this.btnViewOld.TabIndex = 6;
            this.btnViewOld.Text = "Đơn cũ";
            this.btnViewOld.Click += new System.EventHandler(this.btnViewOld_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.FillColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.920354F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(125, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 53);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy đơn";
            // 
            // btnSaveOnly
            // 
            this.btnSaveOnly.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSaveOnly.BorderRadius = 10;
            this.btnSaveOnly.BorderThickness = 1;
            this.btnSaveOnly.FillColor = System.Drawing.Color.White;
            this.btnSaveOnly.Font = new System.Drawing.Font("Segoe UI Semibold", 10.19469F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveOnly.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnSaveOnly.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnSaveOnly.Image = global::QL_CuaHangBanThuocTruSau.Properties.Resources.debt_consolidation;
            this.btnSaveOnly.ImageOffset = new System.Drawing.Point(2, 0);
            this.btnSaveOnly.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSaveOnly.Location = new System.Drawing.Point(313, 75);
            this.btnSaveOnly.Name = "btnSaveOnly";
            this.btnSaveOnly.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnSaveOnly.Size = new System.Drawing.Size(176, 58);
            this.btnSaveOnly.TabIndex = 4;
            this.btnSaveOnly.Text = " Ghi nợ / Lưu đơn";
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.BorderRadius = 10;
            this.btnSavePrint.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(168)))), ((int)(((byte)(83)))));
            this.btnSavePrint.Font = new System.Drawing.Font("Segoe UI Semibold", 12.10619F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePrint.ForeColor = System.Drawing.Color.White;
            this.btnSavePrint.Image = global::QL_CuaHangBanThuocTruSau.Properties.Resources.wallet;
            this.btnSavePrint.ImageSize = new System.Drawing.Size(27, 27);
            this.btnSavePrint.Location = new System.Drawing.Point(14, 75);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Size = new System.Drawing.Size(261, 58);
            this.btnSavePrint.TabIndex = 3;
            this.btnSavePrint.Text = "Thanh toán";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 15.9292F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotal.Location = new System.Drawing.Point(113, 3);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(376, 43);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "0đ";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalText
            // 
            this.lblTotalText.AutoSize = true;
            this.lblTotalText.Font = new System.Drawing.Font("Segoe UI Semibold", 12.10619F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalText.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalText.Location = new System.Drawing.Point(9, 15);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(98, 25);
            this.lblTotalText.TabIndex = 1;
            this.lblTotalText.Text = "Tổng tiền:";
            // 
            // pnlCartHeader
            // 
            this.pnlCartHeader.Controls.Add(this.guna2HtmlLabel1);
            this.pnlCartHeader.Controls.Add(this.guna2Button1);
            this.pnlCartHeader.Controls.Add(this.guna2Separator1);
            this.pnlCartHeader.Controls.Add(this.cboCustomer);
            this.pnlCartHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCartHeader.Location = new System.Drawing.Point(15, 0);
            this.pnlCartHeader.Name = "pnlCartHeader";
            this.pnlCartHeader.Size = new System.Drawing.Size(506, 114);
            this.pnlCartHeader.TabIndex = 0;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Enabled = false;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 14.0177F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(42, 15);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(187, 32);
            this.guna2HtmlLabel1.TabIndex = 2;
            this.guna2HtmlLabel1.Text = "Đơn hàng hiện tại";
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Image = global::QL_CuaHangBanThuocTruSau.Properties.Resources.add_to_cart1;
            this.guna2Button1.ImageSize = new System.Drawing.Size(28, 28);
            this.guna2Button1.Location = new System.Drawing.Point(3, 10);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Size = new System.Drawing.Size(44, 37);
            this.guna2Button1.TabIndex = 3;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(235, 27);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(265, 10);
            this.guna2Separator1.TabIndex = 4;
            // 
            // cboCustomer
            // 
            this.cboCustomer.BackColor = System.Drawing.Color.Transparent;
            this.cboCustomer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboCustomer.BorderRadius = 10;
            this.cboCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FocusedColor = System.Drawing.Color.Empty;
            this.cboCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCustomer.ItemHeight = 30;
            this.cboCustomer.Location = new System.Drawing.Point(3, 62);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(497, 36);
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
            this.pnlLeft.Size = new System.Drawing.Size(1089, 767);
            this.pnlLeft.TabIndex = 1;
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.Location = new System.Drawing.Point(15, 75);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Size = new System.Drawing.Size(1059, 677);
            this.flpProducts.TabIndex = 1;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.guna2Panel1);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(15, 15);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1059, 60);
            this.pnlSearch.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.cboLocTheoLoai);
            this.guna2Panel1.Controls.Add(this.cboLocTheoGia);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(659, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(400, 60);
            this.guna2Panel1.TabIndex = 2;
            // 
            // cboLocTheoLoai
            // 
            this.cboLocTheoLoai.BackColor = System.Drawing.Color.Transparent;
            this.cboLocTheoLoai.BorderRadius = 10;
            this.cboLocTheoLoai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLocTheoLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTheoLoai.FocusedColor = System.Drawing.Color.SteelBlue;
            this.cboLocTheoLoai.FocusedState.BorderColor = System.Drawing.Color.SteelBlue;
            this.cboLocTheoLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocTheoLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLocTheoLoai.HoverState.BorderColor = System.Drawing.Color.SteelBlue;
            this.cboLocTheoLoai.ItemHeight = 30;
            this.cboLocTheoLoai.Location = new System.Drawing.Point(3, 9);
            this.cboLocTheoLoai.Name = "cboLocTheoLoai";
            this.cboLocTheoLoai.Size = new System.Drawing.Size(173, 36);
            this.cboLocTheoLoai.TabIndex = 2;
            // 
            // cboLocTheoGia
            // 
            this.cboLocTheoGia.BackColor = System.Drawing.Color.Transparent;
            this.cboLocTheoGia.BorderRadius = 10;
            this.cboLocTheoGia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLocTheoGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTheoGia.FocusedColor = System.Drawing.Color.SteelBlue;
            this.cboLocTheoGia.FocusedState.BorderColor = System.Drawing.Color.SteelBlue;
            this.cboLocTheoGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocTheoGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLocTheoGia.HoverState.BorderColor = System.Drawing.Color.SteelBlue;
            this.cboLocTheoGia.ItemHeight = 30;
            this.cboLocTheoGia.Location = new System.Drawing.Point(182, 9);
            this.cboLocTheoGia.Name = "cboLocTheoGia";
            this.cboLocTheoGia.Size = new System.Drawing.Size(215, 36);
            this.cboLocTheoGia.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.SteelBlue;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.SteelBlue;
            this.txtSearch.IconLeft = global::QL_CuaHangBanThuocTruSau.Properties.Resources.magnifier;
            this.txtSearch.IconLeftOffset = new System.Drawing.Point(7, 0);
            this.txtSearch.Location = new System.Drawing.Point(4, 9);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm sản phẩm theo tên, mã,...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(648, 36);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblHTGioHang
            // 
            this.lblHTGioHang.BackColor = System.Drawing.Color.Transparent;
            this.lblHTGioHang.Font = new System.Drawing.Font("Segoe UI", 10.83186F);
            this.lblHTGioHang.ForeColor = System.Drawing.Color.Gray;
            this.lblHTGioHang.Location = new System.Drawing.Point(189, 400);
            this.lblHTGioHang.Name = "lblHTGioHang";
            this.lblHTGioHang.Size = new System.Drawing.Size(174, 25);
            this.lblHTGioHang.TabIndex = 4;
            this.lblHTGioHang.Text = "(Giỏ hàng đang trống)";
            // 
            // Frm_BanHang
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1625, 767);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_BanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG BÁN HÀNG - POS";
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.pnlCheckout.ResumeLayout(false);
            this.pnlCheckout.PerformLayout();
            this.pnlCartHeader.ResumeLayout(false);
            this.pnlCartHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Button btnSavePrint;
        private Guna.UI2.WinForms.Guna2Button btnSaveOnly;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnViewOld;
        private Guna.UI2.WinForms.Guna2Button btnInventoryHistory;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cboLocTheoLoai;
        private Guna.UI2.WinForms.Guna2ComboBox cboLocTheoGia;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHTGioHang;
    }
}
