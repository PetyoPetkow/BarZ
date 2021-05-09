namespace BarZ.Data.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageDir { get; set; }
        public string ImageName { get; set; }
        public string ImageExtention { get; set; }
        public int BarId { get; set; }
        public Bar Bar { get; set; }

    }
}
