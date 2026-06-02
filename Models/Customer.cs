using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models 
{
    [Table ("Customers")]
    public class Customer {
        public Customer()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength (100)]
        public string Name { get; set; }

        [StringLength (15)]
        public string Phone { get; set; }

        [StringLength (255)]
        public string Address { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<DebtTransaction> DebtTransactions { get; set; }
    }
}