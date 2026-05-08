using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models {
    [Table ("InventoryTransactions")]
    public class InventoryTransaction {
        public InventoryTransaction()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int TransactionID { get; set; }

        public int BatchID { get; set; }
        public int Quantity { get; set; }

        [StringLength (20)]
        public string TransactionType { get; set; }

        public int? ReferenceID { get; set; }

        public DateTime? CreatedAt { get; set; }

        [ForeignKey ("BatchID")]
        public virtual Batch Batch { get; set; }
    }
}