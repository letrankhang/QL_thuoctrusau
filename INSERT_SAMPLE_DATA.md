# SQL Server Sample Data Insert Script

Tài liệu này chứa các câu lệnh SQL để chèn dữ liệu mẫu vào cơ sở dữ liệu dựa trên các Models trong dự án. Thứ tự chèn được sắp xếp để đảm bảo tính toàn vẹn của khóa ngoại (Foreign Key).

## 1. Bảng Danh mục (Categories)
```sql
INSERT INTO Categories (Name, Description) VALUES 
(N'Thuốc trừ sâu', N'Các loại thuốc tiêu diệt sâu hại cây trồng'),
(N'Thuốc diệt cỏ', N'Các loại thuốc tiêu diệt cỏ dại'),
(N'Phân bón', N'Các loại phân bón vi lượng và đa lượng'),
(N'Thuốc kích thích sinh trưởng', N'Hỗ trợ cây trồng phát triển nhanh');
```

## 2. Bảng Nhà cung cấp (Suppliers)
```sql
INSERT INTO Suppliers (Name, Phone, Address, CreatedAt) VALUES 
(N'Công ty CP BVTV An Giang', '0283123456', N'An Giang, Việt Nam', GETDATE()),
(N'Tập đoàn Lộc Trời', '0283987654', N'TP. Hồ Chí Minh, Việt Nam', GETDATE()),
(N'Công ty Bayer Việt Nam', '0283456789', N'Đồng Nai, Việt Nam', GETDATE());
```

## 3. Bảng Người dùng (Users)
```sql
-- Lưu ý: Mật khẩu nên được băm (hash) trước khi chèn thực tế
INSERT INTO Users (Username, Password, FullName, Email, Role, Status, CreatedAt) VALUES 
('admin', 'admin123', N'Quản trị viên', 'admin@example.com', 'Admin', 1, GETDATE()),
('nhanvien1', '123456', N'Nguyễn Văn A', 'nv1@example.com', 'Staff', 1, GETDATE());
```

## 4. Bảng Sản phẩm (Products)
```sql
INSERT INTO Products (CategoryID, Name, Description, CreatedAt) VALUES 
(1, N'Bassa 50EC', N'Đặc trị rầy nâu', GETDATE()),
(1, N'Regent 800WG', N'Diệt trừ sâu cuốn lá', GETDATE()),
(2, N'Sofit 300EC', N'Diệt cỏ tiền nảy mầm', GETDATE());
```

## 5. Bảng Biến thể Sản phẩm (ProductVariants)
```sql
INSERT INTO ProductVariants (ProductID, Unit, Concentration, RetailPrice, WholesalePrice) VALUES 
(1, N'Chai 450ml', '50EC', 120000, 110000),
(1, N'Chai 1 lít', '50EC', 250000, 230000),
(2, N'Gói 1g', '800WG', 15000, 13000);
```

## 6. Bảng Khách hàng (Customers)
```sql
INSERT INTO Customers (Name, Phone, Address, CreatedAt) VALUES 
(N'Nguyễn Thị Bình', '0901234567', N'Cần Thơ, Việt Nam', GETDATE()),
(N'Trần Văn Dũng', '0912345678', N'Vĩnh Long, Việt Nam', GETDATE());
```

## 7. Bảng Nhập hàng (Imports)
```sql
INSERT INTO Imports (SupplierID, UserID, ImportDate, TotalAmount, Status) VALUES 
(1, 1, GETDATE(), 11000000, 'COMPLETED'),
(2, 1, GETDATE(), 1300000, 'COMPLETED');
```

## 8. Bảng Lô hàng (Batches)
```sql
INSERT INTO Batches (ImportID, VariantID, ImportPrice, InitialQuantity, RemainingQuantity, ManufactureDate, ExpiryDate) VALUES 
(1, 1, 110000, 100, 100, '2026-01-01', '2028-01-01'),
(2, 3, 13000, 100, 100, '2026-02-01', '2028-02-01');
```

## Ghi chú:
- Các trường `ID` (ProductID, CategoryID, ...) thường được thiết lập là `IDENTITY` (tự động tăng), nên không cần truyền vào câu lệnh INSERT trừ khi bạn bật `IDENTITY_INSERT`.
- Dữ liệu tiếng Việt nên bắt đầu bằng tiền tố `N` (ví dụ: `N'Tiếng Việt'`) để đảm bảo không bị lỗi font trong SQL Server.
