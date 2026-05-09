using iTextSharp.text;
using iTextSharp.text.pdf;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Utils
{
    public class InvoicePrinter
    {
        private static string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");

        public void ExportToPdf(Order order, string filePath)
        {
            if (order == null) return;

            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Cấu hình font tiếng Việt
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font fontNormal = new Font(bf, 11, Font.NORMAL);
                Font fontBold = new Font(bf, 11, Font.BOLD);
                Font fontItalic = new Font(bf, 11, Font.ITALIC);
                Font fontTitle = new Font(bf, 18, Font.BOLD, BaseColor.BLACK);
                Font fontHeader = new Font(bf, 14, Font.BOLD);

                // 1. Header Công ty
                Paragraph headerCompany = new Paragraph("CỬA HÀNG BÁN THUỐC TRỪ SÂU K3G\nTrao chất lượng – Nhận niềm tin - Cho mùa vàng trĩu hạt", fontHeader);
                headerCompany.Alignment = Element.ALIGN_CENTER;
                document.Add(headerCompany);

                Paragraph headerAddr = new Paragraph("ĐC: TP. Cao Lãnh, tỉnh Đồng Tháp\nĐT: 0814.999.999", fontNormal);
                headerAddr.Alignment = Element.ALIGN_CENTER;
                document.Add(headerAddr);

                document.Add(new Paragraph("\n"));

                // 2. Tiêu đề hóa đơn
                Paragraph title = new Paragraph("HOÁ ĐƠN BÁN HÀNG", fontTitle);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                Paragraph subTitle = new Paragraph($"Mã hóa đơn: #{order.OrderID} - Ngày: {order.OrderDate:dd/MM/yyyy HH:mm}", fontItalic);
                subTitle.Alignment = Element.ALIGN_CENTER;
                document.Add(subTitle);
                document.Add(new Paragraph("\n"));

                // 3. Thông tin khách hàng
                document.Add(new Paragraph($"Tên khách hàng: {order.Customer?.Name ?? "..................................................."}", fontNormal));
                document.Add(new Paragraph($"Địa chỉ: {order.Customer?.Address ?? "..................................................."}", fontNormal));
                document.Add(new Paragraph($"Điện thoại: {order.Customer?.Phone ?? "..................................................."}", fontNormal));
                document.Add(new Paragraph("\n"));

                // 4. Bảng danh sách sản phẩm
                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 10f, 40f, 15f, 15f, 20f });

                // Header bảng
                AddCellToTable(table, "STT", fontBold);
                AddCellToTable(table, "Tên hàng", fontBold);
                AddCellToTable(table, "Số lượng", fontBold);
                AddCellToTable(table, "Đơn giá", fontBold);
                AddCellToTable(table, "Thành tiền", fontBold);

                int stt = 1;
                if (order.OrderDetails != null)
                {
                    foreach (var detail in order.OrderDetails)
                    {
                        AddCellToTable(table, stt++.ToString(), fontNormal);
                        string productName = detail.ProductVariant?.Product?.Name ?? "N/A";
                        if (!string.IsNullOrEmpty(detail.ProductVariant?.Unit))
                            productName += $" ({detail.ProductVariant.Unit})";

                        AddCellToTable(table, productName, fontNormal);
                        AddCellToTable(table, detail.OrderQuantity.ToString("N0"), fontNormal, Element.ALIGN_RIGHT);
                        AddCellToTable(table, detail.UnitPrice.ToString("N0"), fontNormal, Element.ALIGN_RIGHT);
                        AddCellToTable(table, (detail.OrderQuantity * detail.UnitPrice).ToString("N0"), fontNormal, Element.ALIGN_RIGHT);
                    }
                }

                // Dòng tổng cộng
                PdfPCell cellTotalLabel = new PdfPCell(new Phrase("Tổng cộng", fontBold));
                cellTotalLabel.Colspan = 4;
                cellTotalLabel.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTotalLabel.Padding = 5;
                table.AddCell(cellTotalLabel);

                PdfPCell cellTotalValue = new PdfPCell(new Phrase(order.TotalAmount.ToString("N0") + " đ", fontBold));
                cellTotalValue.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellTotalValue.Padding = 5;
                table.AddCell(cellTotalValue);

                // Tính toán tiền nợ và đã thanh toán
                decimal debtAmount = 0;
                if (order.DebtTransactions != null)
                {
                    // Lấy giao dịch nợ liên quan đến đơn hàng này (SALE hoặc DEBT)
                    debtAmount = order.DebtTransactions
                        .Where(t => t.TransactionType == "SALE" || t.TransactionType == "DEBT")
                        .Sum(t => t.Amount);
                }
                decimal paidAmount = order.TotalAmount - debtAmount;

                // Dòng đã thanh toán
                PdfPCell cellPaidLabel = new PdfPCell(new Phrase("Đã thanh toán", fontNormal));
                cellPaidLabel.Colspan = 4;
                cellPaidLabel.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellPaidLabel.Padding = 5;
                table.AddCell(cellPaidLabel);

                PdfPCell cellPaidValue = new PdfPCell(new Phrase(paidAmount.ToString("N0") + " đ", fontNormal));
                cellPaidValue.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellPaidValue.Padding = 5;
                table.AddCell(cellPaidValue);

                // Dòng còn nợ
                PdfPCell cellDebtLabel = new PdfPCell(new Phrase("Còn nợ", fontNormal));
                cellDebtLabel.Colspan = 4;
                cellDebtLabel.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellDebtLabel.Padding = 5;
                table.AddCell(cellDebtLabel);

                PdfPCell cellDebtValue = new PdfPCell(new Phrase(debtAmount.ToString("N0") + " đ", fontNormal));
                cellDebtValue.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellDebtValue.Padding = 5;
                table.AddCell(cellDebtValue);

                document.Add(table);
                document.Add(new Paragraph("\n"));

                // 5. Số tiền bằng chữ
                string amountInWords = NumberToWords(order.TotalAmount);
                document.Add(new Paragraph($"Thành tiền viết bằng chữ: {amountInWords}.", fontItalic));
                document.Add(new Paragraph("\n"));

                // 6. Chữ ký
                PdfPTable tableSign = new PdfPTable(2);
                tableSign.WidthPercentage = 100;
                tableSign.DefaultCell.Border = Rectangle.NO_BORDER;

                PdfPCell cellBuyer = new PdfPCell(new Phrase("\n\nKHÁCH HÀNG\n\n\n(Ký, họ tên)", fontBold));
                cellBuyer.Border = Rectangle.NO_BORDER;
                cellBuyer.HorizontalAlignment = Element.ALIGN_CENTER;
                tableSign.AddCell(cellBuyer);

                string dateStr = $"Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";
                PdfPCell cellSeller = new PdfPCell(new Phrase($"{dateStr}\n\nCHỦ CỬA HÀNG\n\n\n(Ký, họ tên)", fontBold));
                cellSeller.Border = Rectangle.NO_BORDER;
                cellSeller.HorizontalAlignment = Element.ALIGN_CENTER;
                tableSign.AddCell(cellSeller);

                document.Add(tableSign);

                document.Close();
                MessageBox.Show("Xuất hóa đơn thành công tại: " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở file sau khi xuất
                try { System.Diagnostics.Process.Start(filePath); } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (document.IsOpen()) document.Close();
            }
        }

        private void AddCellToTable(PdfPTable table, string text, Font font, int alignment = Element.ALIGN_LEFT)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.HorizontalAlignment = alignment;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Padding = 5;
            table.AddCell(cell);
        }

        #region Đọc số thành chữ
        public static string NumberToWords(decimal total)
        {
            try
            {
                string rs = "";
                total = Math.Round(total, 0);
                long n = (long)total;
                if (n == 0) return "Không đồng";
                if (n < 0) return "Âm " + NumberToWords(Math.Abs(n));

                string[] unit = { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
                int i = 0;
                while (n > 0)
                {
                    string temp = ReadGroup3(n % 1000);
                    if (temp != "") rs = temp + unit[i] + (rs != "" ? ", " : "") + rs;
                    n /= 1000;
                    i++;
                }
                rs = rs.Trim();
                if (rs.EndsWith(",")) rs = rs.Substring(0, rs.Length - 1);
                return rs.Substring(0, 1).ToUpper() + rs.Substring(1) + " đồng";
            }
            catch { return "Không thể đọc số"; }
        }

        private static string ReadGroup3(long n)
        {
            string[] digits = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string rs = "";
            int h = (int)(n / 100);
            int t = (int)((n % 100) / 10);
            int u = (int)(n % 10);

            if (h == 0 && t == 0 && u == 0) return "";

            if (h > 0)
            {
                rs += digits[h] + " trăm";
                if (t == 0 && u > 0) rs += " lẻ";
            }

            if (t > 0)
            {
                if (t == 1) rs += " mười";
                else rs += " " + digits[t] + " mươi";
            }

            if (u > 0)
            {
                if (t > 0 && u == 1 && t > 1) rs += " mốt";
                else if (t > 0 && u == 5) rs += " lăm";
                else rs += " " + digits[u];
            }

            return rs.Trim();
        }
        #endregion

        // Giữ lại phương thức cũ để tránh lỗi compile nếu có chỗ khác gọi (như Frm_BanHang)
        public void PrintInvoice(Order order, List<OrderDetail> details)
        {
            string fileName = $"HD_{order.OrderID}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            // Nếu OrderDetails chưa được nạp, gán tạm từ tham số
            if (order.OrderDetails == null) order.OrderDetails = details;

            ExportToPdf(order, path);
        }
    }
}
