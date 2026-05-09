using ClosedXML.Excel;
using QL_CuaHangBanThuocTruSau.BUS;
using QL_CuaHangBanThuocTruSau.Models;
using QL_CuaHangBanThuocTruSau.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QL_CuaHangBanThuocTruSau.Utils
{
    public class ExcelHelper
    {
        /// <summary>
        /// Phương thức xuất Excel generic cho các danh sách đơn giản
        /// </summary>
        public static void ExportToExcel<T>(IEnumerable<T> data, string fileName, string sheetName = "Data")
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files|*.xlsx";
                    sfd.FileName = fileName;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add(sheetName);
                            worksheet.Cell(1, 1).InsertTable(data);
                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Phương thức xuất Excel chuyên biệt cho Lô hàng (Stylized)
        /// </summary>
        public static void XuatExcelLoHang(List<BatchViewModel> danhSach, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Lô Hàng");

                // 1. Tiêu đề
                var titleRange = worksheet.Range("A1:J1");
                titleRange.Merge().Value = "BÁO CÁO DANH SÁCH LÔ HÀNG";
                titleRange.Style.Font.SetBold().Font.SetFontSize(16).Font.FontColor = XLColor.White;
                titleRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#2E7D32");
                titleRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // 2. Thông tin phụ
                worksheet.Cell("A2").Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                worksheet.Range("A2:J2").Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right).Font.SetItalic();

                // 3. Header bảng
                string[] headers = { "Mã Lô", "Tên Sản Phẩm", "Biến Thể", "Nhà Cung Cấp", "Giá Nhập", "SL Ban Đầu", "SL Còn Lại", "NSX", "HSD", "Trạng Thái" };
                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = worksheet.Cell(4, i + 1);
                    cell.Value = headers[i];
                    cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#E8F5E9");
                    cell.Style.Font.SetBold();
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                }

                // 4. Dữ liệu
                int row = 5;
                foreach (var item in danhSach)
                {
                    worksheet.Cell(row, 1).Value = item.BatchID;
                    worksheet.Cell(row, 2).Value = item.TenSanPham;
                    worksheet.Cell(row, 3).Value = item.BienThe;
                    worksheet.Cell(row, 4).Value = item.NhaCungCap;
                    worksheet.Cell(row, 5).Value = item.GiaNhap;
                    worksheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0\" đ\"";
                    worksheet.Cell(row, 6).Value = item.SoLuongBanDau;
                    worksheet.Cell(row, 7).Value = item.SoLuongConLai;
                    worksheet.Cell(row, 8).Value = item.NgaySanXuat;
                    worksheet.Cell(row, 8).Style.NumberFormat.Format = "dd/MM/yyyy";
                    worksheet.Cell(row, 9).Value = item.HanSuDung;
                    worksheet.Cell(row, 9).Style.NumberFormat.Format = "dd/MM/yyyy";
                    worksheet.Cell(row, 10).Value = item.TrangThai;

                    // Định dạng màu cho cột Trạng thái
                    var statusCell = worksheet.Cell(row, 10);
                    if (item.TrangThai == "Hết hạn") statusCell.Style.Font.FontColor = XLColor.Red;
                    else if (item.TrangThai == "Sắp hết hạn") statusCell.Style.Font.FontColor = XLColor.Orange;
                    else statusCell.Style.Font.FontColor = XLColor.Green;

                    worksheet.Range(row, 1, row, 10).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    row++;
                }

                // 5. Tổng kết
                int lastRow = row;
                worksheet.Cell(lastRow, 1).Value = "Tổng số lượng lô hàng:";
                worksheet.Cell(lastRow, 1).Style.Font.SetBold();
                worksheet.Cell(lastRow, 2).Value = danhSach.Count;
                worksheet.Cell(lastRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                // Tự động căn chỉnh
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }

        /// <summary>
        /// Phương thức xuất Excel cho danh sách Nhà cung cấp (Stylized)
        /// </summary>
        public static void XuatExcelNCC(List<Supplier> danhSach, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Nhà Cung Cấp");

                // 1. Tiêu đề
                var titleRange = worksheet.Range("A1:E1");
                titleRange.Merge().Value = "DANH SÁCH NHÀ CUNG CẤP";
                titleRange.Style.Font.SetBold().Font.SetFontSize(16).Font.FontColor = XLColor.White;
                titleRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#1976D2");
                titleRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // 2. Thông tin phụ
                worksheet.Cell("A2").Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                worksheet.Range("A2:E2").Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right).Font.SetItalic();

                // 3. Header bảng
                string[] headers = { "Mã NCC", "Tên Nhà Cung Cấp", "Số Điện Thoại", "Địa Chỉ", "Ngày Tạo" };
                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = worksheet.Cell(4, i + 1);
                    cell.Value = headers[i];
                    cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#E3F2FD");
                    cell.Style.Font.SetBold();
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                }

                // 4. Dữ liệu
                int row = 5;
                foreach (var item in danhSach)
                {
                    worksheet.Cell(row, 1).Value = item.SupplierID;
                    worksheet.Cell(row, 2).Value = item.Name;
                    worksheet.Cell(row, 3).Value = item.Phone;
                    worksheet.Cell(row, 4).Value = item.Address;
                    worksheet.Cell(row, 5).Value = item.CreatedAt;
                    worksheet.Cell(row, 5).Style.NumberFormat.Format = "dd/MM/yyyy";

                    worksheet.Range(row, 1, row, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    row++;
                }

                // 5. Tổng kết
                int lastRow = row;
                worksheet.Cell(lastRow, 1).Value = "Tổng số lượng NCC:";
                worksheet.Cell(lastRow, 1).Style.Font.SetBold();
                worksheet.Cell(lastRow, 2).Value = danhSach.Count;
                worksheet.Cell(lastRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                // Tự động căn chỉnh
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }

        /// <summary>
        /// Phương thức xuất Excel cho danh sách Sản phẩm (Stylized)
        /// </summary>
        public static void XuatExcelSanPham(List<Product> danhSach, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sản Phẩm");

                // 1. Tiêu đề
                var titleRange = worksheet.Range("A1:D1");
                titleRange.Merge().Value = "DANH SÁCH SẢN PHẨM";
                titleRange.Style.Font.SetBold().Font.SetFontSize(16).Font.FontColor = XLColor.White;
                titleRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#EF6C00");
                titleRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // 2. Thông tin phụ
                worksheet.Cell("A2").Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                worksheet.Range("A2:D2").Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right).Font.SetItalic();

                // 3. Header bảng
                string[] headers = { "Mã Sản Phẩm", "Tên Sản Phẩm", "Loại", "Mô Tả" };
                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = worksheet.Cell(4, i + 1);
                    cell.Value = headers[i];
                    cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#FFF3E0");
                    cell.Style.Font.SetBold();
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                }

                // 4. Dữ liệu
                int row = 5;
                foreach (var item in danhSach)
                {
                    worksheet.Cell(row, 1).Value = item.ProductID;
                    worksheet.Cell(row, 2).Value = item.Name;
                    worksheet.Cell(row, 3).Value = item.Category?.Name ?? item.CategoryID.ToString();
                    worksheet.Cell(row, 4).Value = item.Description;

                    worksheet.Range(row, 1, row, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    row++;
                }

                // 5. Tổng kết
                int lastRow = row;
                worksheet.Cell(lastRow, 1).Value = "Tổng số lượng sản phẩm:";
                worksheet.Cell(lastRow, 1).Style.Font.SetBold();
                worksheet.Cell(lastRow, 2).Value = danhSach.Count;
                worksheet.Cell(lastRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                // Tự động căn chỉnh
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }

        /// <summary>
        /// Phương thức xuất Excel chi tiết cho danh sách Sản phẩm kèm theo Biến thể
        /// </summary>
        public static void XuatExcelSanPhamChiTiet(List<Product> danhSach, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Chi Tiết Sản Phẩm");

                // 1. Tiêu đề
                var titleRange = worksheet.Range("A1:G1");
                titleRange.Merge().Value = "DANH SÁCH CHI TIẾT SẢN PHẨM & BIẾN THỂ";
                titleRange.Style.Font.SetBold().Font.SetFontSize(16).Font.FontColor = XLColor.White;
                titleRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#E65100");
                titleRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // 2. Thông tin phụ
                worksheet.Cell("A2").Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                worksheet.Range("A2:G2").Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right).Font.SetItalic();

                // 3. Header bảng
                string[] headers = { "Mã SP", "Tên Sản Phẩm / Biến Thể", "Loại", "Đơn Vị", "Hàm Lượng", "Giá Bán Lẻ", "Giá Bán Sỉ" };
                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = worksheet.Cell(4, i + 1);
                    cell.Value = headers[i];
                    cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#FFE0B2");
                    cell.Style.Font.SetBold();
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                }

                // 4. Dữ liệu
                int row = 5;
                foreach (var sp in danhSach)
                {
                    // Dòng sản phẩm chính
                    worksheet.Cell(row, 1).Value = sp.ProductID;
                    worksheet.Cell(row, 2).Value = sp.Name;
                    worksheet.Cell(row, 2).Style.Font.SetBold();
                    worksheet.Cell(row, 3).Value = sp.Category?.Name ?? sp.CategoryID.ToString();
                    
                    var productRange = worksheet.Range(row, 1, row, 7);
                    productRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#FFF3E0");
                    productRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    row++;

                    // Các dòng biến thể
                    if (sp.ProductVariants != null && sp.ProductVariants.Count > 0)
                    {
                        foreach (var v in sp.ProductVariants)
                        {
                            worksheet.Cell(row, 2).Value = "- " + v.Unit + (string.IsNullOrEmpty(v.Concentration) ? "" : " (" + v.Concentration + ")");
                            worksheet.Cell(row, 2).Style.Alignment.SetIndent(1);
                            worksheet.Cell(row, 4).Value = v.Unit;
                            worksheet.Cell(row, 5).Value = v.Concentration;
                            worksheet.Cell(row, 6).Value = v.RetailPrice;
                            worksheet.Cell(row, 6).Style.NumberFormat.Format = "#,##0\" đ\"";
                            worksheet.Cell(row, 7).Value = v.WholesalePrice;
                            worksheet.Cell(row, 7).Style.NumberFormat.Format = "#,##0\" đ\"";

                            worksheet.Range(row, 1, row, 7).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            row++;
                        }
                    }
                }

                // 5. Tổng kết
                int lastRow = row;
                worksheet.Cell(lastRow, 1).Value = "Tổng số lượng sản phẩm chính:";
                worksheet.Cell(lastRow, 1).Style.Font.SetBold();
                worksheet.Cell(lastRow, 2).Value = danhSach.Count;
                worksheet.Cell(lastRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                // Tự động căn chỉnh
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }

        /// <summary>
        /// Phương thức nhập Excel cho Sản phẩm
        /// </summary>
        public static void NhapExcel(ProductBUS bus)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Excel Files|*.xlsx";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook(ofd.FileName))
                        {
                            var worksheet = workbook.Worksheet(1);
                            var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Skip header

                            int count = 0;
                            foreach (var row in rows)
                            {
                                var sp = new Product
                                {
                                    ProductID = row.Cell(1).GetValue<int>(),
                                    Name = row.Cell(2).GetValue<string>(),
                                    CategoryID = row.Cell(3).GetValue<int>(),
                                    Description = row.Cell(4).GetValue<string>()
                                };

                                string loi = "";
                                if (bus.them(sp, out loi))
                                {
                                    count++;
                                }
                            }
                            MessageBox.Show($"Đã nhập thành công {count} sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhập Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
