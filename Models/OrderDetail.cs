using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models {
    [Table ("OrderDetails")]
    public class OrderDetail {
        [Key]
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }
        public int VariantID { get; set; }

        public int OrderQuantity { get; set; }

        [Column (TypeName = "decimal")]
        public decimal UnitPrice { get; set; }

        [ForeignKey ("OrderID")]
        public virtual Order Order { get; set; }

        [ForeignKey ("VariantID")]
        public virtual ProductVariant ProductVariant { get; set; }

        public virtual ICollection<OrderDetailBatch> OrderDetailBatches { get; set; }
    }
}