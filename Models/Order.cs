using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models {
    [Table ("Orders")]
    public class Order {
        public Order()
        {
            OrderDate = DateTime.Now;
            TotalAmount = 0;
        }

        [Key]
        public int OrderID { get; set; }

        public int CustomerID { get; set; }
        public int UserID { get; set; }

        public DateTime? OrderDate { get; set; }

        [Column (TypeName = "decimal")]
        public decimal TotalAmount { get; set; }

        [StringLength (20)]
        public string Status { get; set; }

        [ForeignKey ("CustomerID")]
        public virtual Customer Customer { get; set; }

        [ForeignKey ("UserID")]
        public virtual User User { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<DebtTransaction> DebtTransactions { get; set; }
    }
}