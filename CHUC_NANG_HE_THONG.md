# DANH SÁCH CHỨC NĂNG HỆ THỐNG QUẢN LÝ CỬA HÀNG BÁN THUỐC TRỪ SÂU

**Tên dự án:** QL_CuaHangBanThuocTruSau  
**Ngôn ngữ:** C# (WinForms)  
**Framework:** .NET Framework 4.8  
**Database:** Entity Framework (Code First)  
**Ngày cập nhật:** 05/06/2026

---

## 1. QUẢN LÝ XÁC THỰC VÀ PHÂN QUYỀN

### 1.1 Đăng nhập
- Đăng nhập bằng tên tài khoản và mật khẩu
- Ghi nhớ đăng nhập (Remember Me)
- Hiển thị/ẩn mật khẩu
- Phân quyền: Admin và User

### 1.2 Quên mật khẩu
- Nhập email hoặc username để khôi phục
- Gửi mã xác thực qua email
- Nhập mã OTP để xác thực
- Đặt lại mật khẩu mới

### 1.3 Quản lý phiên làm việc
- Lưu thông tin người dùng hiện tại (SessionManager)
- Đăng xuất an toàn
- Hiển thị thông tin người dùng trên giao diện chính

---

## 2. TỔNG QUAN (DASHBOARD) - Chỉ Admin

### 2.1 Thống kê tổng quan
- **Tổng doanh thu:** Hiển thị tổng doanh thu
- **Đơn hàng mới hôm nay:** Số lượng đơn hàng trong ngày
- **Công nợ khách hàng:** Tổng số tiền nợ của khách hàng
- **Giá trị tồn kho:** Tổng giá trị hàng tồn kho

### 2.2 Biểu đồ xu hướng kinh doanh
- Biểu đồ cột: Số lượng sản phẩm bán ra theo ngày (7 ngày gần nhất)
- Biểu đồ đường: Doanh thu theo ngày (7 ngày gần nhất)
- Hiển thị dữ liệu trên cùng một biểu đồ

### 2.3 Cảnh báo sản phẩm
- Danh sách sản phẩm sắp hết hạn
- Danh sách sản phẩm đã hết hạn
- Hiển thị chi tiết: tên sản phẩm, ngày hết hạn, số lượng tồn

---

## 3. QUẢN LÝ SẢN PHẨM

### 3.1 Danh sách sản phẩm
- Hiển thị danh sách tất cả sản phẩm
- Thông tin: Mã SP, Tên SP, Loại, Đơn vị, Hình ảnh
- Đếm tổng số sản phẩm

### 3.2 Thêm sản phẩm mới
- Nhập thông tin: Tên, Mô tả, Loại, Đơn vị
- Upload hình ảnh sản phẩm
- Xóa hình ảnh đã chọn

### 3.3 Sửa thông tin sản phẩm
- Cập nhật thông tin sản phẩm
- Thay đổi hình ảnh
- Cập nhật loại sản phẩm

### 3.4 Xóa sản phẩm
- Xóa sản phẩm (kiểm tra ràng buộc dữ liệu)
- Xác nhận trước khi xóa

### 3.5 Tìm kiếm và lọc
- Tìm kiếm theo tên sản phẩm
- Lọc theo loại sản phẩm
- Sắp xếp A-Z, Z-A

### 3.6 Quản lý loại sản phẩm
- Thêm loại sản phẩm mới
- Hiển thị danh sách loại

### 3.7 Quản lý biến thể sản phẩm
- Xem chi tiết biến thể của sản phẩm
- Thêm biến thể mới (hàm lượng, giá bán)
- Sửa thông tin biến thể
- Xóa biến thể

---

## 4. BÁN HÀNG

### 4.1 Tạo đơn hàng
- Chọn khách hàng từ danh sách
- Tìm kiếm sản phẩm theo tên
- Lọc sản phẩm theo loại
- Lọc sản phẩm theo giá (dưới 50k, 50-100k, 100-200k, 200-500k, trên 500k)
- Hiển thị danh sách sản phẩm có sẵn (còn hàng)
- Thêm sản phẩm vào giỏ hàng
- Nhập số lượng
- Hiển thị thông tin lô hàng (expiry date)

### 4.2 Giỏ hàng
- Hiển thị danh sách sản phẩm trong giỏ
- Tính tổng tiền tự động
- Xóa sản phẩm khỏi giỏ
- Xóa toàn bộ giỏ hàng

### 4.3 Thanh toán
- **Thanh toán:** Khách trả một phần hoặc toàn bộ
- **Ghi nợ 100%:** Không thanh toán, ghi toàn bộ vào công nợ
- Nhập số tiền khách đưa
- Tính tiền thừa
- In hóa đơn sau khi thanh toán

### 4.4 Lịch sử đơn hàng
- Xem danh sách đơn hàng cũ
- Lọc theo ngày tháng
- Xuất báo cáo Excel
- In lại hóa đơn

### 4.5 Phím tắt
- F1: Thanh toán
- F2: Ghi nợ
- F3: Hủy đơn
- F4: Xem lịch sử
- F5: Làm mới

---

## 5. NHẬP HÀNG

### 5.1 Tạo đơn nhập hàng
- Chọn nhà cung cấp
- Chọn sản phẩm và biến thể
- Nhập thông tin lô hàng:
  - Số lô (Batch Number)
  - Ngày sản xuất
  - Ngày hết hạn
  - Số lượng
  - Giá nhập
- Thêm nhiều sản phẩm vào đơn nhập
- Tính tổng tiền tự động

### 5.2 Thanh toán đơn nhập
- Thanh toán ngay (PAID)
- Chưa thanh toán (UNPAID) - ghi nợ nhà cung cấp
- Lưu đơn nhập hàng

### 5.3 Lịch sử nhập hàng
- Hiển thị danh sách đơn nhập hàng
- Thông tin: Mã đơn, NCC, Tổng tiền, Trạng thái thanh toán, Ngày nhập
- Xem chi tiết đơn nhập
- Lọc theo trạng thái thanh toán
- Tìm kiếm đơn nhập
- Xuất báo cáo Excel

### 5.4 Quản lý trạng thái
- Hoàn thành (COMPLETED)
- Chờ xử lý (PENDING)
- Đã hủy (CANCELLED)
- Đã thanh toán (PAID)
- Chưa thanh toán (UNPAID)

---

## 6. QUẢN LÝ LÔ HÀNG

### 6.1 Danh sách lô hàng
- Hiển thị tất cả lô hàng
- Thông tin: Mã lô, Sản phẩm, Biến thể, Số lượng, Giá nhập, NSX, HSD, NCC
- Đếm tổng số lô hàng

### 6.2 Lọc lô hàng theo trạng thái
- **Tất cả:** Hiển thị tất cả lô hàng
- **Còn hạn:** Lô hàng còn hạn sử dụng
- **Gần hết hạn:** Sắp hết hạn (dưới 30 ngày)
- **Hết hạn:** Đã quá hạn sử dụng

### 6.3 Lọc và tìm kiếm
- Lọc theo sản phẩm
- Lọc theo nhà cung cấp
- Tìm kiếm theo mã lô

### 6.4 Xuất báo cáo
- Xuất danh sách lô hàng ra Excel
- Định dạng báo cáo chuyên nghiệp
- Hiển thị màu sắc theo trạng thái

### 6.5 Hiển thị trực quan
- Mã màu theo trạng thái:
  - Xanh: Còn hạn
  - Vàng: Gần hết hạn
  - Đỏ: Hết hạn
- Tính ngày còn lại tự động

---

## 7. QUẢN LÝ KHÁCH HÀNG

### 7.1 Danh sách khách hàng
- Hiển thị thông tin: Mã KH, Tên, SĐT, Địa chỉ, Ngày tạo
- Đếm tổng số khách hàng

### 7.2 Thêm khách hàng mới
- Nhập thông tin: Tên, SĐT, Địa chỉ
- Validate số điện thoại (10 số, bắt đầu bằng 0)
- Kiểm tra trùng lặp

### 7.3 Sửa thông tin khách hàng
- Cập nhật thông tin khách hàng
- Validate dữ liệu

### 7.4 Xóa khách hàng
- Xóa khách hàng (kiểm tra ràng buộc)
- Xác nhận trước khi xóa

### 7.5 Tìm kiếm và lọc
- Tìm kiếm theo tên hoặc SĐT
- Lọc theo ngày tạo:
  - Tất cả các ngày
  - Hôm nay
  - Tuần này
  - Tháng này

---

## 8. QUẢN LÝ NHÀ CUNG CẤP

### 8.1 Danh sách nhà cung cấp
- Hiển thị thông tin: Mã NCC, Tên, SĐT, Địa chỉ
- Đếm tổng số NCC

### 8.2 Thêm nhà cung cấp
- Nhập thông tin: Tên, SĐT, Địa chỉ
- Validate dữ liệu

### 8.3 Sửa thông tin NCC
- Cập nhật thông tin
- Kiểm tra dữ liệu hợp lệ

### 8.4 Xóa nhà cung cấp
- Xóa NCC (kiểm tra ràng buộc)
- Xác nhận trước khi xóa

### 8.5 Tìm kiếm
- Tìm kiếm NCC theo tên

---

## 9. QUẢN LÝ CÔNG NỢ

### 9.1 Danh sách công nợ
- Hiển thị công nợ khách hàng và nhà cung cấp
- Thông tin: Mã đơn, Tên đối tác, Loại nợ, Tổng tiền, Đã thanh toán, Còn nợ
- Phân trang dữ liệu

### 9.2 Phân loại công nợ
- **Nợ phải thu:** Công nợ từ khách hàng
- **Nợ phải trả:** Công nợ với nhà cung cấp

### 9.3 Thanh toán công nợ
- Chọn đơn hàng cần thanh toán
- Nhập số tiền thanh toán
- Cập nhật trạng thái công nợ
- Lưu lịch sử giao dịch

### 9.4 Lọc và tìm kiếm
- Lọc theo loại nợ (Phải thu / Phải trả)
- Tìm kiếm theo tên đối tác
- Lọc theo ngày tạo

### 9.5 Xuất báo cáo
- Xuất danh sách công nợ ra Excel
- Báo cáo chi tiết công nợ

---

## 10. QUẢN LÝ TÀI KHOẢN - Chỉ Admin

### 10.1 Danh sách tài khoản
- Hiển thị thông tin: Username, Họ tên, Email, Chức vụ, Trạng thái, Ngày tạo
- Phân biệt Admin và User
- Hiển thị avatar

### 10.2 Thêm tài khoản mới
- Nhập thông tin: Username, Password, Họ tên, Email, Chức vụ
- Validate email
- Kiểm tra trùng username
- Mã hóa mật khẩu

### 10.3 Sửa thông tin tài khoản
- Cập nhật thông tin cá nhân
- Đổi mật khẩu
- Thay đổi chức vụ

### 10.4 Vô hiệu hóa tài khoản
- Xóa mềm (Soft delete)
- Không thể xóa tài khoản của chính mình
- Xác nhận trước khi vô hiệu hóa

### 10.5 Lọc và tìm kiếm
- Tìm kiếm theo username hoặc tên
- Lọc theo chức vụ (Admin/User)
- Lọc theo trạng thái (Active/Inactive)
- Lọc theo ngày tạo

---

## 11. LỊCH SỬ KHO

### 11.1 Danh sách giao dịch
- Hiển thị lịch sử nhập/xuất kho
- Thông tin: Mã GD, Sản phẩm, Mã lô, Số lượng, Loại GD, Thời gian, Mã tham chiếu

### 11.2 Phân loại giao dịch
- **Nhập hàng (IMPORT):** Nhập từ NCC
- **Bán hàng (SALE/SELL):** Xuất khi bán
- **Khách trả hàng (RETURN):** Nhập lại từ khách
- **Điều chỉnh (ADJUST):** Điều chỉnh tồn kho

### 11.3 Lọc theo thời gian
- Chọn từ ngày - đến ngày
- Lọc dữ liệu theo khoảng thời gian

### 11.4 Xuất báo cáo
- Xuất lịch sử kho ra Excel

---

## 12. LỊCH SỬ ĐỢN HÀNG

### 12.1 Danh sách đơn hàng
- Hiển thị tất cả đơn hàng
- Thông tin: Mã đơn, Khách hàng, Nhân viên, Ngày lập, Tổng tiền, Trạng thái

### 12.2 Lọc theo thời gian
- Chọn từ ngày - đến ngày
- Lọc đơn hàng theo khoảng thời gian

### 12.3 Xem chi tiết đơn hàng
- Xem thông tin chi tiết đơn hàng
- Danh sách sản phẩm trong đơn

### 12.4 Xuất báo cáo
- Xuất danh sách đơn hàng ra Excel

---

## 13. IN ẤN VÀ BÁO CÁO

### 13.1 In hóa đơn bán hàng
- In hóa đơn sau khi thanh toán
- Format: PDF
- Thông tin: Tên cửa hàng, địa chỉ, SĐT, logo
- Chi tiết: Sản phẩm, số lượng, đơn giá, thành tiền
- Tổng tiền, tiền khách đưa, tiền thừa

### 13.2 Xuất báo cáo Excel
- Xuất danh sách sản phẩm
- Xuất danh sách lô hàng
- Xuất lịch sử đơn hàng
- Xuất lịch sử kho
- Xuất công nợ
- Định dạng chuyên nghiệp với màu sắc

### 13.3 Xuất báo cáo PDF
- Báo cáo lô hàng
- Báo cáo công nợ
- Sử dụng font Unicode (Arial) cho tiếng Việt

---

## 14. TIỆN ÍCH

### 14.1 Gửi email
- Gửi mã OTP khi quên mật khẩu
- Hỗ trợ Gmail SMTP

### 14.2 Logger
- Ghi log lỗi vào file
- Ghi thông tin debug

### 14.3 SessionManager
- Quản lý phiên đăng nhập
- Lưu thông tin người dùng hiện tại
- Kiểm tra quyền Admin

### 14.4 OperationResult
- Trả về kết quả thao tác
- Thông báo lỗi chi tiết

---

## 15. GIAO DIỆN

### 15.1 Giao diện chính
- Menu điều hướng bên trái
- Hiển thị thông tin người dùng
- Đồng hồ thời gian thực
- Chào người dùng theo giờ

### 15.2 Thiết kế
- Sử dụng Guna2 UI Framework
- Giao diện hiện đại, thân thiện
- Màu sắc nhất quán
- Icon trực quan

### 15.3 Responsive
- Tự động điều chỉnh kích thước
- Hỗ trợ nhiều độ phân giải màn hình

---

## 16. BẢO MẬT

### 16.1 Mã hóa mật khẩu
- Sử dụng BCrypt để hash password
- Không lưu mật khẩu dạng plain text

### 16.2 Phân quyền
- Phân biệt Admin và User
- Ẩn các chức năng theo quyền
- Kiểm tra quyền trước khi thực hiện thao tác

### 16.3 Validate dữ liệu
- Kiểm tra dữ liệu đầu vào
- Ngăn chặn SQL Injection
- Validate email, số điện thoại

---

## 17. CƠ SỞ DỮ LIỆU

### 17.1 Các bảng chính
- Users: Tài khoản người dùng
- Products: Sản phẩm
- ProductVariants: Biến thể sản phẩm
- Categories: Loại sản phẩm
- Customers: Khách hàng
- Suppliers: Nhà cung cấp
- Batches: Lô hàng
- Orders: Đơn hàng
- OrderDetails: Chi tiết đơn hàng
- OrderDetailBatch: Lô hàng trong đơn hàng
- Imports: Đơn nhập hàng
- InventoryTransactions: Lịch sử kho
- DebtTransactions: Giao dịch công nợ

### 17.2 Quan hệ
- One-to-Many: Product → ProductVariants
- One-to-Many: Category → Products
- One-to-Many: Customer → Orders
- One-to-Many: Supplier → Imports
- Many-to-Many: Orders ↔ Batches (qua OrderDetailBatch)

---

## 18. KỸ THUẬT SỬ DỤNG

### 18.1 Architecture
- 3-Layer Architecture:
  - Views (Presentation Layer)
  - Controllers (Business Logic Controller)
  - BUS (Business Logic Layer)
  - DAO (Data Access Layer)
  - Models (Entity Models)
  - Utils (Utilities)

### 18.2 Design Pattern
- MVC Pattern
- Repository Pattern
- Singleton Pattern (SessionManager)

### 18.3 Thư viện
- Guna.UI2.WinForms: Giao diện
- Entity Framework: ORM
- ClosedXML: Xuất Excel
- iTextSharp: Tạo PDF
- BCrypt.Net: Mã hóa mật khẩu
- System.Net.Mail: Gửi email

---

## TỔNG KẾT

Hệ thống quản lý cửa hàng bán thuốc trừ sâu bao gồm **18 module chức năng chính** với các tính năng:

- ✅ Quản lý bán hàng hoàn chỉnh
- ✅ Quản lý nhập hàng và lô hàng
- ✅ Quản lý công nợ phải thu/phải trả
- ✅ Quản lý kho và lịch sử xuất nhập
- ✅ Thống kê dashboard trực quan
- ✅ Phân quyền Admin/User
- ✅ In hóa đơn và xuất báo cáo
- ✅ Cảnh báo hàng hết hạn
- ✅ Giao diện hiện đại, dễ sử dụng

**Phù hợp cho:** Cửa hàng kinh doanh thuốc trừ sâu, phân bón, vật tư nông nghiệp.
