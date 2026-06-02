using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models 
{
    [Table ("OrderDetailBatches")]
    public class OrderDetailBatch {
        [Key]
        public int OrderDetailBatchID { get; set; }

        public int OrderDetailID { get; set; }
        public int BatchID { get; set; }

        public int Quantity { get; set; }

        [ForeignKey ("OrderDetailID")]
        public virtual OrderDetail OrderDetail { get; set; }

        [ForeignKey ("BatchID")]
        public virtual Batch Batch { get; set; }
    }
}