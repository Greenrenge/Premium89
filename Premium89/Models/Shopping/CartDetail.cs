using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Premium89.Models.Shopping
{
    public class CartItem
    {
        public long CartItemId { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        [StringLength(1)]
        [Required]
        public string Active { get; set; }

        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}