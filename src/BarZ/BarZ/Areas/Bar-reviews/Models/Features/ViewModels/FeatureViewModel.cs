namespace BarZ.Areas.Bar_reviews.Models.Features.ViewModels
{
    using System.Collections.Generic;

    using BarZ.Data.Models;

    public class FeatureViewModel
    {
        public int Id { get; set; }

        public string FeatureName { get; set; }

        public virtual ICollection<Bar>Bars { get; set; }
    }
}
