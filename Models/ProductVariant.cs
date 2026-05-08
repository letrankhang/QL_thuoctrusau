using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models {
    [Table ("ProductVariants")]
    public class ProductVariant {
        public ProductVariant()
        {
            RetailPrice = 0;
            WholesalePrice = 0;
        }

        [Key]
        public int VariantID { get; set; }

        public int ProductID { get; set; }

        [Required]
        [StringLength (50)]
        public string Unit { get; set; }

        [StringLength (50)]
        public string Concentration { get; set; }

        [Column (TypeName = "decimal")]
        public decimal RetailPrice { get; set; }

        [Column (TypeName = "decimal")]
        public decimal WholesalePrice { get; set; }

        [ForeignKey ("ProductID")]
        public virtual Product Product { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
    }
}