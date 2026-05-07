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

        private void LoadExpiredProducts () {
            try
            {
                var expiredProducts = _controller.GetExpiredProducts ();

                // Thiết lập DataGridView
                dataGridView1.DataSource = null;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear ();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ép các cột lấp đầy chiều ngang
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb (52, 58, 64);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font ("Segoe UI", 9, FontStyle.Bold);
                dataGridView1.ColumnHeadersHeight = 35;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb (248, 249, 250);

                dataGridView1.Columns.Add (new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    DataPropertyName = "ProductName",
                    HeaderText = "Sản phẩm",
                    Width = 180
                });
                dataGridView1.Columns.Add (new DataGridViewTextBoxColumn
                {
                    Name = "BatchID",
                    DataPropertyName = "BatchID",
                    HeaderText = "Lô",
                    Width = 50
                });
                dataGridView1.Columns.Add (new DataGridViewTextBoxColumn
                {
                    Name = "ExpiryDate",
                    DataPropertyName = "ExpiryDate",
                    HeaderText = "Hạn dùng",
                    DefaultCellStyle = new DataGridViewCellStyle { 
                        Format = "dd/MM/yyyy",
                        Alignment = DataGridViewContentAlignment.MiddleCenter 
                    },
                    Width = 90
                });
                dataGridView1.Columns.Add (new DataGridViewTextBoxColumn
                {
                    Name = "RemainingQuantity",
                    DataPropertyName = "RemainingQuantity",
                    HeaderText = "Tồn",
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight },
                    Width = 60
                });

                dataGridView1.DataSource = expiredProducts;

                // Highlight dòng cận date hoặc hết hạn
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["ExpiryDate"] != null && row.Cells["ExpiryDate"].Value != null)
                    {
                        DateTime expiryDate = (DateTime)row.Cells["ExpiryDate"].Value;
                        if (expiryDate < DateTime.Now)
                        {
                            row.DefaultCellStyle.ForeColor = Color.Red;
                            row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                        }
                        else if ((expiryDate - DateTime.Now).TotalDays <= 30)
                        {
                            row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                        }
                    }
                }
            }
            catch( Exception ex )
            {
                Console.WriteLine ("Lỗi khi tải hàng cận date: " + ex.Message);
            }
        }


    }
}

