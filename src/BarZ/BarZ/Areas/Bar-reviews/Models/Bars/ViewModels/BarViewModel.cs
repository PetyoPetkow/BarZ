namespace BarZ.Areas.Bar_reviews.Models.Bars.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using BarZ.Data.Models;

    public class BarViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PictureAdress { get; set; }

        public virtual Image Image { get; set; }

        [DisplayName("Open")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime BeginningOfTheWorkDay { get; set; }


        [DisplayName("Close")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime EndOfTheWorkDay { get; set; }


        [DisplayName("Review")]
        public string Description { get; set; }

        [DisplayName("Facebook page")]
        public string FacebookPageUrl { get; set; }

        public virtual Destination Destination { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Feature> Features { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

