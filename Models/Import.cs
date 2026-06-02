using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models 
{
    [Table ("Imports")]
    public class Import {
        public Import()
        {
            ImportDate = DateTime.Now;
            TotalAmount = 0;
            Status = "COMPLETED";
        }

        [Key]
        public int ImportID { get; set; }

        public int SupplierID { get; set; }
        public int UserID { get; set; }

        public DateTime? ImportDate { get; set; }

        [Column (TypeName = "decimal")]
        public decimal TotalAmount { get; set; }

        [StringLength (20)]
        public string Status { get; set; }

        [ForeignKey ("SupplierID")]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey ("UserID")]
        public virtual User User { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
    }
}