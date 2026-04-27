using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_CuaHangBanThuocTruSau.Models {
    [Table ("Users")]
    public class User {
        public User()
        {
            Status = true;
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength (50)]
        public string Username { get; set; }

        [Required]
        [StringLength (255)]
        public string Password { get; set; }

        [StringLength (100)]
        public string FullName { get; set; }

        [StringLength (20)]
        public string Role { get; set; }

        public bool Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Import> Imports { get; set; }
    }
}