using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarZ.Areas.Bar_reviews.Models.Bars.ViewModels
{
    public class BarFeatureViewModel
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool Selected { get; set; }
    }
}
