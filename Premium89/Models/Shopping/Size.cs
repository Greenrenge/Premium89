using System.ComponentModel.DataAnnotations;

namespace Premium89.Models.Shopping
{
    public class Size
    {
        public Size()
        {
            Active = "A";
        }
        public int SizeId { get; set; }
        [Required]
        public string SizeName { get; set; }
        public string SizeDescription { get; set; }

        public int? SizeGroupId { get; set; }

        public virtual SizeGroup SizeGroup { get; set; }

        [StringLength(1)]
        [Required]
        public string Active { get; set; }
    }
}