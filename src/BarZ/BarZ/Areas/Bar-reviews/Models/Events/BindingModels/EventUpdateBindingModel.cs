namespace BarZ.Areas.Bar_reviews.Models.Events.BindingModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using BarZ.Data.Models;

    public class EventUpdateBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Event name")]
        public string EventName { get; set; }

        [Required]
        [DisplayName("Date and time")]
        public DateTime DateAndTime { get; set; }

        public decimal? Fee { get; set; }

        [MinLength(2)]
        [MaxLength(512)]
        public string Info { get; set; }

        public Bar Bar { get; set; }
    }
}
