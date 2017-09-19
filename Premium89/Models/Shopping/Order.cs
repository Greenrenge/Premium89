using System;
using System.Collections.Generic;
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
        public string ShippingAddress { get; set; }

        public long OrderId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}