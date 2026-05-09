namespace QL_CuaHangBanThuocTruSau.Views
{
    partial class Frm_KhachHang
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
            this.dgvKhachHang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colMaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSĐT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTongKhachHang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTim = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlInput = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDangChon = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.txtDiaChi = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSĐT = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenKH = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvKhachHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKhachHang.ColumnHeadersHeight = 35;
            this.dgvKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaKH,
            this.colTenKH,
            this.colSĐT,
            this.colDiaChi});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKhachHang.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKhachHang.Location = new System.Drawing.Point(0, 158);
            this.dgvKhachHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.ReadOnly = true;
            this.dgvKhachHang.RowHeadersVisible = false;
            this.dgvKhachHang.RowHeadersWidth = 62;
            this.dgvKhachHang.RowTemplate.Height = 28;
            this.dgvKhachHang.Size = new System.Drawing.Size(601, 404);
            this.dgvKhachHang.TabIndex = 0;
            this.dgvKhachHang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKhachHang.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvKhachHang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvKhachHang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvKhachHang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvKhachHang.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvKhachHang.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKhachHang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.SteelBlue;
            this.dgvKhachHang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKhachHang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvKhachHang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvKhachHang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvKhachHang.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvKhachHang.ThemeStyle.ReadOnly = true;
            this.dgvKhachHang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKhachHang.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKhachHang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvKhachHang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvKhachHang.ThemeStyle.RowsStyle.Height = 28;
            this.dgvKhachHang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKhachHang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);
            this.dgvKhachHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellContentClick);
            // 
            // colMaKH
            // 
            this.colMaKH.DataPropertyName = "CustomerID";
            this.colMaKH.HeaderText = "Mã KH";
            this.colMaKH.MinimumWidth = 8;
            this.colMaKH.Name = "colMaKH";
            this.colMaKH.ReadOnly = true;
            // 
            // colTenKH
            // 
            this.colTenKH.DataPropertyName = "Name";
            this.colTenKH.HeaderText = "Tên khách hàng";
            this.colTenKH.MinimumWidth = 8;
            this.colTenKH.Name = "colTenKH";
            this.colTenKH.ReadOnly = true;
            // 
            // colSĐT
            // 
            this.colSĐT.DataPropertyName = "Phone";
            this.colSĐT.HeaderText = "Số điện thoại";
            this.colSĐT.MinimumWidth = 8;
            this.colSĐT.Name = "colSĐT";
            this.colSĐT.ReadOnly = true;
            // 
            // colDiaChi
            // 
            this.colDiaChi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDiaChi.DataPropertyName = "Address";
            this.colDiaChi.HeaderText = "Địa chỉ";
            this.colDiaChi.MinimumWidth = 8;
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.ReadOnly = true;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.lblTongKhachHang);
            this.pnlTop.Controls.Add(this.txtTim);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 83);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(601, 75);
            this.pnlTop.TabIndex = 1;
            // 
            // lblTongKhachHang
            // 
            this.lblTongKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.lblTongKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongKhachHang.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTongKhachHang.Location = new System.Drawing.Point(206, 20);
            this.lblTongKhachHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTongKhachHang.Name = "lblTongKhachHang";
            this.lblTongKhachHang.Size = new System.Drawing.Size(15, 30);
            this.lblTongKhachHang.TabIndex = 2;
            this.lblTongKhachHang.Text = "0";
            // 
            // txtTim
            // 
            this.txtTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTim.BorderRadius = 5;
            this.txtTim.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTim.DefaultText = "";
            this.txtTim.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTim.Location = new System.Drawing.Point(228, 20);
            this.txtTim.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTim.Name = "txtTim";
            this.txtTim.PlaceholderText = "Tìm kiếm...";
            this.txtTim.SelectedText = "";
            this.txtTim.Size = new System.Drawing.Size(366, 45);
            this.txtTim.TabIndex = 0;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInput.BorderColor = System.Drawing.Color.LightGray;
            this.pnlInput.BorderThickness = 1;
            this.pnlInput.Controls.Add(this.label7);
            this.pnlInput.Controls.Add(this.label6);
            this.pnlInput.Controls.Add(this.label3);
            this.pnlInput.Controls.Add(this.label2);
            this.pnlInput.Controls.Add(this.label1);
            this.pnlInput.Controls.Add(this.lblDangChon);
            this.pnlInput.Controls.Add(this.btnLamMoi);
            this.pnlInput.Controls.Add(this.btnXoa);
            this.pnlInput.Controls.Add(this.btnSua);
            this.pnlInput.Controls.Add(this.btnThem);
            this.pnlInput.Controls.Add(this.txtDiaChi);
            this.pnlInput.Controls.Add(this.txtSĐT);
            this.pnlInput.Controls.Add(this.txtTenKH);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInput.Location = new System.Drawing.Point(601, 0);
            this.pnlInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(411, 562);
            this.pnlInput.TabIndex = 2;
            this.pnlInput.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInput_Paint);
            // 
            // lblDangChon
            // 
            this.lblDangChon.BackColor = System.Drawing.Color.Transparent;
            this.lblDangChon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDangChon.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDangChon.Location = new System.Drawing.Point(169, 70);
            this.lblDangChon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDangChon.Name = "lblDangChon";
            this.lblDangChon.Size = new System.Drawing.Size(24, 27);
            this.lblDangChon.TabIndex = 11;
            this.lblDangChon.Text = "---";
            this.lblDangChon.Click += new System.EventHandler(this.lblDangChon_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 5;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.FillColor = System.Drawing.Color.Red;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(228, 498);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(146, 60);
            this.btnLamMoi.TabIndex = 9;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.FillColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(35, 498);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(153, 60);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 5;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(228, 421);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(146, 56);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 5;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.DarkSlateGray;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(35, 421);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(153, 60);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BorderRadius = 5;
            this.txtDiaChi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiaChi.DefaultText = "";
            this.txtDiaChi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiaChi.Location = new System.Drawing.Point(35, 323);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.PlaceholderText = "";
            this.txtDiaChi.SelectedText = "";
            this.txtDiaChi.Size = new System.Drawing.Size(339, 88);
            this.txtDiaChi.TabIndex = 5;
            // 
            // txtSĐT
            // 
            this.txtSĐT.BorderRadius = 5;
            this.txtSĐT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSĐT.DefaultText = "";
            this.txtSĐT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSĐT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSĐT.Location = new System.Drawing.Point(35, 238);
            this.txtSĐT.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSĐT.Name = "txtSĐT";
            this.txtSĐT.PlaceholderText = "";
            this.txtSĐT.SelectedText = "";
            this.txtSĐT.Size = new System.Drawing.Size(339, 45);
            this.txtSĐT.TabIndex = 4;
            // 
            // txtTenKH
            // 
            this.txtTenKH.BorderRadius = 5;
            this.txtTenKH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenKH.DefaultText = "";
            this.txtTenKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenKH.Location = new System.Drawing.Point(35, 143);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.PlaceholderText = "";
            this.txtTenKH.SelectedText = "";
            this.txtTenKH.Size = new System.Drawing.Size(339, 45);
            this.txtTenKH.TabIndex = 3;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlTitle.Controls.Add(this.label5);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(601, 83);
            this.pnlTitle.TabIndex = 3;
            this.pnlTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTitle_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "Đang chọn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 28);
            this.label3.TabIndex = 14;
            this.label3.Text = "Họ và tên:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 30);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tổng khách hàng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(306, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(334, 38);
            this.label5.TabIndex = 14;
            this.label5.Text = "QUẢN LÝ KHÁCH HÀNG";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(33, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(317, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 28);
            this.label7.TabIndex = 15;
            this.label7.Text = "Số điện thoại:";
            // 
            // Frm_KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1012, 562);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_KhachHang";
            this.Text = "QUẢN LÝ KHÁCH HÀNG";
            this.Load += new System.EventHandler(this.Frm_KhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvKhachHang;
        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlInput;
        private Guna.UI2.WinForms.Guna2TextBox txtTim;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongKhachHang;
        private Guna.UI2.WinForms.Guna2TextBox txtDiaChi;
        private Guna.UI2.WinForms.Guna2TextBox txtSĐT;
        private Guna.UI2.WinForms.Guna2TextBox txtTenKH;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDangChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSĐT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiaChi;
        private Guna.UI2.WinForms.Guna2Panel pnlTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}