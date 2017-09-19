
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Premium89.Models.Shopping
{
    public class SizeGroup
    {
        public SizeGroup()
        {
            Sizes = new HashSet<Size>();
            Active = "A";
        }
        public int SizeGroupId { get; set; }
        [Required]
        public string SizeGroupName { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
        [StringLength(1)]
        [Required]
        public string Active { get; set; }
    }
}