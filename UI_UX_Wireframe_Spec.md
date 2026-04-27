# TÀI LIỆU THIẾT KẾ GIAO DIỆN CHI TIẾT (FULL UI/UX WIREFRAME)

**Dự án:** Quản lý Cửa hàng Vật tư Nông nghiệp
**Phong cách:** Modern Dashboard, GunaUI2/Bunifu.
**Chủ đề:** 🌿 Nông nghiệp Xanh.

---

## 1. BỐ CỤC TỔNG THỂ (GLOBAL LAYOUT)

```text
__________________________________________________________________________
| [=] LOGO APP     | [ Breadcrumb: Trang chủ > Bán hàng ]   [🔔] [👤 Admin] |
|------------------|------------------------------------------------------|
| ( ) Tổng quan    |                                                      |
| ( ) Bán hàng     |                                                      |
| ( ) Nhập hàng    |                                                      |
| ( ) Sản phẩm     |               VÙNG NỘI DUNG CHÍNH                    |
| ( ) Lô hàng      |             (HIỂN THỊ CÁC USERCONTROL)               |
| ( ) Khách hàng   |                                                      |
| ( ) Công nợ      |                                                      |
| ( ) Báo cáo      |                                                      |
| ( ) Cài đặt      |                                                      |
|------------------|                                                      |
| [v] Thu gọn      | [ Thời gian: 27/04/2026 14:30 ] [ Version 1.0 ]      |
|__________________|______________________________________________________|
```

**Mô tả:**
- **Sidebar:** Guna2Panel bên trái, chứa các Guna2Button chuyển đổi màn hình.
- **Header:** Guna2GradientPanel trên cùng, chứa tên màn hình hiện tại và nút thông báo hàng cận date.
- **Footer:** StatusStrip hiển thị thời gian hệ thống và phiên bản.

---

## 2. MÀN HÌNH ĐĂNG NHẬP (LOGIN)

```text
__________________________________________________________
|                                                         |
|      [      HÌNH ẢNH MINH HỌA NÔNG NGHIỆP      ]        |
|      [           (Banner bên trái)             ]        |
|                                                         |
|      --------------------------------------------       |
|      |  [icon] Tài khoản: [____________________] |      |
|      |                                          |      |
|      |  [icon] Mật khẩu:  [____________________] |      |
|      --------------------------------------------       |
|                                                         |
|      [x] Ghi nhớ đăng nhập         [Quên mật khẩu?]     |
|                                                         |
|             [ BUTTON: ĐĂNG NHẬP ]                       |
|_________________________________________________________|
```

**Mô tả:** 
- Guna2ShadowForm để tạo bóng đổ cho cửa sổ.
- Guna2TextBox có thuộc tính `IconLeft` và `PlaceholderText`.
- Guna2Button với hiệu ứng `HoverState` đổi màu.

---

## 3. DASHBOARD (TỔNG QUAN)

```text
__________________________________________________________________________
|  [ TỔNG DOANH THU ]  [ ĐƠN HÀNG MỚI ]  [ KHÁCH CÒN NỢ ]  [ GIÁ TRỊ KHO ] |
|  [    15.000.000   ]  [      24      ]  [  120.000.000 ]  [ 850.000.000 ] |
|-------------------------------------------------------------------------|
|                                     |                                   |
|       BIỂU ĐỒ DOANH THU 7 NGÀY      |      CẢNH BÁO HÀNG CẬN DATE       |
|             (Line Chart)            |   | SP       | Lô  | HSD    | SL | |
|                                     |   |----------|-----|--------|----| |
|                                     |   | Anvil    | L01 | 05/26  | 10 | |
|                                     |   | Regent   | L09 | 06/26  | 45 | |
|_____________________________________|___________________________________|
```

**Mô tả:**
- **Top Cards:** Guna2Panel bo góc, đổ bóng.
- **Chart:** Sử dụng Guna.Charts hoặc LiveCharts.
- **Alert Table:** Guna2DataGridView loại nhỏ, highlight màu đỏ cho các dòng cận date.

---

## 4. QUẢN LÝ SẢN PHẨM & ĐƠN VỊ TÍNH

```text
__________________________________________________________________________
| [ Tìm sản phẩm... ] [ + Thêm mới ] [ Xuất Excel ] [ Bộ lọc Danh mục ▼ ] |
|-------------------------------------------------------------------------|
| | ID | Hình | Tên Sản Phẩm | Hoạt Chất | Quy Cách | ĐVT Chính | Giá Bán | |
| |----|------|--------------|-----------|----------|-----------|---------| |
| | 01 | [im] | Anvil 5SC    | Hexacon...| 100ml    | Chai      | 85.000  | |
| | 02 | [im] | Kali Miền Nam| Kali...   | 50kg     | Bao       | 650.000 | |
|-------------------------------------------------------------------------|
| [ Popup Thêm Mới:                                                       |
|   - Tên: [____________]  Danh mục: [____▼]                              |
|   - Đơn vị quy đổi: [1 Thùng] = [20 Chai] = [200 Gói]                   |
| ]                                                                       |
|_________________________________________________________________________|
```

**Mô tả:**
- Quản lý quy đổi đơn vị tính (Unit Conversion) đa cấp.
- Guna2DataGridView hỗ trợ Image Column để hiện ảnh sản phẩm nhỏ.

---

## 5. MÀN HÌNH BÁN HÀNG (POS)

```text
__________________________________________________________________________
| [ F1: Tìm SP/Quét mã... ]          | Khách hàng: [ Nguyễn Văn A  ] [+]  |
|------------------------------------|------------------------------------|
| DANH SÁCH MUA HÀNG                 | CHI TIẾT THANH TOÁN                |
| | Tên SP | Lô | ĐVT | SL | Giá | TT| |----------------------------------|
| |--------|----|-----|----|-----|---| | Tổng tiền hàng:      1.500.000 |
| | Anvil  |L01| Chai| 10 | 85k |850| | Giảm giá:               50.000 |
| |        |    |     |    |     |   | |----------------------------------|
| |        |    |     |    |     |   | | KHÁCH PHẢI TRẢ:      1.450.000 |
| |        |    |     |    |     |   | |----------------------------------|
| |        |    |     |    |     |   | | HÌNH THỨC:                       |
| |        |    |     |    |     |   | | ( ) Tiền mặt ( ) CK  (*) Ghi nợ |
|------------------------------------| [ BUTTON: F2 - LƯU & IN HÓA ĐƠN ]  |
| [F3: Hủy đơn] [F4: Xem đơn cũ]     | [ BUTTON: F5 - CHỈ LƯU ĐƠN      ]  |
|____________________________________|____________________________________|
```

**Mô tả:**
- **Popup chọn Lô:** Khi chọn sản phẩm, hiện bảng chọn Lô còn tồn (Ưu tiên FEFO).
- **Phím tắt:** Bắt sự kiện KeyDown toàn Form (F1, F2, F5...).

---

## 6. QUẢN LÝ LÔ HÀNG & HSD (BATCH)

```text
__________________________________________________________________________
| [ Lọc: ( ) Tất cả  (*) Sắp hết hạn  ( ) Hết hàng ] [ Tìm theo Lô... ]   |
|--------------------------------------------------------------------------|
| | Sản phẩm | Số Lô | Ngày Nhập | Ngày SX | Hạn Dùng | Tồn Kho | Trạng Thái|
| |----------|-------|-----------|---------|----------|---------|-----------|
| | Regent   | L123  | 01/01/26  | 10/25   | 10/26    | 150 Gói | Bình thường|
| | Anvil    | L002  | 15/02/26  | 05/24   | 05/26    | 12 Chai | Cận Date !!|
|--------------------------------------------------------------------------|
| [ Nút: Xuất báo cáo tồn kho theo lô ] [ Nút: Tiêu hủy/Trả hàng NCC ]     |
|__________________________________________________________________________|
```

**Mô tả:**
- Hiển thị trạng thái bằng Guna2Chip (Đỏ: Hết hạn, Cam: Cận date, Xanh: An toàn).

---

## 7. QUẢN LÝ CÔNG NỢ (DEBT MANAGEMENT)

```text
__________________________________________________________________________
| [ Tab: Nợ Khách Hàng ] [ Tab: Nợ Nhà Cung Cấp ] [ Lịch sử trả nợ ]      |
|-------------------------------------------------------------------------|
| [ Tìm khách hàng... ] [ Tổng nợ: 1.250.000.000đ ] [ Xuất file đối soát ]|
|-------------------------------------------------------------------------|
| | Tên Khách Hàng | Địa chỉ | Số ĐT | Nợ Cũ | Phát Sinh | Đã Trả | Còn Nợ | |
| |----------------|---------|-------|-------|-----------|--------|--------| |
| | Trần Văn B     | Ấp 1... | 091...| 10tr  | 5tr       | 2tr    | 13tr   | |
|-------------------------------------------------------------------------|
| [ Nút: THU TIỀN NỢ (Popup) ] [ Nút: Xem chi tiết hóa đơn nợ ]           |
|_________________________________________________________________________|
```

**Mô tả:**
- Chức năng "Thu tiền nợ" cho phép trả một phần hoặc toàn bộ.
- "Chi tiết hóa đơn nợ" liệt kê tất cả các phiếu bán hàng chưa thanh toán của khách đó.

---

## 8. NHẬP KHO (IMPORT)

```text
__________________________________________________________________________
| Nhà cung cấp: [ Đông Nam A ▼ ] [+] | Ngày nhập: [ 27/04/2026 ]         |
|-------------------------------------------------------------------------|
| [ + Thêm dòng sản phẩm ]                                                |
| | SP | ĐVT | SL | Giá Nhập | Số Lô | Ngày SX | Hạn Dùng | Thành Tiền |  |
| |----|-----|----|----------|-------|---------|----------|------------|  |
| |[v] | Chai| 100| 75.000   | AB45  | 01/26   | 01/28    | 7.500.000  |  |
|-------------------------------------------------------------------------|
|                                         Tổng tiền nhập: 7.500.000       |
| [ Nút: HOÀN TẤT NHẬP KHO ]              Thanh toán:     [________]      |
|_________________________________________________________________________|
```

**Mô tả:**
- Ép buộc nhập Số Lô và HSD khi nhập hàng mới.
- Tự động cộng tồn kho vào bảng `Batch`.

---

## Ghi chú cho nhóm Code:
1. **Guna2Elipse:** Dùng để bo góc tất cả các Form và Panel.
2. **Guna2DragControl:** Cho phép nắm kéo Header để di chuyển cửa sổ.
3. **DataBinding:** Tất cả các bảng (Grid) phải dùng `BindingSource` để lọc dữ liệu nhanh.
4. **Validation:** Kiểm tra HSD không được nhỏ hơn ngày hiện tại khi nhập hàng.
