using BarZ.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarZ.Areas.Bar_reviews.Models.Features.ViewModels
{
    public class FeatureViewModel
    {
        public int Id { get; set; }

        public string FeatureName { get; set; }

        public virtual ICollection<Bar>Bars { get; set; }
    }
}
