namespace QL_CuaHangBanThuocTruSau.Migrations {
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration {
        public override void Up () {
            CreateTable (
                "dbo.Batches",
                c => new
                {
                    BatchID = c.Int (nullable: false, identity: true),
                    ImportID = c.Int (nullable: false),
                    VariantID = c.Int (nullable: false),
                    ImportPrice = c.Decimal (nullable: false, precision: 18, scale: 2),
                    InitialQuantity = c.Int (nullable: false),
                    RemainingQuantity = c.Int (nullable: false),
                    ManufactureDate = c.DateTime (storeType: "date"),
                    ExpiryDate = c.DateTime (nullable: false, storeType: "date"),
                })
                .PrimaryKey (t => t.BatchID)
                .ForeignKey ("dbo.Imports", t => t.ImportID, cascadeDelete: true)
                .ForeignKey ("dbo.ProductVariants", t => t.VariantID, cascadeDelete: true)
                .Index (t => t.ImportID)
                .Index (t => t.VariantID);

            CreateTable (
                "dbo.Imports",
                c => new
                {
                    ImportID = c.Int (nullable: false, identity: true),
                    SupplierID = c.Int (nullable: false),
                    UserID = c.Int (nullable: false),
                    ImportDate = c.DateTime (),
                    TotalAmount = c.Decimal (nullable: false, precision: 18, scale: 2),
                    Status = c.String (maxLength: 20),
                })
                .PrimaryKey (t => t.ImportID)
                .ForeignKey ("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey ("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index (t => t.SupplierID)
                .Index (t => t.UserID);

            CreateTable (
                "dbo.Suppliers",
                c => new
                {
                    SupplierID = c.Int (nullable: false, identity: true),
                    Name = c.String (nullable: false, maxLength: 100),
                    Phone = c.String (maxLength: 15),
                    Address = c.String (maxLength: 255),
                    CreatedAt = c.DateTime (),
                })
                .PrimaryKey (t => t.SupplierID);

            CreateTable (
                "dbo.DebtTransactions",
                c => new
                {
                    DebtID = c.Int (nullable: false, identity: true),
                    CustomerID = c.Int (),
                    SupplierID = c.Int (),
                    Amount = c.Decimal (nullable: false, precision: 18, scale: 2),
                    TransactionType = c.String (maxLength: 20),
                    ReferenceOrderID = c.Int (),
                    ReferenceImportID = c.Int (),
                    TransactionDate = c.DateTime (),
                    Note = c.String (maxLength: 255),
                })
                .PrimaryKey (t => t.DebtID)
                .ForeignKey ("dbo.Customers", t => t.CustomerID)
                .ForeignKey ("dbo.Imports", t => t.ReferenceImportID)
                .ForeignKey ("dbo.Orders", t => t.ReferenceOrderID)
                .ForeignKey ("dbo.Suppliers", t => t.SupplierID)
                .Index (t => t.CustomerID)
                .Index (t => t.SupplierID)
                .Index (t => t.ReferenceOrderID)
                .Index (t => t.ReferenceImportID);

            CreateTable (
                "dbo.Customers",
                c => new
                {
                    CustomerID = c.Int (nullable: false, identity: true),
                    Name = c.String (nullable: false, maxLength: 100),
                    Phone = c.String (maxLength: 15),
                    Address = c.String (maxLength: 255),
                    CreatedAt = c.DateTime (),
                })
                .PrimaryKey (t => t.CustomerID);

            CreateTable (
                "dbo.Orders",
                c => new
                {
                    OrderID = c.Int (nullable: false, identity: true),
                    CustomerID = c.Int (nullable: false),
                    UserID = c.Int (nullable: false),
                    OrderDate = c.DateTime (),
                    TotalAmount = c.Decimal (nullable: false, precision: 18, scale: 2),
                    Status = c.String (maxLength: 20),
                })
                .PrimaryKey (t => t.OrderID)
                .ForeignKey ("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey ("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index (t => t.CustomerID)
                .Index (t => t.UserID);

            CreateTable (
                "dbo.OrderDetails",
                c => new
                {
                    OrderDetailID = c.Int (nullable: false, identity: true),
                    OrderID = c.Int (nullable: false),
                    VariantID = c.Int (nullable: false),
                    OrderQuantity = c.Int (nullable: false),
                    UnitPrice = c.Decimal (nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey (t => t.OrderDetailID)
                .ForeignKey ("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey ("dbo.ProductVariants", t => t.VariantID, cascadeDelete: true)
                .Index (t => t.OrderID)
                .Index (t => t.VariantID);

            CreateTable (
                "dbo.OrderDetailBatches",
                c => new
                {
                    OrderDetailBatchID = c.Int (nullable: false, identity: true),
                    OrderDetailID = c.Int (nullable: false),
                    BatchID = c.Int (nullable: false),
                    Quantity = c.Int (nullable: false),
                })
                .PrimaryKey (t => t.OrderDetailBatchID)
                .ForeignKey ("dbo.Batches", t => t.BatchID, cascadeDelete: false)
                .ForeignKey ("dbo.OrderDetails", t => t.OrderDetailID, cascadeDelete: false)
                .Index (t => t.OrderDetailID)
                .Index (t => t.BatchID);

            CreateTable (
                "dbo.ProductVariants",
                c => new
                {
                    VariantID = c.Int (nullable: false, identity: true),
                    ProductID = c.Int (nullable: false),
                    Unit = c.String (nullable: false, maxLength: 50),
                    Concentration = c.String (maxLength: 50),
                    RetailPrice = c.Decimal (nullable: false, precision: 18, scale: 2),
                    WholesalePrice = c.Decimal (nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey (t => t.VariantID)
                .ForeignKey ("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index (t => t.ProductID);

            CreateTable (
                "dbo.Products",
                c => new
                {
                    ProductID = c.Int (nullable: false, identity: true),
                    CategoryID = c.Int (nullable: false),
                    Name = c.String (nullable: false, maxLength: 255),
                    Description = c.String (),
                    CreatedAt = c.DateTime (),
                })
                .PrimaryKey (t => t.ProductID)
                .ForeignKey ("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index (t => t.CategoryID);

            CreateTable (
                "dbo.Categories",
                c => new
                {
                    CategoryID = c.Int (nullable: false, identity: true),
                    Name = c.String (nullable: false, maxLength: 100),
                    Description = c.String (maxLength: 255),
                })
                .PrimaryKey (t => t.CategoryID);

            CreateTable (
                "dbo.Users",
                c => new
                {
                    UserID = c.Int (nullable: false, identity: true),
                    Username = c.String (nullable: false, maxLength: 50),
                    Password = c.String (nullable: false, maxLength: 255),
                    FullName = c.String (maxLength: 100),
                    Role = c.String (maxLength: 20),
                    Status = c.Boolean (nullable: false),
                    CreatedAt = c.DateTime (),
                })
                .PrimaryKey (t => t.UserID);

            CreateTable (
                "dbo.InventoryTransactions",
                c => new
                {
                    TransactionID = c.Int (nullable: false, identity: true),
                    BatchID = c.Int (nullable: false),
                    Quantity = c.Int (nullable: false),
                    TransactionType = c.String (maxLength: 20),
                    ReferenceID = c.Int (),
                    CreatedAt = c.DateTime (),
                })
                .PrimaryKey (t => t.TransactionID)
                .ForeignKey ("dbo.Batches", t => t.BatchID, cascadeDelete: true)
                .Index (t => t.BatchID);

        }

        public override void Down () {
            DropForeignKey ("dbo.InventoryTransactions", "BatchID", "dbo.Batches");
            DropForeignKey ("dbo.Imports", "SupplierID", "dbo.Suppliers");
            DropForeignKey ("dbo.DebtTransactions", "SupplierID", "dbo.Suppliers");
            DropForeignKey ("dbo.DebtTransactions", "ReferenceOrderID", "dbo.Orders");
            DropForeignKey ("dbo.DebtTransactions", "ReferenceImportID", "dbo.Imports");
            DropForeignKey ("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey ("dbo.Imports", "UserID", "dbo.Users");
            DropForeignKey ("dbo.OrderDetails", "VariantID", "dbo.ProductVariants");
            DropForeignKey ("dbo.ProductVariants", "ProductID", "dbo.Products");
            DropForeignKey ("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey ("dbo.Batches", "VariantID", "dbo.ProductVariants");
            DropForeignKey ("dbo.OrderDetailBatches", "OrderDetailID", "dbo.OrderDetails");
            DropForeignKey ("dbo.OrderDetailBatches", "BatchID", "dbo.Batches");
            DropForeignKey ("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey ("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey ("dbo.DebtTransactions", "CustomerID", "dbo.Customers");
            DropForeignKey ("dbo.Batches", "ImportID", "dbo.Imports");
            DropIndex ("dbo.InventoryTransactions", new[] { "BatchID" });
            DropIndex ("dbo.Products", new[] { "CategoryID" });
            DropIndex ("dbo.ProductVariants", new[] { "ProductID" });
            DropIndex ("dbo.OrderDetailBatches", new[] { "BatchID" });
            DropIndex ("dbo.OrderDetailBatches", new[] { "OrderDetailID" });
            DropIndex ("dbo.OrderDetails", new[] { "VariantID" });
            DropIndex ("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex ("dbo.Orders", new[] { "UserID" });
            DropIndex ("dbo.Orders", new[] { "CustomerID" });
            DropIndex ("dbo.DebtTransactions", new[] { "ReferenceImportID" });
            DropIndex ("dbo.DebtTransactions", new[] { "ReferenceOrderID" });
            DropIndex ("dbo.DebtTransactions", new[] { "SupplierID" });
            DropIndex ("dbo.DebtTransactions", new[] { "CustomerID" });
            DropIndex ("dbo.Imports", new[] { "UserID" });
            DropIndex ("dbo.Imports", new[] { "SupplierID" });
            DropIndex ("dbo.Batches", new[] { "VariantID" });
            DropIndex ("dbo.Batches", new[] { "ImportID" });
            DropTable ("dbo.InventoryTransactions");
            DropTable ("dbo.Users");
            DropTable ("dbo.Categories");
            DropTable ("dbo.Products");
            DropTable ("dbo.ProductVariants");
            DropTable ("dbo.OrderDetailBatches");
            DropTable ("dbo.OrderDetails");
            DropTable ("dbo.Orders");
            DropTable ("dbo.Customers");
            DropTable ("dbo.DebtTransactions");
            DropTable ("dbo.Suppliers");
            DropTable ("dbo.Imports");
            DropTable ("dbo.Batches");
        }
    }
}
