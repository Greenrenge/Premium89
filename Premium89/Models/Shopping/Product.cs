using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            Active = "A";
        }
        public long ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string ProductShortDescription { get; set; }
        [StringLength(10000)]
        public string ProductLongDescription { get; set; }
        [StringLength(10000)]
        public string ProductSpecification { get; set; }
        public long ItemLeft { get; set; }
        public decimal OriginalPriceTHB { get; set; }
        public DateTime? SaleStartPeriod { get; set; }
        public DateTime? SaleEndPeriod { get; set; }

        [NotMapped]
        public bool IsSale
        {
            get
            {
                if (SaleStartPeriod.HasValue && SaleEndPeriod.HasValue)
                    return DateTime.Now >= SaleStartPeriod && DateTime.Now <= SaleEndPeriod;
                else if (!SaleStartPeriod.HasValue && !SaleEndPeriod.HasValue) return false;
                else if (!SaleStartPeriod.HasValue) return DateTime.Now <= SaleEndPeriod;
                else return DateTime.Now >= SaleStartPeriod;
            }
        }

        [NotMapped]
        public decimal Price { get { if (IsSale) return DiscountedPriceTHB; else return OriginalPriceTHB; } }
        public decimal DiscountedPriceTHB { get; set; }

        [StringLength(1)]
        [Required]
        public string Active { get; set; }

        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<Link> PictureUrls { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}