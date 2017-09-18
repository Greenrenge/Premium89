using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Premium89.Models.Shopping
{
    public class Product
    {
        public Product()
        {
            Sizes = new HashSet<Size>();
            Colors = new HashSet<Color>();
            PictureUrls = new HashSet<Link>();
            Categories = new HashSet<Category>();
        }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductShortDescription { get; set; }
        [StringLength(10000)]
        public string ProductLongDescription { get; set; }
        [StringLength(10000)]
        public string ProductSpecification { get; set; }
        public long ItemLeft { get; set; }
        public decimal PriceTHB { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<Link> PictureUrls { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}