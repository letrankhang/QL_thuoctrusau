using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models 
{
    [Table ("Categories")]
    public class Category {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength (100)]
        public string Name { get; set; }

        [StringLength (255)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}