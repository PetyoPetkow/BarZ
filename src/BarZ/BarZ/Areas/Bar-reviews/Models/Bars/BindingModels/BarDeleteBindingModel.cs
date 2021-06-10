using BarZ.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarZ.Areas.Bar_reviews.Models.Bars.BindingModels
{
    public class BarDeleteBindingModel
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Destination")]
        public string DestinationName { get; set; }

    }
}
