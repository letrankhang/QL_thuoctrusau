# SQL Server Sample Data Insertion Script

Dưới đây là mã SQL để chèn dữ liệu mẫu cho hệ thống Quản lý cửa hàng thuốc trừ sâu. Script này được thiết kế để tuân thủ các ràng buộc khóa ngoại (Foreign Key).

```sql
-- 1. Chèn dữ liệu vào bảng Users
SET IDENTITY_INSERT Users ON;
INSERT INTO Users (UserID, Username, Password, FullName, Role, Status, CreatedAt)
VALUES 
(1, 'admin', 'admin123', N'Quản trị viên', 'ADMIN', 1, GETDATE()),
(2, 'staff1', 'staff123', N'Nguyễn Văn Nhân Viên', 'STAFF', 1, GETDATE());
SET IDENTITY_INSERT Users OFF;

-- 2. Chèn dữ liệu vào bảng Categories
SET IDENTITY_INSERT Categories ON;
INSERT INTO Categories (CategoryID, Name, Description)
VALUES 
(1, N'Thuốc trừ sâu', N'Các loại thuốc diệt trừ sâu hại'),
(2, N'Thuốc diệt cỏ', N'Các loại thuốc diệt cỏ dại'),
(3, N'Phân bón', N'Các loại phân bón hóa học và hữu cơ');
SET IDENTITY_INSERT Categories OFF;

-- 3. Chèn dữ liệu vào bảng Suppliers
SET IDENTITY_INSERT Suppliers ON;
INSERT INTO Suppliers (SupplierID, Name, Phone, Address, CreatedAt)
VALUES 
(1, N'Công ty CP BVTV An Giang', '0283838383', N'Long Xuyên, An Giang', GETDATE()),
(2, N'Tập đoàn Lộc Trời', '0283939393', N'TP. Hồ Chí Minh', GETDATE());
SET IDENTITY_INSERT Suppliers OFF;

-- 4. Chèn dữ liệu vào bảng Customers
SET IDENTITY_INSERT Customers ON;
INSERT INTO Customers (CustomerID, Name, Phone, Address, CreatedAt)
VALUES 
(1, N'Nguyễn Văn An', '0901234567', N'Huyện Chợ Mới, An Giang', GETDATE()),
(2, N'Trần Thị Bình', '0912345678', N'Huyện Thoại Sơn, An Giang', GETDATE());
SET IDENTITY_INSERT Customers OFF;

-- 5. Chèn dữ liệu vào bảng Products
SET IDENTITY_INSERT Products ON;
INSERT INTO Products (ProductID, CategoryID, Name, Description, CreatedAt)
VALUES 
(1, 1, N'Bassa 50EC', N'Thuốc trừ rầy nâu', GETDATE()),
(2, 1, N'Regent 800WG', N'Thuốc trừ sâu cuốn lá', GETDATE()),
(3, 2, N'Sofit 300EC', N'Thuốc trừ cỏ tiền nảy mầm', GETDATE());
SET IDENTITY_INSERT Products OFF;

-- 6. Chèn dữ liệu vào bảng ProductVariants
SET IDENTITY_INSERT ProductVariants ON;
INSERT INTO ProductVariants (VariantID, ProductID, Unit, Concentration, RetailPrice, WholesalePrice)
VALUES 
(1, 1, N'Chai 450ml', '50EC', 120000, 110000),
(2, 2, N'Gói 1g', '800WG', 15000, 13000),
(3, 3, N'Chai 500ml', '300EC', 250000, 230000);
SET IDENTITY_INSERT ProductVariants OFF;

-- 7. Chèn dữ liệu vào bảng Imports
SET IDENTITY_INSERT Imports ON;
INSERT INTO Imports (ImportID, SupplierID, UserID, ImportDate, TotalAmount, Status)
VALUES 
(1, 1, 1, GETDATE(), 11000000, 'COMPLETED'),
(2, 2, 1, GETDATE(), 1300000, 'COMPLETED');
SET IDENTITY_INSERT Imports OFF;

-- 8. Chèn dữ liệu vào bảng Batches
SET IDENTITY_INSERT Batches ON;
INSERT INTO Batches (BatchID, ImportID, VariantID, ImportPrice, InitialQuantity, RemainingQuantity, ManufactureDate, ExpiryDate)
VALUES 
(1, 1, 1, 110000, 100, 90, '2025-01-01', '2027-01-01'),
(2, 2, 2, 13000, 100, 100, '2025-02-01', '2027-02-01');
SET IDENTITY_INSERT Batches OFF;

-- 9. Chèn dữ liệu vào bảng Orders
SET IDENTITY_INSERT Orders ON;
INSERT INTO Orders (OrderID, CustomerID, UserID, OrderDate, TotalAmount, Status)
VALUES 
(1, 1, 2, GETDATE(), 1200000, 'COMPLETED');
SET IDENTITY_INSERT Orders OFF;

-- 10. Chèn dữ liệu vào bảng OrderDetails
SET IDENTITY_INSERT OrderDetails ON;
INSERT INTO OrderDetails (OrderDetailID, OrderID, VariantID, OrderQuantity, UnitPrice)
VALUES 
(1, 1, 1, 10, 120000);
SET IDENTITY_INSERT OrderDetails OFF;

-- 11. Chèn dữ liệu vào bảng OrderDetailBatches
SET IDENTITY_INSERT OrderDetailBatches ON;
INSERT INTO OrderDetailBatches (OrderDetailBatchID, OrderDetailID, BatchID, Quantity)
VALUES 
(1, 1, 1, 10);
SET IDENTITY_INSERT OrderDetailBatches OFF;

-- 12. Chèn dữ liệu vào bảng InventoryTransactions
SET IDENTITY_INSERT InventoryTransactions ON;
INSERT INTO InventoryTransactions (TransactionID, BatchID, Quantity, TransactionType, ReferenceID, CreatedAt)
VALUES 
(1, 1, 100, 'IMPORT', 1, GETDATE()),
(2, 2, 100, 'IMPORT', 2, GETDATE()),
(3, 1, -10, 'SALE', 1, GETDATE());
SET IDENTITY_INSERT InventoryTransactions OFF;

-- 13. Chèn dữ liệu vào bảng DebtTransactions
SET IDENTITY_INSERT DebtTransactions ON;
INSERT INTO DebtTransactions (DebtID, CustomerID, SupplierID, Amount, TransactionType, ReferenceOrderID, ReferenceImportID, TransactionDate, Note)
VALUES 
(1, NULL, 1, 11000000, 'PURCHASE', NULL, 1, GETDATE(), N'Nhập hàng Bassa'),
(2, 1, NULL, 1200000, 'SALE', 1, NULL, GETDATE(), N'Bán lẻ cho khách An');
SET IDENTITY_INSERT DebtTransactions OFF;
```
