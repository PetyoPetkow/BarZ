namespace BarZ.Areas.Bar_reviews.Models.Events.BindingModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using BarZ.Data.Models;

    public class EventDeleteBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string EventName { get; set; }

        [DisplayName("Date and time:")]
        public DateTime DateAndTime { get; set; }

        [DisplayName("Bar:")]
        public Bar Bar { get; set; }

        [MinLength(2)]
        [MaxLength(512)]
        [DisplayName("Info:")]
        public string Info { get; set; }
    }
}
