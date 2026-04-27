# KẾ HOẠCH PHÂN CHIA CÔNG VIỆC - DỰ ÁN QL_CUAHANGBANTHUOCTRUSAU

**Dự án:** Quản lý Cửa hàng Vật tư Nông nghiệp
**Tổng số thành viên:** 4
**Công nghệ:** C# WinForms, EF Core, GunaUI2/Bunifu, SQL Server.

---

## 1. Người thứ nhất (Bạn - Team Lead / System Architect)
*Trọng tâm: Hệ thống lõi, Xác thực, Tổng quan và Tiêu chuẩn hóa.*

### ✅ Công việc đã hoàn thành:
- Khởi tạo cấu trúc dự án (Models, BUS, DAO, Controllers, Context).
- Thiết lập Database Context & Migrations ban đầu.
- Xây dựng cơ chế Đăng nhập/Đăng xuất (Auth).
- Quản lý người dùng (CRUD Users).
- Thiết kế Layout chính (Frm_TRANGCHU) và cơ chế Session.

### 🛠️ Công việc tiếp theo:
- **Dashboard (Trang chủ):** Hiển thị các Widget thống kê nhanh (Tổng doanh thu ngày, Số đơn hàng, Cảnh báo hàng cận date).
- **Phân quyền (RBAC):** Cài đặt middleware hoặc logic tại Controller để chặn quyền truy cập giữa Admin và Nhân viên.
- **Base Components:** Xây dựng các Class/UserControl dùng chung (như Toast Notification, Custom Dialog, Logger).
- **Cấu hình hệ thống:** Quản lý thông tin cửa hàng (Tên, địa chỉ, logo, số điện thoại in trên hóa đơn).

---

## 2. Người thứ hai (Developer - Inventory Expert)
*Trọng tâm: Quản lý hàng hóa, Lô hàng và Kho bãi.*

### 🛠️ Nhiệm vụ chi tiết:
- **Danh mục & Sản phẩm:** Xây dựng CRUD Sản phẩm, Loại hàng (Category).
- **Quy đổi Đơn vị tính:** Xử lý logic quy đổi Thùng -> Chai/Gói (ProductVariant).
- **Quản lý Lô hàng (Batch):** 
    - Theo dõi Ngày sản xuất, Hạn sử dụng (HSD).
    - Viết logic cảnh báo hàng cận date (Màu đỏ: < 60 ngày, Cam: < 180 ngày).
- **Quản lý Nhà cung cấp (Supplier):** CRUD thông tin đối tác cung ứng.
- **Kiểm kê & Điều chỉnh:** Chức năng cân bằng kho (InventoryTransaction - Adjust loss/gain).

---

## 3. Người thứ ba (Developer - Sales & UI Specialist)
*Trọng tâm: Quy trình bán hàng (POS) và Trải nghiệm khách hàng.*

### 🛠️ Nhiệm vụ chi tiết:
- **Màn hình Bán hàng (POS):** 
    - Giao diện bán hàng nhanh bằng phím tắt (F1, F2...).
    - Logic chọn Lô hàng tự động theo FEFO (Hết hạn trước - Xuất trước).
    - Tính toán chiết khấu, thuế và in hóa đơn (ReportViewer hoặc thư viện PDF).
- **Quản lý Khách hàng:** CRUD thông tin nông dân, phân loại khách hàng.
- **Xử lý Trả hàng (Sales Return):** Nông dân trả lại thuốc chưa dùng, hoàn trả tồn kho vào đúng lô cũ.
- **Hạn mức tín dụng:** Logic chặn không cho bán nợ nếu vượt quá `CreditLimit`.

---

## 4. Người thứ tư (Developer - Finance & Accountant)
*Trọng tâm: Nhập hàng, Công nợ và Báo cáo tài chính.*

### 🛠️ Nhiệm vụ chi tiết:
- **Nhập kho (Import):** 
    - Lập phiếu nhập hàng từ Nhà cung cấp.
    - Tự động tạo mới các `Batch` (Lô) khi hàng vào kho.
- **Quản lý Công nợ (Debt Management):** 
    - Xây dựng quy trình "Nợ gối đầu": Thu nợ theo đợt, xem lịch sử giao dịch nợ (DebtTransaction).
    - Chức năng in "Bảng kê chi tiết nợ" để đối soát cuối vụ với nông dân.
- **Hệ thống Báo cáo:** 
    - Báo cáo doanh thu/lợi nhuận thực tế (đã trừ giá vốn theo lô).
    - Báo cáo công nợ phải thu (Khách hàng) và phải trả (Nhà cung cấp).
    - Báo cáo tồn kho giá trị (Tổng tiền hàng đang nằm trong kho).

---

## 📅 LƯU Ý PHỐI HỢP (GIT FLOW)
1. **Branching:** Mỗi người làm việc trên branch riêng (`feature/user-management`, `feature/inventory`, ...).
2. **Commit:** Nhắn tin rõ ràng (Ví dụ: `feat: add batch tracking logic`).
3. **Database:** Khi thay đổi Model, phải báo cho Team Lead (Người 1) để thực hiện Migration tập trung, tránh xung đột file `.resx` của Migration.
4. **UI:** Sử dụng thống nhất bộ thư viện GunaUI2 để đảm bảo giao diện đồng bộ.
