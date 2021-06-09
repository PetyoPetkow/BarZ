namespace BarZ.Areas.Bar_reviews.Models.Bars.BindingModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using BarZ.Data.Models;
    using Microsoft.AspNetCore.Http;

    public class BarCreateBindingModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string Name { get; set; }

        public IFormFile image { get; set; }

        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        [DisplayName("Open at")]
        public DateTime BeginningOfTheWorkDay { get; set; }

        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        [DisplayName("Close at")]
        public DateTime EndOfTheWorkDay { get; set; }

        [Required]
        public string Description { get; set; }

        [MinLength(2)]
        [MaxLength(512)]
        [DisplayName("Facebook page")]
        public string FacebookPageUrl { get; set; }

        [DisplayName("Destination")]
        [Required]
        public int DestinationId { get; set; }

        public ICollection<Feature> Features { get; set; } 
    }
}
