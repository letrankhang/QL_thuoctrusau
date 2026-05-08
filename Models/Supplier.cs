using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models {
    [Table ("Suppliers")]
    public class Supplier {
        public Supplier()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int SupplierID { get; set; }

        [Required]
        [StringLength (100)]
        public string Name { get; set; }

        [StringLength (15)]
        public string Phone { get; set; }

        [StringLength (255)]
        public string Address { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Import> Imports { get; set; }
        public virtual ICollection<DebtTransaction> DebtTransactions { get; set; }
    }
}