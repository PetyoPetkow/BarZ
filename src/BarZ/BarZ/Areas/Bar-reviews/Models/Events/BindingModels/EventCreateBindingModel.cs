namespace BarZ.Areas.Bar_reviews.Models.Events.BindingModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class EventCreateBindingModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [Required]
        [DisplayName("Date and time")]
        public DateTime DateAndTime { get; set; }

        public decimal? Fee { get; set; }

        [MinLength(2)]
        [MaxLength(512)]
        public string Info { get; set; }

        [Required]
        [DisplayName("Bar")]
        public int BarId { get; set; }
    }
}
