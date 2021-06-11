using BarZ.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarZ.Areas.Bar_reviews.Models.Features.BindingModels
{
    public class FeatureUpdateBindingModel
    {   
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string FeatureName { get; set; }
    }
}
