using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Premium89.Models.Shopping
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public DateTime OrderDate { get; set; }
        public decimal GrandTotal { get; set; }
        [Required]
        public string ShippingAddress { get; set; }

        public long OrderId { get; set; }

        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }

        [StringLength(1)]
        [Required]
        public string Active { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}