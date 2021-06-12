namespace BarZ.Areas.Bar_reviews.Models.Features.BindingModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class FeatureUpdateBindingModel
    {   
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Feature name")]
        public string FeatureName { get; set; }
    }
}
