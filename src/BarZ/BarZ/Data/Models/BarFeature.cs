namespace BarZ.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BarFeature
    {
        public int Id { get; set; }

        [Required]
        public int BarId { get; set; }
        public virtual Bar Bar { get; set; }

        [Required]
        public string FeatureId { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
