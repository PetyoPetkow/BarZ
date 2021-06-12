namespace BarZ.Areas.Bar_reviews.Models.Bars.BindingModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class BarDeleteBindingModel
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Info:")]
        public string Description { get; set; }

        [DisplayName("Destination:")]
        public string DestinationName { get; set; }

    }
}
