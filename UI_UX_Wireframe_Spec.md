# TÀI LIỆU THIẾT KẾ WIREFRAME & UI/UX SPECIFICATION

**Dự án:** Quản lý Cửa hàng Vật tư Nông nghiệp
**Phong cách thiết kế:** Hiện đại, Dashboard-centric, tối ưu cho WinForms (GunaUI2/Bunifu).
**Màu sắc chủ đạo:** Xanh lá (Nông nghiệp), Xanh dương (Tin cậy), Cam (Cảnh báo).

---

## 1. MÀN HÌNH ĐĂNG NHẬP (LOGIN SCREEN)

```text
__________________________________________________________
|                                                         |
|      [ LOGO CỬA HÀNG ]                                  |
|      QUẢN LÝ VẬT TƯ NÔNG NGHIỆP                         |
|                                                         |
|      --------------------------------------------       |
|      |  [icon] Tài khoản: [____________________] |      |
|      |                                          |      |
|      |  [icon] Mật khẩu:  [____________________] |      |
|      --------------------------------------------       |
|                                                         |
|      [ ] Ghi nhớ đăng nhập         [Quên mật khẩu?]     |
|                                                         |
|             [ BUTTON: ĐĂNG NHẬP ]                       |
|_________________________________________________________|
```

**Mô tả chi tiết:**
- **Control gợi ý:** Guna2GradientPanel cho nền, Guna2TextBox (có Icon Left), Guna2Button (bo góc).
- **Trải nghiệm người dùng:** Nhấn `Enter` để đăng nhập nhanh. Focus sẵn vào ô Tài khoản khi mở app.

---

## 2. BỐ CỤC CHÍNH (MAIN LAYOUT / DASHBOARD)

```text
__________________________________________________________
| SIDEBAR (Menu)  | HEADER: [ Tên Cửa Hàng ] [User] [Date] |
|-----------------|----------------------------------------|
| [ ] Tổng quan   |                                        |
| [ ] Bán hàng    |                                        |
| [ ] Nhập hàng   |          VÙNG NỘI DUNG CHÍNH           |
| [ ] Sản phẩm    |          (MAIN CONTENT AREA)           |
| [ ] Khách hàng  |                                        |
| [ ] Công nợ     |                                        |
| [ ] Báo cáo     |                                        |
| [ ] Cấu hình    |                                        |
|-----------------|________________________________________|
```

**Mô tả chi tiết:**
- **Sidebar:** Dùng Guna2Panel, các nút Menu dùng Guna2Button loại `CheckedState` để highlight menu đang chọn.
- **Header:** Hiển thị thời gian thực và tên nhân viên đang trực.

---

## 3. MÀN HÌNH BÁN HÀNG (POS - POINT OF SALE)
*Giao diện quan trọng nhất, cần thao tác cực nhanh.*

```text
__________________________________________________________________________
| [ Tìm sản phẩm... (F1) ] [ Quét mã vạch ] | [ Khách hàng: [________] +] |
|-------------------------------------------|-----------------------------|
| DANH SÁCH SẢN PHẨM CHỌN (Grid)            | THÔNG TIN ĐƠN HÀNG          |
| | STT | Tên | Lô | ĐVT | SL | Giá | T.Tiền | |---------------------------|
| |-----|-----|----|-----|----|-----|--------| | Tổng tiền:     1.500.000 |
| | 1   | Anvil|L01| Chai| 10 | 120k| 1.200k | | Chiết khấu:       50.000 |
| | 2   | Regnt|L02| Gói | 5  | 50k |  250k  | | PHẢI THANH TOÁN: 1.450.000 |
|                                           | |---------------------------|
|-------------------------------------------| | HÌNH THỨC:                |
| [F2: Lưu & In] [F3: Chỉ lưu] [F4: Hủy]    | | ( ) Tiền mặt  (*) Ghi nợ  |
|___________________________________________|_____________________________|
```

**Mô tả chi tiết:**
- **Grid:** Hiển thị rõ cột "Lô" (Batch). Khi chọn 1 sản phẩm, nếu có nhiều lô, phải hiện Popup chọn Lô (Ưu tiên lô gần hết hạn).
- **Phím tắt:** F1: Tìm kiếm, F2: Thanh toán, F10: Đổi đơn vị tính.
- **Xử lý Nợ:** Nếu chọn "Ghi nợ", hệ thống tự động cộng vào `TotalDebt` của Khách hàng sau khi bấm Lưu.

---

## 4. MÀN HÌNH NHẬP HÀNG (INVENTORY INBOUND)

```text
__________________________________________________________________________
| Nhà cung cấp: [___________________] [+] | Ngày nhập: [ 26/04/2026 ]     |
|-------------------------------------------------------------------------|
| [ Thêm dòng mới ]                                                       |
| | Sản phẩm | ĐVT | SL | Giá Nhập | NSX | HSD | Số Lô | Thành tiền |     |
| |----------|-----|----|----------|-----|-----|-------|------------|     |
| | [____▼]  | Chai| 100| 80.000   |...  |...  | AB123 | 8.000.000  |     |
|-------------------------------------------------------------------------|
|                                           Tổng tiền nhập: 8.000.000     |
| [ Nút: Hoàn tất nhập kho ]                Thanh toán:     [________]    |
|_________________________________________________________________________|
```

**Mô tả chi tiết:**
- **Nhập lô:** Đây là nơi tạo mới các `Batch`. Buộc phải nhập HSD và Số Lô.
- **Giá nhập:** Tự động gợi ý giá nhập lần gần nhất của nhà cung cấp đó.

---

## 5. MÀN HÌNH QUẢN LÝ CÔNG NỢ (DEBT MANAGEMENT)

```text
__________________________________________________________________________
| [ Tìm khách hàng... ] [ Trạng thái: ( ) Còn nợ  ( ) Hết nợ ] [ Xuất Excel]|
|--------------------------------------------------------------------------|
| DANH SÁCH KHÁCH HÀNG NỢ                                                  |
| | Tên Khách Hàng | Điện thoại | Nợ đầu kỳ | Phát sinh | Đã trả | Còn nợ | |
| |----------------|------------|-----------|-----------|--------|--------| |
| | Nguyễn Văn A   | 090xxx     | 5.000k    | 2.000k    | 1.000k | 6.000k | |
|--------------------------------------------------------------------------|
| [ Nút: Thu tiền nợ ] [ Nút: Xem lịch sử chi tiết ] [ Nút: In bảng kê ]   |
|__________________________________________________________________________|
```

**Mô tả chi tiết:**
- **Thu tiền nợ:** Mở một Dialog cho phép nhập số tiền khách trả, chọn phương thức (Tiền mặt/Chuyển khoản).
- **Xem chi tiết:** Hiển thị tất cả các `Order` mà khách chưa trả tiền và các `DebtTransaction` đã thực hiện.

---

## 6. MÀN HÌNH QUẢN LÝ LÔ HÀNG (BATCH TRACKING)
*Dành riêng cho việc theo dõi hạn sử dụng.*

```text
__________________________________________________________________________
| [ Bộ lọc: ( ) Sắp hết hạn  ( ) Còn hàng  ( ) Hết hàng ] [ Tìm sản phẩm ] |
|--------------------------------------------------------------------------|
| | Tên sản phẩm | Số Lô | Ngày nhập | HSD | Ngày còn lại | Tồn kho |      |
| |--------------|-------|-----------|-----|--------------|---------|      |
| | Anvil 5SC    | L001  | 01/01/26  |...  | 45 ngày [!]  | 15 chai |      |
| | Tung hieu    | L009  | 10/02/26  |...  | 300 ngày     | 100 chai|      |
|--------------------------------------------------------------------------|
| [ ! ] Màu đỏ: Cận date (< 60 ngày) | Màu cam: Cận date (< 180 ngày)      |
|__________________________________________________________________________|
```

---

## Ghi chú cho Developer:
1. **Validation:** Tất cả các ô số lượng, đơn giá phải chặn không cho nhập chữ.
2. **Responsive:** Các Grid phải co giãn theo kích thước màn hình (Anchor: Top, Bottom, Left, Right).
3. **Feedback:** Khi lưu thành công phải có Toast Notification (Bunifu Snackbar) để người dùng biết.
4. **Data Binding:** Sử dụng mô hình MVVM hoặc ít nhất là tách biệt logic xử lý ra khỏi Form code-behind.
