using iTextSharp.text;
using iTextSharp.text.pdf;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Utils
{
    public class ReportHelper
    {
        private static string fontPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");

        private static void ThemCell(PdfPTable bang, string noiDung, Font font,
            int canLe = Element.ALIGN_LEFT, BaseColor mauNen = null)
        {
            PdfPCell cell = new PdfPCell(new Phrase(noiDung, font));
            cell.HorizontalAlignment = canLe;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Padding = 5;
            if (mauNen != null)
                cell.BackgroundColor = mauNen;
            bang.AddCell(cell);
        }

        public static void XuatReportLoHang(List<BatchViewModel> danhSach, string filePath)
        {
            Document doc = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30);
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font fontTieuDe = new Font(bf, 16, Font.BOLD);
                Font fontNgayXuat = new Font(bf, 10, Font.ITALIC);
                Font fontCot = new Font(bf, 10, Font.BOLD, BaseColor.WHITE);
                Font fontNoiDung = new Font(bf, 9, Font.NORMAL);
                Font fontTong = new Font(bf, 10, Font.BOLD);

                BaseColor mauHeader = new BaseColor(46, 125, 50);   
                BaseColor mauTong = new BaseColor(232, 245, 233);  

                Paragraph tieuDe = new Paragraph("BÁO CÁO DANH SÁCH LÔ HÀNG", fontTieuDe);
                tieuDe.Alignment = Element.ALIGN_CENTER;
                doc.Add(tieuDe);

                Paragraph ngayXuat = new Paragraph("Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNgayXuat);
                ngayXuat.Alignment = Element.ALIGN_RIGHT;
                doc.Add(ngayXuat);
                doc.Add(new Paragraph("\n"));

                PdfPTable bang = new PdfPTable(10);
                bang.WidthPercentage = 100;
                bang.SetWidths(new float[] { 6f, 18f, 14f, 16f, 10f, 9f, 9f, 10f, 10f, 11f });

                // Header
                string[] tieuDeCot = {
                    "Mã Lô", "Tên Sản Phẩm", "Biến Thể", "Nhà Cung Cấp",
                    "Giá Nhập", "SL Ban Đầu", "SL Còn Lại", "NSX", "HSD", "Trạng Thái"
                };
                foreach (string tdc in tieuDeCot)
                    ThemCell(bang, tdc, fontCot, Element.ALIGN_CENTER, mauHeader);

                // Dữ liệu
                foreach (var lo in danhSach)
                {
                    BaseColor mauTrangThai = BaseColor.BLACK;
                    if (lo.TrangThai == "Hết hạn")
                        mauTrangThai = BaseColor.RED;

                    else if (lo.TrangThai == "Sắp hết hạn")
                        mauTrangThai = new BaseColor(255, 140, 0); 

                    else
                        mauTrangThai = new BaseColor(27, 94, 32);  

                    Font fontTrangThai = new Font(bf, 9, Font.BOLD, mauTrangThai);

                    ThemCell(bang, lo.BatchID.ToString(), fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, lo.TenSanPham, fontNoiDung);
                    ThemCell(bang, lo.BienThe, fontNoiDung);
                    ThemCell(bang, lo.NhaCungCap, fontNoiDung);
                    ThemCell(bang, lo.GiaNhap.ToString("N0") + " đ", fontNoiDung, Element.ALIGN_RIGHT);
                    ThemCell(bang, lo.SoLuongBanDau.ToString(), fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, lo.SoLuongConLai.ToString(), fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, lo.NgaySanXuat.HasValue ? lo.NgaySanXuat.Value.ToString("dd/MM/yyyy") : "", fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, lo.HanSuDung.HasValue ? lo.HanSuDung.Value.ToString("dd/MM/yyyy") : "", fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, lo.TrangThai, fontTrangThai, Element.ALIGN_CENTER);
                }

                // Dòng tổng
                PdfPCell cellTongLabel = new PdfPCell(new Phrase("Tổng số lô hàng: " + danhSach.Count, fontTong));
                cellTongLabel.Colspan = 10;
                cellTongLabel.BackgroundColor = mauTong;
                cellTongLabel.Padding = 6;
                bang.AddCell(cellTongLabel);

                doc.Add(bang);
                doc.Close();

                MessageBox.Show("Xuất Report thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try { System.Diagnostics.Process.Start(filePath); } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất report: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (doc.IsOpen()) doc.Close();
            }
        }

        public static void XuatReportSanPham(List<Product> danhSach, string filePath)
        {
            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font fontTieuDe = new Font(bf, 16, Font.BOLD);
                Font fontNgayXuat = new Font(bf, 10, Font.ITALIC);
                Font fontCot = new Font(bf, 10, Font.BOLD, BaseColor.WHITE);
                Font fontNoiDung = new Font(bf, 9, Font.NORMAL);
                Font fontSP = new Font(bf, 9, Font.BOLD);
                Font fontTong = new Font(bf, 10, Font.BOLD);

                BaseColor mauHeader = new BaseColor(230, 81, 0);    
                BaseColor mauSP = new BaseColor(255, 243, 224); 
                BaseColor mauTong = new BaseColor(255, 224, 178); 

                Paragraph tieuDe = new Paragraph("DANH SÁCH SẢN PHẨM", fontTieuDe);
                tieuDe.Alignment = Element.ALIGN_CENTER;
                doc.Add(tieuDe);

                Paragraph ngayXuat = new Paragraph(
                    "Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNgayXuat);
                ngayXuat.Alignment = Element.ALIGN_RIGHT;
                doc.Add(ngayXuat);
                doc.Add(new Paragraph("\n"));

                PdfPTable bang = new PdfPTable(4);
                bang.WidthPercentage = 100;
                bang.SetWidths(new float[] { 10f, 25f, 15f, 50f });

                // Header
                string[] tieuDeCot = { "Mã SP", "Tên Sản Phẩm", "Loại", "Mô Tả" };
                foreach (string tdc in tieuDeCot)
                    ThemCell(bang, tdc, fontCot, Element.ALIGN_CENTER, mauHeader);

                // Dữ liệu
                foreach (var sp in danhSach)
                {
                    ThemCell(bang, sp.ProductID.ToString(), fontSP, Element.ALIGN_CENTER, mauSP);
                    ThemCell(bang, sp.Name, fontSP, Element.ALIGN_LEFT, mauSP);
                    ThemCell(bang, sp.Category?.Name ?? sp.CategoryID.ToString(), fontNoiDung, Element.ALIGN_LEFT, mauSP);
                    ThemCell(bang, sp.Description ?? "", fontNoiDung, Element.ALIGN_LEFT, mauSP);
                }

                // Dòng tổng
                PdfPCell cellTong = new PdfPCell(new Phrase("Tổng số sản phẩm: " + danhSach.Count, fontTong));
                cellTong.Colspan = 4;
                cellTong.BackgroundColor = mauTong;
                cellTong.Padding = 6;
                bang.AddCell(cellTong);

                doc.Add(bang);
                doc.Close();

                MessageBox.Show("Xuất Report thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try { System.Diagnostics.Process.Start(filePath); } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất report: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (doc.IsOpen()) doc.Close();
            }
        }

        public static void XuatReportNhaCungCap(List<Supplier> danhSach, string filePath)
        {
            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font fontTieuDe = new Font(bf, 16, Font.BOLD);
                Font fontNgayXuat = new Font(bf, 10, Font.ITALIC);
                Font fontCot = new Font(bf, 10, Font.BOLD, BaseColor.WHITE);
                Font fontNoiDung = new Font(bf, 9, Font.NORMAL);
                Font fontTong = new Font(bf, 10, Font.BOLD);

                BaseColor mauHeader = new BaseColor(21, 101, 192);   
                BaseColor mauTong = new BaseColor(227, 242, 253);  

                Paragraph tieuDe = new Paragraph("DANH SÁCH NHÀ CUNG CẤP", fontTieuDe);
                tieuDe.Alignment = Element.ALIGN_CENTER;
                doc.Add(tieuDe);

                Paragraph ngayXuat = new Paragraph(
                    "Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNgayXuat);
                ngayXuat.Alignment = Element.ALIGN_RIGHT;
                doc.Add(ngayXuat);
                doc.Add(new Paragraph("\n"));

                PdfPTable bang = new PdfPTable(5);
                bang.WidthPercentage = 100;
                bang.SetWidths(new float[] { 10f, 25f, 18f, 35f, 12f });

                // Header
                string[] tieuDeCot = { "Mã NCC", "Tên Nhà Cung Cấp", "Số Điện Thoại", "Địa Chỉ", "Ngày Tạo" };
                foreach (string tdc in tieuDeCot)
                    ThemCell(bang, tdc, fontCot, Element.ALIGN_CENTER, mauHeader);

                // Dữ liệu
                foreach (var ncc in danhSach)
                {
                    ThemCell(bang, ncc.SupplierID.ToString(), fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, ncc.Name, fontNoiDung);
                    ThemCell(bang, ncc.Phone ?? "", fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, ncc.Address ?? "", fontNoiDung);
                    ThemCell(bang, ncc.CreatedAt?.ToString("dd/MM/yyyy") ?? "", fontNoiDung, Element.ALIGN_CENTER);
                }

                // Dòng tổng
                PdfPCell cellTong = new PdfPCell(new Phrase("Tổng số nhà cung cấp: " + danhSach.Count, fontTong));
                cellTong.Colspan = 5;
                cellTong.BackgroundColor = mauTong;
                cellTong.Padding = 6;
                bang.AddCell(cellTong);

                doc.Add(bang);
                doc.Close();

                MessageBox.Show("Xuất Report thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try { System.Diagnostics.Process.Start(filePath); } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất report: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (doc.IsOpen()) doc.Close();
            }
        }

        public static void XuatReportKhachHang(List<Customer> danhSach, string filePath)
        {
            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font fontTieuDe = new Font(bf, 16, Font.BOLD);
                Font fontNgayXuat = new Font(bf, 10, Font.ITALIC);
                Font fontCot = new Font(bf, 10, Font.BOLD, BaseColor.WHITE);
                Font fontNoiDung = new Font(bf, 9, Font.NORMAL);
                Font fontTong = new Font(bf, 10, Font.BOLD);

                BaseColor mauHeader = new BaseColor(21, 101, 192);  
                BaseColor mauTong = new BaseColor(227, 242, 253); 

                Paragraph tieuDe = new Paragraph("DANH SÁCH KHÁCH HÀNG", fontTieuDe);
                tieuDe.Alignment = Element.ALIGN_CENTER;
                doc.Add(tieuDe);

                Paragraph ngayXuat = new Paragraph(
                    "Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNgayXuat);
                ngayXuat.Alignment = Element.ALIGN_RIGHT;
                doc.Add(ngayXuat);
                doc.Add(new Paragraph("\n"));

                PdfPTable bang = new PdfPTable(5);
                bang.WidthPercentage = 100;
                bang.SetWidths(new float[] { 10f, 25f, 18f, 35f, 12f });

                // Header
                string[] tieuDeCot = { "Mã KH", "Họ Tên", "Số Điện Thoại", "Địa Chỉ", "Ngày Tạo" };
                foreach (string tdc in tieuDeCot)
                    ThemCell(bang, tdc, fontCot, Element.ALIGN_CENTER, mauHeader);

                // Dữ liệu
                foreach (var kh in danhSach)
                {
                    ThemCell(bang, kh.CustomerID.ToString(), fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, kh.Name ?? "", fontNoiDung);
                    ThemCell(bang, kh.Phone ?? "", fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, kh.Address ?? "", fontNoiDung);
                    ThemCell(bang, kh.CreatedAt?.ToString("dd/MM/yyyy") ?? "", fontNoiDung, Element.ALIGN_CENTER);
                }

                // Dòng tổng
                PdfPCell cellTong = new PdfPCell(new Phrase("Tổng số khách hàng: " + danhSach.Count, fontTong));
                cellTong.Colspan = 5;
                cellTong.BackgroundColor = mauTong;
                cellTong.Padding = 6;
                bang.AddCell(cellTong);

                doc.Add(bang);
                doc.Close();

                MessageBox.Show("Xuất Report thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try { System.Diagnostics.Process.Start(filePath); } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất report: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (doc.IsOpen()) doc.Close();
            }
        }
    }
}