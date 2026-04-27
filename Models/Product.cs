using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models {
    [Table ("Products")]
    public class Product {
        public Product()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength (255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        [ForeignKey ("CategoryID")]
        public virtual Category Category { get; set; }

        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}