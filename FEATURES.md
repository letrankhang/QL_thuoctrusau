# DANH SÁCH TÍNH NĂNG HỆ THỐNG (FEATURE LIST)

**Dự án:** Quản lý Cửa hàng Vật tư Nông nghiệp
**Trạng thái:** Đặc tả tính năng chi tiết (Functional Requirements)

---

## 1. PHÂN HỆ QUẢN TRỊ HỆ THỐNG (SYSTEM ADMINISTRATION)
- **Đăng nhập/Đăng xuất:** Bảo mật tài khoản nhân viên.
- **Quản lý Tài khoản:** Thêm, sửa, xóa, khóa tài khoản người dùng.
- **Phân quyền (RBAC):** 
    - *Admin:* Toàn quyền hệ thống.
    - *Nhân viên:* Chỉ bán hàng, nhập hàng, không xem được báo cáo lợi nhuận.
- **Cấu hình cửa hàng:** Cài đặt thông tin in trên hóa đơn (Tên CH, SĐT, Địa chỉ).
- **Sao lưu & Phục hồi:** Đảm bảo an toàn dữ liệu định kỳ.

---

## 2. PHÂN HỆ QUẢN LÝ KHO & SẢN PHẨM (INVENTORY MANAGEMENT)
- **Quản lý Danh mục:** Phân loại sản phẩm (Thuốc trừ sâu, phân bón, hạt giống...).
- **Quản lý Sản phẩm:** 
    - Lưu trữ tên, hoạt chất, quy cách đóng gói.
    - Thiết lập đơn vị tính đa cấp (Ví dụ: Thùng -> Chai -> Gói).
- **Quản lý Lô hàng (Batch Tracking) - *Trọng tâm*:**
    - Ghi nhận Số lô, Ngày sản xuất, Hạn sử dụng cho từng đợt nhập.
    - Theo dõi tồn kho chi tiết theo từng lô cụ thể.
- **Cảnh báo hàng cận date:** Tự động liệt kê sản phẩm sắp hết hạn (dưới 2 tháng, 6 tháng).
- **Kiểm kê kho:** Đối soát số lượng thực tế và phần mềm, tạo phiếu điều chỉnh lệch kho.

---

## 3. PHÂN HỆ NHẬP HÀNG (PROCUREMENT)
- **Quản lý Nhà cung cấp:** Lưu thông tin đối tác cung ứng.
- **Phiếu nhập kho:** 
    - Nhập hàng theo đơn vị lớn (Thùng).
    - Tự động tính giá vốn trung bình hoặc giá vốn theo lô.
- **Quản lý nợ NCC:** Theo dõi số tiền còn nợ nhà cung cấp sau mỗi đợt nhập.

---

## 4. PHÂN HỆ BÁN HÀNG (POS - POINT OF SALE)
- **Màn hình bán hàng nhanh:** 
    - Tìm kiếm sản phẩm theo tên hoặc hoạt chất.
    - Hỗ trợ phím tắt (F1-F12) để thao tác không dùng chuột.
- **Cơ chế chọn Lô thông minh:** Tự động gợi ý xuất lô cũ trước (FEFO).
- **Xử lý đơn vị tính:** Tự động quy đổi giá khi khách mua lẻ (ví dụ mua lẻ 5 chai từ thùng 20 chai).
- **Thanh toán đa phương thức:** Tiền mặt, chuyển khoản hoặc ghi nợ.
- **In hóa đơn:** Mẫu hóa đơn chuyên nghiệp, hiển thị rõ số lô/HSD của từng món hàng.
- **Trả hàng (Sales Return):** Xử lý nhập lại kho khi nông dân trả lại hàng chưa sử dụng.

---

## 5. PHÂN HỆ QUẢN LÝ CÔNG NỢ "GỐI ĐẦU" (DEBT MANAGEMENT)
- **Hồ sơ Khách hàng:** Quản lý thông tin nông dân, hạn mức nợ (Credit Limit).
- **Quản lý nợ gối đầu:** 
    - Tích lũy nợ qua nhiều hóa đơn trong một mùa vụ.
    - Theo dõi chi tiết các lần trả bớt nợ của khách.
- **Đối soát cuối vụ:** Xuất bảng kê chi tiết tất cả hóa đơn nợ để tính sổ với khách.

---

## 6. HỆ THỐNG BÁO CÁO (REPORTING & ANALYTICS)
- **Báo cáo doanh thu:** Theo ngày, tháng, năm hoặc khoảng thời gian tùy chọn.
- **Báo cáo lợi nhuận thực tế:** Tính dựa trên giá vốn chính xác của từng lô hàng đã bán.
- **Báo cáo tồn kho:** 
    - Danh sách hàng sắp hết trong kho.
    - Giá trị vốn hóa của kho hàng hiện tại.
- **Báo cáo công nợ:** 
    - Top khách hàng nợ nhiều nhất.
    - Danh sách nợ quá hạn hoặc nợ lâu chưa thanh toán.
- **Báo cáo sản phẩm:** Thống kê sản phẩm bán chạy, sản phẩm mang lại lợi nhuận cao nhất.

---

## Ghi chú kỹ thuật:
- **Tốc độ:** Màn hình bán hàng phải phản hồi dưới 1 giây.
- **Chính xác:** Các phép tính tiền nợ và tồn kho lô phải tuyệt đối chính xác (Sử dụng kiểu `decimal`).
- **Offline:** Hệ thống phải hoạt động ổn định trong mạng nội bộ.
