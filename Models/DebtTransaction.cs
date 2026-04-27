using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models {
    [Table ("DebtTransactions")]
    public class DebtTransaction {
        public DebtTransaction()
        {
            TransactionDate = DateTime.Now;
        }

        [Key]
        public int DebtID { get; set; }

        public int? CustomerID { get; set; }
        public int? SupplierID { get; set; }

        [Column (TypeName = "decimal")]
        public decimal Amount { get; set; }

        [StringLength (20)]
        public string TransactionType { get; set; }

        public int? ReferenceOrderID { get; set; }
        public int? ReferenceImportID { get; set; }

        public DateTime? TransactionDate { get; set; }

        [StringLength (255)]
        public string Note { get; set; }

        [ForeignKey ("CustomerID")]
        public virtual Customer Customer { get; set; }

        [ForeignKey ("SupplierID")]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey ("ReferenceOrderID")]
        public virtual Order Order { get; set; }

        [ForeignKey ("ReferenceImportID")]
        public virtual Import Import { get; set; }
    }
}