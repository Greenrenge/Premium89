
using System.Collections.Generic;

namespace Premium89.Models.Shopping
{
    public class SizeGroup
    {
        public SizeGroup()
        {
            Sizes = new HashSet<Size>();
        }
        public int SizeGroupId { get; set; }
        public string SizeGroupName { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
    }
}