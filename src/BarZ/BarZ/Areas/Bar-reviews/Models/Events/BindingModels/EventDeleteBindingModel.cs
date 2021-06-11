namespace BarZ.Areas.Bar_reviews.Models.Events.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EventDeleteBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string EventName { get; set; }

        public DateTime DateAndTime { get; set; }

        [MinLength(2)]
        [MaxLength(512)]
        public string Info { get; set; }
    }
}
