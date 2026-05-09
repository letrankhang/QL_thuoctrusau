# SQL Server Seed Data Script

Tài liệu này chứa các câu lệnh SQL để chèn dữ liệu mẫu vào tất cả các bảng trong hệ thống Quản lý cửa hàng thuốc trừ sâu.

## Thứ tự chèn dữ liệu
Để tránh lỗi ràng buộc khóa ngoại, dữ liệu được chèn theo thứ tự sau:
1. **Users**, **Categories**, **Suppliers**, **Customers** (Các bảng độc lập)
2. **Products** (Phụ thuộc Categories)
3. **ProductVariants** (Phụ thuộc Products)
4. **Imports** (Phụ thuộc Suppliers, Users)
5. **Batches** (Phụ thuộc Imports, ProductVariants)
6. **Orders** (Phụ thuộc Customers, Users)
7. **OrderDetails** (Phụ thuộc Orders, ProductVariants)
8. **OrderDetailBatches** (Phụ thuộc OrderDetails, Batches)
9. **InventoryTransactions** (Phụ thuộc Batches)
10. **DebtTransactions** (Phụ thuộc Customers, Suppliers, Orders, Imports)

---

## SQL Script

```sql
-- Dọn dẹp dữ liệu cũ (Tùy chọn - CẨN THẬN)
/*
DELETE FROM DebtTransactions;
DELETE FROM InventoryTransactions;
DELETE FROM OrderDetailBatches;
DELETE FROM OrderDetails;
DELETE FROM Orders;
DELETE FROM Batches;
DELETE FROM Imports;
DELETE FROM ProductVariants;
DELETE FROM Products;
DELETE FROM Customers;
DELETE FROM Suppliers;
DELETE FROM Categories;
DELETE FROM Users;
*/

-- 1. Chèn dữ liệu vào bảng Users
SET IDENTITY_INSERT Users ON;
INSERT INTO Users (UserID, Username, Password, FullName, Email, Role, Status, CreatedAt)
VALUES 
(1, 'admin', 'admin123', N'Quản trị viên', 'admin@example.com', 'ADMIN', 1, GETDATE()),
(2, 'staff1', 'staff123', N'Nguyễn Văn Nhân Viên', 'staff1@example.com', 'STAFF', 1, GETDATE()),
(3, 'staff2', 'staff456', N'Trần Thị Bán Hàng', 'staff2@example.com', 'STAFF', 1, GETDATE());
SET IDENTITY_INSERT Users OFF;

-- 2. Chèn dữ liệu vào bảng Categories
SET IDENTITY_INSERT Categories ON;
INSERT INTO Categories (CategoryID, Name, Description)
VALUES 
(1, N'Thuốc trừ sâu', N'Các loại thuốc diệt trừ sâu hại cây trồng'),
(2, N'Thuốc diệt cỏ', N'Các loại thuốc diệt cỏ dại'),
(3, N'Phân bón', N'Các loại phân bón hóa học và hữu cơ'),
(4, N'Thuốc kích thích sinh trưởng', N'Hỗ trợ cây phát triển nhanh');
SET IDENTITY_INSERT Categories OFF;

-- 3. Chèn dữ liệu vào bảng Suppliers
SET IDENTITY_INSERT Suppliers ON;
INSERT INTO Suppliers (SupplierID, Name, Phone, Address, CreatedAt)
VALUES 
(1, N'Công ty CP BVTV An Giang', '0283838383', N'Long Xuyên, An Giang', GETDATE()),
(2, N'Tập đoàn Lộc Trời', '0283939393', N'TP. Hồ Chí Minh', GETDATE()),
(3, N'Công ty Bayer Việt Nam', '0284445555', N'KCN Biên Hòa, Đồng Nai', GETDATE());
SET IDENTITY_INSERT Suppliers OFF;

-- 4. Chèn dữ liệu vào bảng Customers
SET IDENTITY_INSERT Customers ON;
INSERT INTO Customers (CustomerID, Name, Phone, Address, CreatedAt)
VALUES 
(1, N'Nguyễn Văn An', '0901234567', N'Huyện Chợ Mới, An Giang', GETDATE()),
(2, N'Trần Thị Bình', '0912345678', N'Huyện Thoại Sơn, An Giang', GETDATE()),
(3, N'Lê Văn Cường', '0922334455', N'Huyện Châu Thành, An Giang', GETDATE());
SET IDENTITY_INSERT Customers OFF;

-- 5. Chèn dữ liệu vào bảng Products
SET IDENTITY_INSERT Products ON;
INSERT INTO Products (ProductID, CategoryID, Name, Description, ImagePath, CreatedAt)
VALUES 
(1, 1, N'Bassa 50EC', N'Thuốc trừ rầy nâu', 'bassa_50ec.png', GETDATE()),
(2, 1, N'Regent 800WG', N'Thuốc trừ sâu cuốn lá', 'regent_800wg.png', GETDATE()),
(3, 2, N'Sofit 300EC', N'Thuốc trừ cỏ tiền nảy mầm', 'sofit_300ec.png', GETDATE()),
(4, 3, N'Phân bón NPK 16-16-8', N'Phân bón lá cao cấp', 'npk_16168.png', GETDATE());
SET IDENTITY_INSERT Products OFF;

-- 6. Chèn dữ liệu vào bảng ProductVariants
SET IDENTITY_INSERT ProductVariants ON;
INSERT INTO ProductVariants (VariantID, ProductID, Unit, Concentration, RetailPrice, WholesalePrice)
VALUES 
(1, 1, N'Chai 450ml', '50EC', 120000, 110000),
(2, 2, N'Gói 1g', '800WG', 15000, 13000),
(3, 3, N'Chai 500ml', '300EC', 250000, 230000),
(4, 4, N'Bao 50kg', 'N/A', 850000, 800000);
SET IDENTITY_INSERT ProductVariants OFF;

-- 7. Chèn dữ liệu vào bảng Imports
SET IDENTITY_INSERT Imports ON;
INSERT INTO Imports (ImportID, SupplierID, UserID, ImportDate, TotalAmount, Status)
VALUES 
(1, 1, 1, GETDATE(), 11000000, 'COMPLETED'),
(2, 2, 1, GETDATE(), 1300000, 'COMPLETED'),
(3, 3, 1, GETDATE(), 2500000, 'COMPLETED');
SET IDENTITY_INSERT Imports OFF;

-- 8. Chèn dữ liệu vào bảng Batches
SET IDENTITY_INSERT Batches ON;
INSERT INTO Batches (BatchID, ImportID, VariantID, ImportPrice, InitialQuantity, RemainingQuantity, ManufactureDate, ExpiryDate)
VALUES 
(1, 1, 1, 110000, 100, 85, '2026-01-01', '2028-01-01'),
(2, 2, 2, 13000, 100, 100, '2026-02-01', '2028-02-01'),
(3, 3, 3, 230000, 10, 10, '2026-03-01', '2028-03-01');
SET IDENTITY_INSERT Batches OFF;

-- 9. Chèn dữ liệu vào bảng Orders
SET IDENTITY_INSERT Orders ON;
INSERT INTO Orders (OrderID, CustomerID, UserID, OrderDate, TotalAmount, Status)
VALUES 
(1, 1, 2, GETDATE(), 1200000, 'COMPLETED'),
(2, 2, 3, GETDATE(), 600000, 'COMPLETED');
SET IDENTITY_INSERT Orders OFF;

-- 10. Chèn dữ liệu vào bảng OrderDetails
SET IDENTITY_INSERT OrderDetails ON;
INSERT INTO OrderDetails (OrderDetailID, OrderID, VariantID, OrderQuantity, UnitPrice)
VALUES 
(1, 1, 1, 10, 120000),
(2, 2, 1, 5, 120000);
SET IDENTITY_INSERT OrderDetails OFF;

-- 11. Chèn dữ liệu vào bảng OrderDetailBatches
SET IDENTITY_INSERT OrderDetailBatches ON;
INSERT INTO OrderDetailBatches (OrderDetailBatchID, OrderDetailID, BatchID, Quantity)
VALUES 
(1, 1, 1, 10),
(2, 2, 1, 5);
SET IDENTITY_INSERT OrderDetailBatches OFF;

-- 12. Chèn dữ liệu vào bảng InventoryTransactions
SET IDENTITY_INSERT InventoryTransactions ON;
INSERT INTO InventoryTransactions (TransactionID, BatchID, Quantity, TransactionType, ReferenceID, CreatedAt)
VALUES 
(1, 1, 100, 'IMPORT', 1, GETDATE()),
(2, 2, 100, 'IMPORT', 2, GETDATE()),
(3, 3, 10, 'IMPORT', 3, GETDATE()),
(4, 1, -10, 'SALE', 1, GETDATE()),
(5, 1, -5, 'SALE', 2, GETDATE());
SET IDENTITY_INSERT InventoryTransactions OFF;

-- 13. Chèn dữ liệu vào bảng DebtTransactions
SET IDENTITY_INSERT DebtTransactions ON;
INSERT INTO DebtTransactions (DebtID, CustomerID, SupplierID, Amount, TransactionType, ReferenceOrderID, ReferenceImportID, TransactionDate, Note)
VALUES 
(1, NULL, 1, 11000000, 'PURCHASE', NULL, 1, GETDATE(), N'Nhập hàng Bassa lô 1'),
(2, 1, NULL, 1200000, 'SALE', 1, NULL, GETDATE(), N'Bán lẻ cho khách An'),
(3, 2, NULL, 600000, 'SALE', 2, NULL, GETDATE(), N'Bán lẻ cho khách Bình');
SET IDENTITY_INSERT DebtTransactions OFF;
```
