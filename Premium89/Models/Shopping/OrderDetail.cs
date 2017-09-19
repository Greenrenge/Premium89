using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Premium89.Models.Shopping
{
    public class OrderDetail
    {
        public OrderDetail()
        {
            Active = "A";
        }
        public long OrderDetailId { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalTHB { get; set; }

        public long OrderId { get; set; }
        public virtual Order Order { get; set; }

        [StringLength(1)]
        [Required]
        public string Active { get; set; }

    }
}