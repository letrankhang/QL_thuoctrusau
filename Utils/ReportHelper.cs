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
        private static string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");

        private const string TEN_CUA_HANG = "CỬA HÀNG BÁN THUỐC TRỪ SÂU K3G";
        private const string SLOGAN = "Trao chất lượng – Nhận niềm tin - Cho mùa vàng trĩu hạt";
        private const string DIA_CHI = "TP. Cao Lãnh, tỉnh Đồng Tháp";
        //private const string EMAIL = "k3g.thuoctrusau@gmail.com";
        private const string SDT = "0814.999.999";

        public static string NguoiDangNhap { get; set; } = "";
        public static string ChucVu { get; set; } = "";

        private static void ThemCell(PdfPTable bang, string noiDung, Font font, int canLe = Element.ALIGN_LEFT, BaseColor mauNen = null)
        {
            PdfPCell cell = new PdfPCell(new Phrase(noiDung, font));
            cell.HorizontalAlignment = canLe;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Padding = 5;
            cell.BorderColor = BaseColor.BLACK;

            if (mauNen != null)
                cell.BackgroundColor = mauNen;

            bang.AddCell(cell);
        }

        private static void ThemHeaderCuaHang(Document doc, BaseFont bf, string tieuDeBaoCao)
        {
            Font fontTenCH = new Font(bf, 14, Font.BOLD);
            Font fontSlogan = new Font(bf, 10, Font.ITALIC);
            Font fontDiaChi = new Font(bf, 10, Font.NORMAL);
            Font fontInfo = new Font(bf, 10, Font.NORMAL);
            Font fontInfoBold = new Font(bf, 10, Font.BOLD);
            Font fontTieuDe = new Font(bf, 16, Font.BOLD);
            Font fontNgayXuat = new Font(bf, 10, Font.ITALIC);

            try
            {
                System.Drawing.Image imgLogo = Properties.Resources.Logo;
                using (MemoryStream ms = new MemoryStream())
                {
                    imgLogo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ms.ToArray());
                    logo.ScaleToFit(80f, 80f);
                    logo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(logo);
                }
            }
            catch 
            { 
                //
            }

            Paragraph tenCH = new Paragraph(TEN_CUA_HANG, fontTenCH);
            tenCH.Alignment = Element.ALIGN_CENTER;
            doc.Add(tenCH);

            Paragraph slogan = new Paragraph(SLOGAN, fontSlogan);
            slogan.Alignment = Element.ALIGN_CENTER;
            doc.Add(slogan);

            doc.Add(new Paragraph("\n"));

            PdfPTable bangInfo = new PdfPTable(2);
            bangInfo.WidthPercentage = 100;
            bangInfo.SetWidths(new float[] { 50f, 50f });
            bangInfo.SpacingAfter = 10f;

            PdfPCell cellTrai = new PdfPCell();
            cellTrai.Border = PdfPCell.NO_BORDER;
            cellTrai.PaddingLeft = 5f;

            Paragraph p1 = new Paragraph();
            p1.Add(new Chunk("Người thực hiện: ", fontInfoBold));
            p1.Add(new Chunk(NguoiDangNhap, fontInfo));
            cellTrai.AddElement(p1);

            Paragraph p1b = new Paragraph();  
            p1b.Add(new Chunk("Chức vụ: ", fontInfoBold));
            p1b.Add(new Chunk(ChucVu, fontInfo));
            cellTrai.AddElement(p1b);

            Paragraph p2 = new Paragraph();
            p2.Add(new Chunk("Ngày lập: ", fontInfoBold));
            p2.Add(new Chunk(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), fontInfo));
            cellTrai.AddElement(p2);

            bangInfo.AddCell(cellTrai);

            PdfPCell cellPhai = new PdfPCell();
            cellPhai.Border = PdfPCell.NO_BORDER;
            cellPhai.HorizontalAlignment = Element.ALIGN_RIGHT;

            Paragraph p3 = new Paragraph("ĐC: " + DIA_CHI, fontInfo);
            p3.Alignment = Element.ALIGN_RIGHT;
            cellPhai.AddElement(p3);

            Paragraph p4 = new Paragraph("Email: k3g.thuoctrusau@gmail.com", fontInfo);
            p4.Alignment = Element.ALIGN_RIGHT;
            cellPhai.AddElement(p4);

            Paragraph p5 = new Paragraph("SĐT: " + SDT, fontInfo);
            p5.Alignment = Element.ALIGN_RIGHT;
            cellPhai.AddElement(p5);

            bangInfo.AddCell(cellPhai);

            doc.Add(bangInfo);

            Paragraph tieuDe = new Paragraph(tieuDeBaoCao, fontTieuDe);
            tieuDe.Alignment = Element.ALIGN_CENTER;
            doc.Add(tieuDe);

            doc.Add(new Paragraph("\n"));
        }

        private static void ThemKyTen(Document doc, BaseFont bf)
        {
            Font fontKy = new Font(bf, 10, Font.ITALIC);
            Font fontKyBold = new Font(bf, 10, Font.BOLD);
            Font fontKyNormal = new Font(bf, 10, Font.NORMAL);

            DateTime now = DateTime.Now;
            Paragraph ngayKy = new Paragraph($"Cao Lãnh, ngày {now.Day} tháng {now.Month} năm {now.Year}", fontKy);
            ngayKy.Alignment = Element.ALIGN_RIGHT;
            doc.Add(ngayKy);

            doc.Add(new Paragraph("\n"));

            PdfPTable bangKy = new PdfPTable(2);
            bangKy.WidthPercentage = 100;
            bangKy.SetWidths(new float[] { 50f, 50f });

            PdfPCell cellNguoiLap = new PdfPCell();
            cellNguoiLap.Border = PdfPCell.NO_BORDER;
            cellNguoiLap.AddElement(new Paragraph("NGƯỜI LẬP BÁO CÁO\n\n", fontKyBold)
            { 
                Alignment = Element.ALIGN_CENTER 
            });
            cellNguoiLap.AddElement(new Paragraph("(Ký, họ tên)", fontKyNormal)
            { 
                Alignment = Element.ALIGN_CENTER 
            });
            cellNguoiLap.AddElement(new Paragraph("\n\n", fontKyNormal));
            bangKy.AddCell(cellNguoiLap);

            PdfPCell cellChuCH = new PdfPCell();
            cellChuCH.Border = PdfPCell.NO_BORDER;
            cellChuCH.AddElement(new Paragraph("CHỦ CỬA HÀNG\n\n", fontKyBold)
            { 
                Alignment = Element.ALIGN_CENTER 
            });
            cellChuCH.AddElement(new Paragraph("(Ký, họ tên)", fontKyNormal)
            { 
                Alignment = Element.ALIGN_CENTER 
            });
            cellChuCH.AddElement(new Paragraph("\n\n", fontKyNormal));
            bangKy.AddCell(cellChuCH);

            doc.Add(bangKy);
        }

        public static void XuatReportLoHang(List<BatchViewModel> danhSach, string filePath)
        {
            Document doc = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30);
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font fontCot = new Font(bf, 10, Font.BOLD, BaseColor.WHITE);
                Font fontNoiDung = new Font(bf, 9, Font.NORMAL);
                Font fontTong = new Font(bf, 10, Font.BOLD);

                BaseColor mauHeader = new BaseColor(46, 125, 50);
                BaseColor mauTong = new BaseColor(232, 245, 233);

                ThemHeaderCuaHang(doc, bf, "BÁO CÁO DANH SÁCH LÔ HÀNG");

                PdfPTable bang = new PdfPTable(10);
                bang.WidthPercentage = 100;
                bang.SetWidths(new float[] { 6f, 18f, 14f, 16f, 10f, 9f, 9f, 10f, 10f, 11f });

                string[] tieuDeCot = {
                    "Mã Lô", "Tên Sản Phẩm", "Biến Thể", "Nhà Cung Cấp",
                    "Giá Nhập", "SL Ban Đầu", "SL Còn Lại", "NSX", "HSD", "Trạng Thái"
                };
                foreach (string tdc in tieuDeCot)
                    ThemCell(bang, tdc, fontCot, Element.ALIGN_CENTER, mauHeader);

                foreach (var lo in danhSach)
                {
                    BaseColor mauTrangThai;
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

                PdfPCell cellTong = new PdfPCell(new Phrase("Tổng số lô hàng: " + danhSach.Count, fontTong));
                cellTong.Colspan = 10;
                cellTong.BackgroundColor = mauTong;
                cellTong.Padding = 6;
                bang.AddCell(cellTong);

                doc.Add(bang);

                ThemKyTen(doc, bf);

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
                if (doc.IsOpen())
                    doc.Close();
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
                Font fontCot = new Font(bf, 10, Font.BOLD, BaseColor.WHITE);
                Font fontSP = new Font(bf, 9, Font.BOLD);
                Font fontBienThe = new Font(bf, 9, Font.NORMAL);
                Font fontTong = new Font(bf, 10, Font.BOLD);

                BaseColor mauHeader = new BaseColor(230, 81, 0);
                BaseColor mauSP = new BaseColor(255, 243, 224);
                BaseColor mauTong = new BaseColor(255, 224, 178);

                ThemHeaderCuaHang(doc, bf, "DANH SÁCH CHI TIẾT SẢN PHẨM & BIẾN THỂ");

                PdfPTable bang = new PdfPTable(7);
                bang.WidthPercentage = 100;
                bang.SetWidths(new float[] { 8f, 24f, 14f, 10f, 14f, 15f, 15f });

                string[] tieuDeCot = { "Mã SP", "Tên Sản Phẩm / Biến Thể", "Loại", "Đơn Vị", "Hàm Lượng", "Giá Bán Lẻ", "Giá Bán Sỉ" };
                foreach (string tdc in tieuDeCot)
                    ThemCell(bang, tdc, fontCot, Element.ALIGN_CENTER, mauHeader);

                foreach (var sp in danhSach)
                {
                    ThemCell(bang, sp.ProductID.ToString(), fontSP, Element.ALIGN_CENTER, mauSP);
                    ThemCell(bang, sp.Name, fontSP, Element.ALIGN_LEFT, mauSP);
                    ThemCell(bang, sp.Category?.Name ?? sp.CategoryID.ToString(), fontSP, Element.ALIGN_LEFT, mauSP);
                    ThemCell(bang, "", fontSP, Element.ALIGN_LEFT, mauSP);
                    ThemCell(bang, "", fontSP, Element.ALIGN_LEFT, mauSP);
                    ThemCell(bang, "", fontSP, Element.ALIGN_LEFT, mauSP);
                    ThemCell(bang, "", fontSP, Element.ALIGN_LEFT, mauSP);

                    if (sp.ProductVariants != null && sp.ProductVariants.Count > 0)
                    {
                        foreach (var v in sp.ProductVariants)
                        {
                            string tenBienThe = "- " + v.Unit +
                                (string.IsNullOrEmpty(v.Concentration) ? "" : " (" + v.Concentration + ")");

                            string[] gt = { "", tenBienThe, "", v.Unit ?? "", v.Concentration ?? "",
                                v.RetailPrice.ToString("N0") + " đ", v.WholesalePrice.ToString("N0") + " đ" };
                            int[] cl = { Element.ALIGN_CENTER, Element.ALIGN_LEFT, Element.ALIGN_LEFT,
                                Element.ALIGN_CENTER, Element.ALIGN_CENTER, Element.ALIGN_RIGHT, Element.ALIGN_RIGHT };

                            for (int i = 0; i < gt.Length; i++)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(gt[i], fontBienThe));
                                cell.HorizontalAlignment = cl[i];
                                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                cell.Padding = 5;
                                cell.BorderWidthBottom = 0.5f;
                                cell.BorderWidthTop = 0;
                                cell.BorderWidthLeft = (i == 0) ? 0.5f : 0;   
                                cell.BorderWidthRight = (i == gt.Length - 1) ? 0.5f : 0;
                                cell.BorderColor = BaseColor.BLACK;
                                bang.AddCell(cell);
                            }
                        }
                    }
                }

                PdfPCell cellTong = new PdfPCell(new Phrase("Tổng số sản phẩm chính: " + danhSach.Count, fontTong));
                cellTong.Colspan = 7;
                cellTong.BackgroundColor = mauTong;
                cellTong.Padding = 6;
                bang.AddCell(cellTong);

                doc.Add(bang);

                ThemKyTen(doc, bf);

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
                if (doc.IsOpen())
                    doc.Close();
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
                Font fontCot = new Font(bf, 10, Font.BOLD, BaseColor.WHITE);
                Font fontNoiDung = new Font(bf, 9, Font.NORMAL);
                Font fontTong = new Font(bf, 10, Font.BOLD);

                BaseColor mauHeader = new BaseColor(21, 101, 192);
                BaseColor mauTong = new BaseColor(227, 242, 253);

                ThemHeaderCuaHang(doc, bf, "DANH SÁCH NHÀ CUNG CẤP");

                PdfPTable bang = new PdfPTable(5);
                bang.WidthPercentage = 100;
                bang.SetWidths(new float[] { 10f, 25f, 18f, 35f, 12f });

                string[] tieuDeCot = { "Mã NCC", "Tên Nhà Cung Cấp", "Số Điện Thoại", "Địa Chỉ", "Ngày Tạo" };
                foreach (string tdc in tieuDeCot)
                    ThemCell(bang, tdc, fontCot, Element.ALIGN_CENTER, mauHeader);

                foreach (var ncc in danhSach)
                {
                    ThemCell(bang, ncc.SupplierID.ToString(), fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, ncc.Name, fontNoiDung);
                    ThemCell(bang, ncc.Phone ?? "", fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, ncc.Address ?? "", fontNoiDung);
                    ThemCell(bang, ncc.CreatedAt?.ToString("dd/MM/yyyy") ?? "", fontNoiDung, Element.ALIGN_CENTER);
                }

                PdfPCell cellTong = new PdfPCell(new Phrase("Tổng số nhà cung cấp: " + danhSach.Count, fontTong));
                cellTong.Colspan = 5;
                cellTong.BackgroundColor = mauTong;
                cellTong.Padding = 6;
                bang.AddCell(cellTong);

                doc.Add(bang);

                ThemKyTen(doc, bf);

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
                if (doc.IsOpen())
                    doc.Close();
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
                Font fontCot = new Font(bf, 10, Font.BOLD, BaseColor.WHITE);
                Font fontNoiDung = new Font(bf, 9, Font.NORMAL);
                Font fontTong = new Font(bf, 10, Font.BOLD);

                BaseColor mauHeader = new BaseColor(21, 101, 192);
                BaseColor mauTong = new BaseColor(227, 242, 253);

                ThemHeaderCuaHang(doc, bf, "DANH SÁCH KHÁCH HÀNG");

                PdfPTable bang = new PdfPTable(5);
                bang.WidthPercentage = 100;
                bang.SetWidths(new float[] { 10f, 25f, 18f, 35f, 12f });

                string[] tieuDeCot = { "Mã KH", "Họ Tên", "Số Điện Thoại", "Địa Chỉ", "Ngày Tạo" };
                foreach (string tdc in tieuDeCot)
                    ThemCell(bang, tdc, fontCot, Element.ALIGN_CENTER, mauHeader);

                foreach (var kh in danhSach)
                {
                    ThemCell(bang, kh.CustomerID.ToString(), fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, kh.Name ?? "", fontNoiDung);
                    ThemCell(bang, kh.Phone ?? "", fontNoiDung, Element.ALIGN_CENTER);
                    ThemCell(bang, kh.Address ?? "", fontNoiDung);
                    ThemCell(bang, kh.CreatedAt?.ToString("dd/MM/yyyy") ?? "", fontNoiDung, Element.ALIGN_CENTER);
                }

                PdfPCell cellTong = new PdfPCell(new Phrase("Tổng số khách hàng: " + danhSach.Count, fontTong));
                cellTong.Colspan = 5;
                cellTong.BackgroundColor = mauTong;
                cellTong.Padding = 6;
                bang.AddCell(cellTong);

                doc.Add(bang);

                ThemKyTen(doc, bf);

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
                if (doc.IsOpen()) 
                    doc.Close(); 
            }
        }
    }
}