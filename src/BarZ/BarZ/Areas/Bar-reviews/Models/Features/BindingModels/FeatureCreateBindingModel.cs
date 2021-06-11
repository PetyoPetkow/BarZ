namespace BarZ.Areas.Bar_reviews.Models.Features.BindingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BarZ.Data.Models;

    public class FeatureCreateBindingModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string FeatureName { get; set; }

        public virtual ICollection<Bar> Bars { get; set; }
    }
}
