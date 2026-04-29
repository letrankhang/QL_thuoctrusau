# ĐẶC TẢ NGHIỆP VỤ CHI TIẾT HỆ THỐNG QUẢN LÝ CỬA HÀNG VẬT TƯ NÔNG NGHIỆP

**Người soạn:** Senior Project Manager (10+ years experience)
**Dự án:** QL_CuaHangBanThuocTruSau
**Trạng thái:** Bản đặc tả chi tiết (Deep-dive Business Process)

---

## 1. QUY TRÌNH NHẬP KHO & ĐIỀU PHỐI LÔ (PROCUREMENT & BATCHING)
*Mục tiêu: Đảm bảo hàng vào kho được kiểm soát hạn sử dụng và giá vốn chính xác.*

1.  **Tiếp nhận hàng (Inbound):**
    *   Nhân viên kiểm tra thực tế hàng hóa từ Nhà cung cấp (`Supplier`).
    *   **Nghiệp vụ thực tế:** Đối với thuốc bảo vệ thực vật, hàng có thể nhập theo Thùng hoặc Chai lẻ. Hệ thống quản lý thông qua các `ProductVariant` tương ứng. Khi nhập hàng, nhân viên chọn đúng quy cách (Variant) và lô hàng (Batch) để ghi nhận kho.
2.  **Khởi tạo Lô hàng (`Batch`):**
    *   Mỗi lần nhập một loại thuốc, nếu có Ngày sản xuất (NSX) hoặc Số lô khác nhau, phải tách thành các `Batch` riêng biệt.
    *   **Ghi nhận giá vốn:** Giá vốn được tính theo từng lô (Batch Price). Điều này giúp tính lợi nhuận chính xác ngay cả khi giá nhập từ nhà sản xuất biến động theo tháng.
3.  **Kiểm tra chất lượng (QC Check):**
    *   Ghi chú tình trạng vỏ chai (có bị móp méo, rò rỉ không). Nếu có, thực hiện tạo `InventoryTransaction` loại "ADJUST_LOSS" để trừ kho ngay lập tức.

## 2. QUY TRÌNH BÁN HÀNG & XỬ LÝ ĐƠN VỊ TÍNH (SALES & UNIT CONVERSION)
*Mục tiêu: Bán hàng nhanh, linh hoạt đơn vị tính và trừ kho thông minh.*

1.  **Lên đơn hàng (`Order`):**
    *   Tìm kiếm sản phẩm theo tên hoặc hoạt chất (ví dụ: Glyphosate, Abamectin).
    *   **Xử lý đơn vị:** Hệ thống quản lý đơn vị tính thông qua các `ProductVariant`. Mỗi sản phẩm có thể có nhiều quy cách (Chai 100ml, Chai 500ml, Thùng 20 chai) được định nghĩa là các Variant khác nhau. 
    *   **Nghiệp vụ quy đổi:** Khi cần bán lẻ từ đơn vị lớn (ví dụ bóc thùng bán chai), nhân viên thực hiện điều chỉnh kho (Inventory Transaction) để đảm bảo tính nhất quán về số lượng.
2.  **Cơ chế chọn Lô (Batch Selection):**
    *   **Tự động:** Hệ thống gợi ý lô có hạn sử dụng gần nhất (FEFO - First Expired, First Out).
    *   **Thủ công:** Cho phép chủ cửa hàng chọn lô cụ thể nếu khách hàng yêu cầu.
3.  **Thanh toán đa phương thức:**
    *   **Tiền mặt/Chuyển khoản:** Hoàn tất đơn hàng, ghi nhận doanh thu.
    *   **Ghi nợ (Mua thiếu):** Đây là nghiệp vụ phổ biến nhất. Khách hàng nhận hàng, ký vào phiếu giao hàng nhưng không trả tiền ngay.

## 3. QUY TRÌNH QUẢN LÝ CÔNG NỢ "GỐI ĐẦU" (CROP-BASED DEBT CYCLE)
*Mục tiêu: Quản lý dòng tiền nông nghiệp, chốt sổ theo mùa vụ.*

1.  **Giai đoạn Đầu vụ (Phát nợ):**
    *   Nông dân lấy thuốc về phun/bón. Mỗi lần lấy hàng, nợ tích lũy tăng dần.
    *   **Tính toán nợ:** Hệ thống truy vấn tổng dư nợ từ các giao dịch `DebtTransaction` liên quan đến khách hàng.
    *   Hạn mức nợ (Credit Limit) được kiểm tra để cảnh báo nếu khách hàng vượt ngưỡng cho phép.
2.  **Giai đoạn Giữa vụ (Trả một phần):**
    *   Khách có thể trả trước một ít tiền mặt. Tạo `DebtTransaction` loại "PAYMENT" để giảm trừ nợ gốc.
3.  **Giai đoạn Cuối vụ (Chốt sổ thu hoạch):**
    *   Sau khi bán lúa/trái cây, nông dân ra cửa hàng "Tính sổ".
    *   **Nghiệp vụ đối soát:** Hệ thống in "Bảng kê chi tiết nợ" liệt kê tất cả hóa đơn từ đầu vụ. 
    *   **Xử lý trả hàng:** Nông dân trả lại những chai thuốc chưa sử dụng hết. Hệ thống phải cho phép "Trả hàng - Hoàn nợ" (Sales Return), cộng lại số lượng vào đúng `Batch` đã xuất trước đó.

## 4. QUY TRÌNH KIỂM KÊ & XỬ LÝ HÀNG HẾT HẠN (AUDIT & EXPIRED GOODS)
*Mục tiêu: Giảm thiểu rủi ro tồn kho ảo và hàng kém chất lượng.*

1.  **Kiểm kê định kỳ:**
    *   So sánh số lượng trên phần mềm và thực tế kệ hàng. 
    *   Lệch kho thường do: Đổ vỡ, nhân viên quên bấm máy, hoặc thất thoát. Sử dụng `InventoryTransaction` để cân bằng.
2.  **Xử lý hàng cận date:**
    *   Hệ thống liệt kê danh sách `Batch` còn dưới 3 tháng hạn dùng.
    *   Chủ cửa hàng quyết định: Giảm giá xả kho hoặc trả lại Nhà cung cấp (Purchase Return).

## 5. HỆ THỐNG BÁO CÁO QUẢN TRỊ (MANAGEMENT REPORTING)
1.  **Báo cáo Lợi nhuận thực (Net Profit):** Phải trừ đi các chi phí hàng hỏng, hàng hết hạn và chiết khấu.
2.  **Báo cáo "Gương mặt nợ":** Danh sách khách hàng nợ nhiều nhất, nợ lâu nhất để có kế hoạch thu hồi vốn trước vụ mới.
3.  **Báo cáo Sản phẩm chủ lực:** Loại thuốc nào mang lại lợi nhuận cao nhất (thường là thuốc đặc trị) thay vì loại bán chạy nhất nhưng biên lợi nhuận thấp (như phân bón bao lớn).

---
*PM Note: Một phần mềm tốt cho cửa hàng thuốc bảo vệ thực vật không cần quá nhiều hiệu ứng, nhưng phải cực kỳ chính xác ở con số nợ và số lượng chai thuốc trong kho.*
