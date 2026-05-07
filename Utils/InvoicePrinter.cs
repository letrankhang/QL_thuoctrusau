using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Utils
{
    public class InvoicePrinter
    {
        private Order _order;
        private List<OrderDetail> _details;
        private Customer _customer;

        public void Print(Order order, List<OrderDetail> details, Customer customer)
        {
            _order = order;
            _details = details;
            _customer = customer;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPageContent);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void PrintPageContent(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Arial", 18, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 12, FontStyle.Bold);
            Font fontNormal = new Font("Arial", 10);
            Font fontItalic = new Font("Arial", 10, FontStyle.Italic);

            float yPos = 20;
            float leftMargin = 50;

            g.DrawString("CỬA HÀNG VẬT TƯ NÔNG NGHIỆP", fontTitle, Brushes.Black, leftMargin + 100, yPos);
            yPos += 40;
            g.DrawString("Đ/C: Huyện ABC, Tỉnh XYZ - SĐT: 09xx.xxx.xxx", fontNormal, Brushes.Black, leftMargin + 140, yPos);
            yPos += 40;

            g.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
            yPos += 10;
            g.DrawString("HÓA ĐƠN BÁN HÀNG", fontHeader, Brushes.Black, leftMargin + 200, yPos);
            yPos += 30;

            g.DrawString($"Khách hàng: {_customer?.Name ?? "Khách lẻ"}", fontNormal, Brushes.Black, leftMargin, yPos);
            g.DrawString($"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm}", fontNormal, Brushes.Black, e.PageBounds.Width - 250, yPos);
            yPos += 25;
            g.DrawString($"Địa chỉ: {_customer?.Address}", fontNormal, Brushes.Black, leftMargin, yPos);
            yPos += 35;

            g.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
            yPos += 5;
            g.DrawString("Tên Sản Phẩm", fontHeader, Brushes.Black, leftMargin, yPos);
            g.DrawString("Số Lượng", fontHeader, Brushes.Black, leftMargin + 250, yPos);
            g.DrawString("Đơn Giá", fontHeader, Brushes.Black, leftMargin + 350, yPos);
            g.DrawString("Thành Tiền", fontHeader, Brushes.Black, leftMargin + 480, yPos);
            yPos += 25;
            g.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
            yPos += 10;

            foreach (var item in _details)
            {
                string prodName = item.ProductVariant?.Product?.Name ?? "Sản phẩm " + item.VariantID;
                g.DrawString(prodName, fontNormal, Brushes.Black, leftMargin, yPos);
                g.DrawString(item.OrderQuantity.ToString(), fontNormal, Brushes.Black, leftMargin + 270, yPos);
                g.DrawString(item.UnitPrice.ToString("N0"), fontNormal, Brushes.Black, leftMargin + 350, yPos);
                
                decimal total = item.OrderQuantity * item.UnitPrice;
                g.DrawString(total.ToString("N0"), fontNormal, Brushes.Black, leftMargin + 480, yPos);
                yPos += 20;
            }

            yPos += 20;
            g.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
            yPos += 10;

            g.DrawString("TỔNG THANH TOÁN:", fontHeader, Brushes.Black, leftMargin + 300, yPos);
            g.DrawString(_order.TotalAmount.ToString("N0"), fontHeader, Brushes.Black, leftMargin + 480, yPos);
            yPos += 40;

            g.DrawString("Cảm ơn Quý khách, hẹn gặp lại!", fontItalic, Brushes.Black, leftMargin + 180, yPos);
        }
    }
}
