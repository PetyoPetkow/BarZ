namespace BarZ.Areas.Bar_reviews.Models.Destinations.BindingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BarZ.Data.Models;

    public class DestinationCreateBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Bar> Bars { get; set; }
    }
}
