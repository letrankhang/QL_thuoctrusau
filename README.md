# 🌾 HỆ THỐNG QUẢN LÝ CỬA HÀNG BÁN THUỐC TRỪ SÂU (QL_CuaHangBanThuocTruSau)

> **DỰ ÁN BÀI TẬP LỚN CUỐI KỲ - HỌC PHẦN LẬP TRÌNH C# / .NET**
---
## 📌 GIỚI THIỆU DỰ ÁN

**Hệ Thống Quản Lý Cửa Hàng Bán Thuốc Trừ Sâu** là ứng dụng desktop (Windows Forms Application) được xây dựng dựa trên ngôn ngữ **C#** và nền tảng **.NET Framework**. 

Dự án được thiết kế nhằm giúp các cửa hàng, đại lý kinh doanh vật tư nông nghiệp & thuốc bảo vệ thực vật tối ưu hóa quy trình quản lý bán hàng, nhập kho, quản lý lô hàng - hạn sử dụng, theo dõi công nợ khách hàng & nhà cung cấp, đồng thời cung cấp báo cáo thống kê trực quan cho chủ cửa hàng.

---

## 👥 THÀNH VIÊN THỰC HIỆN

| STT | Họ và Tên | Vai trò | Nhiệm vụ chính |
| :-: | :--- | :--- | :--- |
| 1 | **Lê Trần Khang** | **Nhóm trưởng** | Quản lý chung, thiết kế kiến trúc hệ thống, phát triển module quản lý tài khoản & Thống kê Dashboard |
| 2 | **Lê Hồng Gấm** | Thành viên | Phát triển module Bán hàng, Quản lý khách hàng |
| 3 | **Phan Tuấn Kha** | Thành viên | Phát triển module Quản lý Kho, Lô hàng & Nhập hàng từ Nhà cung cấp, công nợ |
| 4 | **Trần Thái Kiệt** | Thành viên | Phát triển module quản lý Sản phẩm, biến thể, điều chỉnh giao diện|

---

## ✨ CHỨC NĂNG CHÍNH

### 1. 🔑 Hệ Thống & Tài Khoản
* **Đăng nhập & Phân quyền**: Phân quyền truy cập cho Quản lý và Nhân viên bán hàng.
* **Bảo mật & Xác thực OTP**: Hỗ trợ khôi phục / quên mật khẩu qua mã xác thực tự động gửi đến Email người dùng.
* **Quản lý người dùng**: Thêm, sửa, khóa/mở khóa tài khoản nhân viên.

### 2. 📦 Quản Lý Sản Phẩm & Lô Hàng
* **Quản lý danh mục**: Phân loại các nhóm thuốc trừ sâu, phân bón, vật tư nông nghiệp.
* **Quản lý biến thể sản phẩm**: Quản lý quy cách đóng gói (chai, gói, xô, thùng...), đơn vị tính và giá bán tương ứng.
* **Quản lý Lô hàng (Batch Management)**: Theo dõi số lô, ngày sản xuất và hạn sử dụng của thuốc để cảnh báo thuốc sắp hết hạn.

### 3. 🛒 Quản Lý Bán Hàng (POS)
* Lập hóa đơn bán hàng nhanh chóng, hỗ trợ tìm kiếm sản phẩm thông minh.
* Tự động trừ tồn kho theo đúng lô hàng (FIFO - Lô hết hạn trước xuất trước).
* In hóa đơn bán hàng và lưu lịch sử giao dịch chi tiết.

### 4. 🚚 Quản Lý Nhập Hàng & Nhà Cung Cấp
* Quản lý thông tin nhà cung cấp (tên, số điện thoại, địa chỉ, công nợ).
* Lập phiếu nhập hàng, quản lý thông tin lô hàng nhập về kho.
* Theo dõi lịch sử nhập kho chi tiết.

### 5. 💳 Quản Lý Công Nợ
* **Công nợ Khách hàng**: Theo dõi khoản nợ, thanh toán và lịch sử giao dịch nợ của khách mua hàng.
* **Công nợ Nhà cung cấp**: Quản lý các khoản nợ cần trả cho nhà cung cấp.

### 6. 📊 Dashboard & Thống Kê
* Trực quan hóa doanh thu, lợi nhuận, số lượng đơn hàng theo ngày/tháng/năm.
* Cảnh báo sản phẩm sắp hết hàng trong kho hoặc lô thuốc sắp hết hạn sử dụng.

---

## 🛠️ CÔNG NGHỆ & KIẾN TRÚC SỬ DỤNG

* **Ngôn ngữ lập trình**: C# (.NET Framework)
* **Giao diện người dùng (GUI)**: Windows Forms (WinForms)
* **Quản trị CSDL**: Microsoft SQL Server
* **ORM & Data Access**: Entity Framework (Code First / DbContext)
* **Mô hình kiến trúc**: 3-Tier Architecture / Layered Pattern (Presentation - Business Logic (BUS) - Data Access (DAO/Context))
* **Gửi Email SMTP**: `System.Net.Mail` kết hợp Google SMTP Server (gửi OTP khôi phục mật khẩu).

---

## 📁 CẤU TRÚC THƯ MỤC DỰ ÁN

```text
QL_thuoctrusau/
├── BUS/                   # Business Logic Layer (Xử lý nghiệp vụ)
├── DAO/                   # Data Access Object (Truy xuất CSDL)
├── Context/               # DbContext & cấu hình Entity Framework
├── Models/                # Các Entity Class (Product, Order, Customer, Batch,...)
├── ViewModels/            # Các Model hỗ trợ hiển thị dữ liệu lên UI
├── Controllers/           # Điều khiển luồng xử lý giữa View và BUS
├── Views/                 # Giao diện màn hình Windows Forms (Form Đăng nhập, Bán hàng, Kho,...)
├── Utils/                 # Các tiện ích chung:
│   ├── EmailHelper.cs     # Helper xử lý gửi email OTP xác thực qua SMTP
│   ├── ExcelHelper.cs      # Xuất báo cáo dữ liệu ra file Excel
│   ├── InvoicePrinter.cs  # Hỗ trợ in hóa đơn bán hàng
│   ├── Logger.cs          # Ghi log hệ thống & bắt lỗi exception
│   └── ReportHelper.cs   # Hỗ trợ xuất báo cáo thống kê
├── Migrations/            # Quản lý phiên bản CSDL Entity Framework
├── ImagesProducts/        # Thư mục chứa hình ảnh sản phẩm
├── App.config             # Cấu hình chuỗi kết nối CSDL (ConnectionString)
├── Program.cs             # Entry point của ứng dụng
└── QL_CuaHangBanThuocTruSau.sln # File Solution của Visual Studio
```

---

## 🚀 HƯỚNG DẪN CÀI ĐẶT & CHẠY DỰ ÁN

### Yêu cầu hệ thống:
* **Visual Studio 2019 / 2022** (Đã cài đặt workload *.NET desktop development*).
* **Microsoft SQL Server** (phiên bản 2016 trở lên hoặc SQL Express) & **SSMS**.

### Các bước thực hiện:

1. **Clone / Tải dự án**:
   ```bash
   git clone <URL_REPOSITORY_CUA_NHOM>
   ```

2. **Mở dự án**:
   * Mở file `QL_CuaHangBanThuocTruSau.sln` bằng Visual Studio.

3. **Cấu hình CSDL (Database Connection)**:
   * Mở file `App.config`.
   * Cập nhật lại chuỗi `connectionString` phù hợp với SQL Server trên máy của bạn:
     ```xml
     <connectionStrings>
       <add name="QL_ThuocTruSauDbContext" 
            connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=QL_ThuocTruSauDB;Integrated Security=True;TrustServerCertificate=True" 
            providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```

4. **Cập nhật Database (Entity Framework Migration)**:
   * Mở cửa sổ **Package Manager Console** trong Visual Studio (`Tools -> NuGet Package Manager -> Package Manager Console`).
   * Chạy lệnh cập nhật database:
     ```powershell
     Update-Database
     ```

5. **Biên dịch & Khởi chạy**:
   * Nhấn `F5` hoặc nút `Start` trong Visual Studio để bắt đầu trải nghiệm ứng dụng.

---

## 📧 HƯỚNG DẪN CẤU HÌNH GỬI EMAIL XÁC THỰC (EMAILHELPER)

Để tính năng **Quên mật khẩu / Gửi mã xác thực OTP** qua Email hoạt động được, bạn cần cấu hình tài khoản Email gửi trong file `EmailHelper.cs`.

### 📂 Vị trí file:
[`QL_thuoctrusau/Utils/EmailHelper.cs`]

### ⚙️ Các bước thay đổi Email:

1. Mở file [`Utils/EmailHelper.cs`]
2. Thay đổi giá trị 2 hằng số `FromEmail` và `AppPassword`:

```csharp
namespace QL_CuaHangBanThuocTruSau.Utils 
{
    public static class EmailHelper 
    {
        private const string Host = "smtp.gmail.com";
        private const int Port = 587;

        // 🟢 Thay bằng Email Gmail gửi đi của bạn
        private const string FromEmail = "diachi-email-cua-ban@gmail.com"; 

        // 🟢 Thay bằng Mật khẩu ứng dụng (App Password) 16 ký tự tạo từ tài khoản Google
        private const string AppPassword = "xxxx xxxx xxxx xxxx"; 

        // ...
    }
}
```

### 🔑 Cách lấy Mật khẩu ứng dụng (App Password) từ Gmail:
1. Truy cập vào tài khoản Google của bạn tại [myaccount.google.com](https://myaccount.google.com/).
2. Chọn mục **Bảo mật (Security)** -> Đảm bảo bạn đã bật **Xác minh 2 bước (2-Step Verification)**.
3. Ở ô tìm kiếm phía trên, gõ **Mật khẩu ứng dụng (App Passwords)**.
4. Tạo một tên ứng dụng mới (Ví dụ: `QL_ThuocTruSau`).
5. Google sẽ tạo ra một mã mật khẩu gồm **16 ký tự**.
6. Sao chép 16 ký tự này và dán vào hằng số `AppPassword` trong `EmailHelper.cs`.

> ⚠️ **Lưu ý quan trọng**: Không sử dụng mật khẩu Gmail cá nhân thông thường. Phải sử dụng **App Password** của Google để đảm bảo tính năng gửi email không bị đòn chặn bởi cơ chế bảo mật của Gmail.

---

## 📝 GIẤY PHÉP & THÔNG TIN BỔ SUNG

Dự án này được thực hiện trong khuôn khổ **Bài tập lớn cuối kỳ Học phần Lập trình C# / .NET**. Mọi thông tin và mã nguồn đều phục vụ cho mục đích học tập và nghiên cứu.
