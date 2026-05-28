using QL_CuaHangBanThuocTruSau.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QL_CuaHangBanThuocTruSau.Views {
    public partial class Dashboard : Form {
        private readonly DashboardController _controller;

        public Dashboard () {
            InitializeComponent ();
            _controller = new DashboardController ();
        }

        private void Dashboard_Load (object sender, EventArgs e) {
            LoadSummary ();
            LoadChart ();
            LoadExpiredProducts ();
        }

        private void LoadSummary () {
            try
            {
                var summary = _controller.GetSummary ();
                // Sử dụng định dạng N0 để đảm bảo có dấu phân cách hàng nghìn và đầy đủ số 0
                label6.Text = string.Format ("{0:N0} VNĐ", summary.TotalRevenue);
                label7.Text = string.Format ("{0:N0}", summary.NewOrdersToday);
                label8.Text = string.Format ("{0:N0} VNĐ", summary.CustomerDebt);
                label9.Text = string.Format ("{0:N0} VNĐ", summary.InventoryValue);

                // Màu chữ
                label6.ForeColor = Color.FromArgb(45, 95, 166);
                label7.ForeColor = Color.FromArgb(40, 167, 69);
                label8.ForeColor = Color.FromArgb(220, 53, 69);
                label9.ForeColor = Color.FromArgb(240, 165, 0);

                // Nền trong suốt
                label6.BackColor = Color.Transparent;
                label7.BackColor = Color.Transparent;
                label8.BackColor = Color.Transparent;
                label9.BackColor = Color.Transparent;

                // Màu title
                label2.ForeColor = Color.FromArgb(45, 95, 166);   
                label3.ForeColor = Color.FromArgb(40, 167, 69);   
                label4.ForeColor = Color.FromArgb(220, 53, 69);   
                label5.ForeColor = Color.FromArgb(180, 120, 0);

                SetCardStyle(pnlRevenue, Color.FromArgb(45, 95, 166));   
                SetCardStyle(pnlOrders, Color.FromArgb(40, 167, 69));   
                SetCardStyle(pnlDebt, Color.FromArgb(220, 53, 69));   
                SetCardStyle(pnlInventory, Color.FromArgb(240, 165, 0));   
            }

            catch( Exception ex )
            {
                Console.WriteLine ("Lỗi khi tải tổng quan: " + ex.Message);
            }
        }

        private void LoadChart () {
            try
            {
                chart1.Series.Clear ();
                chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                chart1.ChartAreas[0].BackColor = Color.White;
                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

                // Series Cột: Số lượng sản phẩm bán ra
                Series colSeries = new Series ("Sản phẩm bán ra");
                colSeries.ChartType = SeriesChartType.Column;
                colSeries.Color = Color.FromArgb (0, 123, 255); 
                colSeries.IsValueShownAsLabel = true;
                colSeries.Font = new Font ("Segoe UI", 8, FontStyle.Bold);

                // Series Đường: Doanh thu
                Series lineSeries = new Series ("Doanh thu");
                lineSeries.ChartType = SeriesChartType.Line;
                lineSeries.Color = Color.FromArgb (220, 53, 69);
                lineSeries.BorderWidth = 3;
                lineSeries.MarkerStyle = MarkerStyle.Circle;
                lineSeries.MarkerSize = 10;
                lineSeries.YAxisType = AxisType.Secondary; 

                var revenueData = _controller.GetRevenueData ();
                foreach( var item in revenueData )
                {
                    colSeries.Points.AddXY (item.DateStr, item.ProductCount);
                    lineSeries.Points.AddXY (item.DateStr, item.Revenue);
                }

                chart1.Series.Add (colSeries);
                chart1.Series.Add (lineSeries);

                chart1.Titles.Clear ();
                Title title = chart1.Titles.Add ("XU HƯỚNG KINH DOANH 7 NGÀY QUA");
                title.Font = new Font ("Segoe UI", 12, FontStyle.Bold);
                title.ForeColor = Color.FromArgb (64, 64, 64);

                chart1.ChartAreas[0].AxisX.Title = "Ngày";
                chart1.ChartAreas[0].AxisY.Title = "Số lượng (SP)";
                chart1.ChartAreas[0].AxisY2.Title = "Doanh thu (VNĐ)";

                chart1.ChartAreas[0].AxisY2.LabelStyle.Format = "{0:N0}";
                chart1.Legends[0].Docking = Docking.Bottom;

            }
            catch( Exception ex )
            {
                MessageBox.Show ("Lỗi khi tải biểu đồ: " + ex.Message);
            }
        }
        private void SetCardStyle(Panel pnl, Color accent)
        {
            pnl.BackColor = Color.Transparent;

            Action updateRegion = () =>
            {
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                int r = 8;
                path.AddArc(0, 0, r, r, 180, 90);
                path.AddArc(pnl.Width - r - 1, 0, r, r, 270, 90);
                path.AddArc(pnl.Width - r - 1, pnl.Height - r - 1, r, r, 0, 90);
                path.AddArc(0, pnl.Height - r - 1, r, r, 90, 90);
                path.CloseFigure();
                pnl.Region = new Region(path);
            };

            updateRegion(); // lần đầu
            pnl.Resize += (s, e) => updateRegion(); // cập nhật khi resize

            pnl.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.FillRectangle(new SolidBrush(Color.FromArgb(25, accent)), pnl.ClientRectangle);
                g.FillRectangle(new SolidBrush(accent), 0, 0, 4, pnl.Height);
            };
        }

        private void LoadExpiredProducts()
        {
            try
            {
                var expiredProducts = _controller.GetExpiredProducts();

                dataGridView1.DataSource = null;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();

                // Grid
                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 30;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView1.GridColor = Color.LightGray;
                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
                dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 248);
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 60, 90);

                // Tắt kéo giãn cột và hàng
                dataGridView1.AllowUserToResizeColumns = false;
                dataGridView1.AllowUserToResizeRows = false;
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                // Header
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView1.ColumnHeadersHeight = 34;

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductName", DataPropertyName = "ProductName", HeaderText = "Sản phẩm", FillWeight = 40 });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "BatchID",
                    DataPropertyName = "BatchID",
                    HeaderText = "Mã lô",
                    FillWeight = 12,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ExpiryDate",
                    DataPropertyName = "ExpiryDate",
                    HeaderText = "Hạn sử dụng",
                    FillWeight = 25,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy", Alignment = DataGridViewContentAlignment.MiddleCenter }
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "RemainingQuantity",
                    DataPropertyName = "RemainingQuantity",
                    HeaderText = "Tồn",
                    FillWeight = 13,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                });

                dataGridView1.CellFormatting += DataGridView1_CellFormatting;
                dataGridView1.DataSource = expiredProducts;
                dataGridView1.LostFocus += (s, e) => dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 248);

                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Transparent;
                dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
                dataGridView1.SelectionChanged += (s, e) => dataGridView1.ClearSelection();
                dataGridView1.ClearSelection();

                int loHetHan = 0, loCangDate = 0;
                foreach (var p in expiredProducts)
                {
                    DateTime exp = (DateTime)p.ExpiryDate;
                    if ((exp - DateTime.Now).TotalDays < 0) 
                        loHetHan++;
                    else 
                        loCangDate++;
                }
                lblTongSoLo.Text = string.Format("Tổng: {0} lô cận hạn", loCangDate);

                lblThongBao.Visible = expiredProducts.Count == 0;
                lblThongBao.Text = "(Không có lô hàng nào sắp hết hạn)";
                lblThongBao.BringToFront();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tải hàng cận date: " + ex.Message);
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];
            if (row.Cells["ExpiryDate"]?.Value == null) return;
            if (!(row.Cells["ExpiryDate"].Value is DateTime)) return;

            DateTime expiryDate = (DateTime)row.Cells["ExpiryDate"].Value;
            double daysLeft = (expiryDate - DateTime.Now).TotalDays;

            if (daysLeft < 0)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 30, 30);
                row.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }
            else if (daysLeft <= 30)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 225);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 95, 0);
            }
        }
    }
}

