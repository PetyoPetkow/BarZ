namespace BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels
{
    using System.Collections.Generic;

    using BarZ.Data.Models;
    
    public class DestinationViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Bar> Bars { get; set; }
    }
}
