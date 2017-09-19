using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Premium89.Models.Shopping
{
    public class Link
    {
        public Link()
        {

        }
        public long LinkId { get; set; }
        public string ServerDomain { get; set; }
        [Required]
        public string PhysicalPath { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileExtension { get; set; }
        public int Order { get; set; }

        [StringLength(1)]
        [Required]
        public string Active { get; set; }

        [Required]
        [ForeignKey("Product")]
        public long ProductId { get; set; }

        public virtual Product Product{get;set; }

    }
}