using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models 
{
    [Table ("Batches")]
    public class Batch {
        [Key]
        public int BatchID { get; set; }

        public int ImportID { get; set; }
        public int VariantID { get; set; }

        [Column (TypeName = "decimal")]
        public decimal ImportPrice { get; set; }

        public int InitialQuantity { get; set; }
        public int RemainingQuantity { get; set; }

        [Column (TypeName = "date")]
        public DateTime? ManufactureDate { get; set; }

        [Required]
        [Column (TypeName = "date")]
        public DateTime ExpiryDate { get; set; }

        [ForeignKey ("ImportID")]
        public virtual Import Import { get; set; }

        [ForeignKey ("VariantID")]
        public virtual ProductVariant ProductVariant { get; set; }

        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
    }
}