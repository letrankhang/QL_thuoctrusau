using QL_CuaHangBanThuocTruSau.Models;
using System.Data.Entity;

namespace QL_CuaHangBanThuocTruSau.Context 
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext () : base ("name=AppDbContext")
        {
            Database.SetInitializer<AppDbContext>(null);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Import> Imports { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderDetailBatch> OrderDetailBatches { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<DebtTransaction> DebtTransactions { get; set; }

        protected override void OnModelCreating (DbModelBuilder modelBuilder) 
        {
            base.OnModelCreating (modelBuilder);

            // Tắt Cascade Delete cho quan hệ giữa OrderDetail và OrderDetailBatch
            modelBuilder.Entity<OrderDetailBatch> ()
                .HasRequired (odb => odb.OrderDetail)
                .WithMany (od => od.OrderDetailBatches)
                .HasForeignKey (odb => odb.OrderDetailID)
                .WillCascadeOnDelete (false);

            // Tắt Cascade Delete cho quan hệ giữa Batch và OrderDetailBatch
            modelBuilder.Entity<OrderDetailBatch> ()
                .HasRequired (odb => odb.Batch)
                .WithMany ()
                .HasForeignKey (odb => odb.BatchID)
                .WillCascadeOnDelete (false);
        }
    }
}