namespace Premium89.Models.Shopping
{
    public class Size
    {
        public Size()
        {
                
        }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string SizeDescription { get; set; }

        public int? SizeGroupId { get; set; }

        public virtual SizeGroup SizeGroup { get; set; } 
    }
}