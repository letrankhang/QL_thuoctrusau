namespace QL_CuaHangBanThuocTruSau.Views {
    partial class Dashboard {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if( disposing && (components != null) )
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelSummary = new System.Windows.Forms.TableLayoutPanel();
            this.pnlRevenue = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlOrders = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlDebt = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlInventory = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelDetails = new System.Windows.Forms.TableLayoutPanel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblThongBao = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTongSoLo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanelSummary.SuspendLayout();
            this.pnlRevenue.SuspendLayout();
            this.pnlOrders.SuspendLayout();
            this.pnlDebt.SuspendLayout();
            this.pnlInventory.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanelDetails.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanelSummary);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.19469F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1625, 180);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng quan hôm nay";
            // 
            // tableLayoutPanelSummary
            // 
            this.tableLayoutPanelSummary.ColumnCount = 4;
            this.tableLayoutPanelSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSummary.Controls.Add(this.pnlRevenue, 0, 0);
            this.tableLayoutPanelSummary.Controls.Add(this.pnlOrders, 1, 0);
            this.tableLayoutPanelSummary.Controls.Add(this.pnlDebt, 2, 0);
            this.tableLayoutPanelSummary.Controls.Add(this.pnlInventory, 3, 0);
            this.tableLayoutPanelSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSummary.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanelSummary.Name = "tableLayoutPanelSummary";
            this.tableLayoutPanelSummary.RowCount = 1;
            this.tableLayoutPanelSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSummary.Size = new System.Drawing.Size(1619, 152);
            this.tableLayoutPanelSummary.TabIndex = 0;
            // 
            // pnlRevenue
            // 
            this.pnlRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.pnlRevenue.Controls.Add(this.label6);
            this.pnlRevenue.Controls.Add(this.label2);
            this.pnlRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRevenue.Location = new System.Drawing.Point(10, 10);
            this.pnlRevenue.Margin = new System.Windows.Forms.Padding(10);
            this.pnlRevenue.Name = "pnlRevenue";
            this.pnlRevenue.Size = new System.Drawing.Size(384, 132);
            this.pnlRevenue.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(384, 87);
            this.label6.TabIndex = 8;
            this.label6.Text = "0 VNĐ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.10619F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(384, 45);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tổng doanh thu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOrders
            // 
            this.pnlOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.pnlOrders.Controls.Add(this.label7);
            this.pnlOrders.Controls.Add(this.label3);
            this.pnlOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrders.Location = new System.Drawing.Point(414, 10);
            this.pnlOrders.Margin = new System.Windows.Forms.Padding(10);
            this.pnlOrders.Name = "pnlOrders";
            this.pnlOrders.Size = new System.Drawing.Size(384, 132);
            this.pnlOrders.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(384, 87);
            this.label7.TabIndex = 9;
            this.label7.Text = "0";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.10619F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(384, 45);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số đơn hàng mới";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDebt
            // 
            this.pnlDebt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.pnlDebt.Controls.Add(this.label8);
            this.pnlDebt.Controls.Add(this.label4);
            this.pnlDebt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDebt.Location = new System.Drawing.Point(818, 10);
            this.pnlDebt.Margin = new System.Windows.Forms.Padding(10);
            this.pnlDebt.Name = "pnlDebt";
            this.pnlDebt.Size = new System.Drawing.Size(384, 132);
            this.pnlDebt.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(384, 87);
            this.label8.TabIndex = 10;
            this.label8.Text = "0 VNĐ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12.10619F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(384, 45);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng công nợ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInventory
            // 
            this.pnlInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.pnlInventory.Controls.Add(this.label9);
            this.pnlInventory.Controls.Add(this.label5);
            this.pnlInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInventory.Location = new System.Drawing.Point(1222, 10);
            this.pnlInventory.Margin = new System.Windows.Forms.Padding(10);
            this.pnlInventory.Name = "pnlInventory";
            this.pnlInventory.Size = new System.Drawing.Size(387, 132);
            this.pnlInventory.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(387, 87);
            this.label9.TabIndex = 11;
            this.label9.Text = "0 VNĐ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12.10619F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(387, 45);
            this.label5.TabIndex = 3;
            this.label5.Text = "Giá trị kho hiện tại";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanelDetails);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.19469F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1625, 587);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết hoạt động";
            // 
            // tableLayoutPanelDetails
            // 
            this.tableLayoutPanelDetails.ColumnCount = 2;
            this.tableLayoutPanelDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanelDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelDetails.Controls.Add(this.panelRight, 1, 0);
            this.tableLayoutPanelDetails.Controls.Add(this.guna2Panel4, 0, 0);
            this.tableLayoutPanelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDetails.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanelDetails.Name = "tableLayoutPanelDetails";
            this.tableLayoutPanelDetails.RowCount = 1;
            this.tableLayoutPanelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDetails.Size = new System.Drawing.Size(1619, 559);
            this.tableLayoutPanelDetails.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.guna2Panel3);
            this.panelRight.Controls.Add(this.guna2Panel1);
            this.panelRight.Controls.Add(this.guna2Separator1);
            this.panelRight.Controls.Add(this.label1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(1055, 3);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(7);
            this.panelRight.Size = new System.Drawing.Size(561, 553);
            this.panelRight.TabIndex = 1;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.White;
            this.guna2Panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel3.BorderThickness = 1;
            this.guna2Panel3.Controls.Add(this.lblThongBao);
            this.guna2Panel3.Controls.Add(this.dataGridView1);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(7, 42);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Padding = new System.Windows.Forms.Padding(4);
            this.guna2Panel3.Size = new System.Drawing.Size(547, 439);
            this.guna2Panel3.TabIndex = 5;
            // 
            // lblThongBao
            // 
            this.lblThongBao.BackColor = System.Drawing.Color.White;
            this.lblThongBao.Enabled = false;
            this.lblThongBao.Font = new System.Drawing.Font("Segoe UI", 10.83186F);
            this.lblThongBao.ForeColor = System.Drawing.Color.Gray;
            this.lblThongBao.Location = new System.Drawing.Point(139, 302);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(278, 25);
            this.lblThongBao.TabIndex = 2;
            this.lblThongBao.Text = "(Không có lô hàng nào sắp hết hạn)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.19469F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(539, 431);
            this.dataGridView1.TabIndex = 1;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(7, 481);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.guna2Panel1.Size = new System.Drawing.Size(547, 65);
            this.guna2Panel1.TabIndex = 4;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.lblTongSoLo);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 7);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(547, 58);
            this.guna2Panel2.TabIndex = 2;
            // 
            // lblTongSoLo
            // 
            this.lblTongSoLo.BackColor = System.Drawing.Color.Transparent;
            this.lblTongSoLo.Font = new System.Drawing.Font("Segoe UI", 10.83186F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSoLo.ForeColor = System.Drawing.Color.Gray;
            this.lblTongSoLo.Location = new System.Drawing.Point(15, 17);
            this.lblTongSoLo.Name = "lblTongSoLo";
            this.lblTongSoLo.Size = new System.Drawing.Size(12, 25);
            this.lblTongSoLo.TabIndex = 1;
            this.lblTongSoLo.Text = "0";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Separator1.Location = new System.Drawing.Point(187, 20);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(368, 16);
            this.guna2Separator1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(547, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lô hàng tồn sắp hết hạn";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.White;
            this.guna2Panel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel4.BorderThickness = 1;
            this.guna2Panel4.Controls.Add(this.chart1);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel4.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Padding = new System.Windows.Forms.Padding(1);
            this.guna2Panel4.Size = new System.Drawing.Size(1046, 553);
            this.guna2Panel4.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(1, 1);
            this.chart1.Name = "chart1";
            this.chart1.Padding = new System.Windows.Forms.Padding(10);
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1044, 551);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Dashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1625, 767);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.Text = "Hệ thống Quản lý Cửa hàng - Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanelSummary.ResumeLayout(false);
            this.pnlRevenue.ResumeLayout(false);
            this.pnlOrders.ResumeLayout(false);
            this.pnlDebt.ResumeLayout(false);
            this.pnlInventory.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanelDetails.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlInventory;
        private System.Windows.Forms.Panel pnlDebt;
        private System.Windows.Forms.Panel pnlOrders;
        private System.Windows.Forms.Panel pnlRevenue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSummary;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDetails;
        private System.Windows.Forms.Panel panelRight;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongSoLo;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblThongBao;
    }
}
