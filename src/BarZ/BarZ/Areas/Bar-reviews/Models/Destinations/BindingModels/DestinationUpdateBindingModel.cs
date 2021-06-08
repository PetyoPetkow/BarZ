using BarZ.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarZ.Areas.Bar_reviews.Models.Destinations.BindingModels
{
    public class DestinationUpdateBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Bar> Bars { get; set; }
    }
}
