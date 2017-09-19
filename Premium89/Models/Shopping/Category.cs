using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Premium89.Models.Shopping
{
    public class Category
    {
        public Category()
        {
            ChildCates = new HashSet<Category>();
            Products = new HashSet<Product>();
            Active = "A";
        }
        [Key]
        public long CategoryId { get; set; }

        [Index(IsUnique = true)]
        [Required]
        public string CategoryName { get; set; }

        //[ForeignKey("ParentCate")]
        public long? ParentCategoryId { get; set; }

        public virtual Category ParentCate { get; set; }

        public virtual ICollection<Category> ChildCates { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        [StringLength(1)]
        [Required]
        public string Active { get; set; }
    }
}