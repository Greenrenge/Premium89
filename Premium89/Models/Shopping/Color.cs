using System.ComponentModel.DataAnnotations;

namespace Premium89.Models.Shopping
{
    public class Color
    {
        public Color()
        {

        }
        public long ColorId { get; set; }
        public string ColorName { get; set; }
        public string ColorRGB { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}