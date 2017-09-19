using System.ComponentModel.DataAnnotations;

namespace Premium89.Models.Shopping
{
    public class Color
    {
        public Color()
        {
            Active = "A";
        }
        public long ColorId { get; set; }
        [Required]
        public string ColorName { get; set; }
        [Required]
        public string ColorRGB { get; set; }

        [StringLength(1)]
        [Required]
        public string Active { get; set; }
    }
}