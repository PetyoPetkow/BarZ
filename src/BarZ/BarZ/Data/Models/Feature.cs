namespace BarZ.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Feature
    {
        public Feature()
        {
            this.FeaturesBars = new HashSet<BarFeature>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string FeatureName { get; set; }

        public virtual ICollection<BarFeature> FeaturesBars { get; set; }

    }
}
