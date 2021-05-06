namespace BarZ.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
