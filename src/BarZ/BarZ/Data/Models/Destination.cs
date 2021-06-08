namespace BarZ.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Destination
    {
        public Destination()
        {
            this.Bars = new HashSet<Bar>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        [DisplayName("Destination")]
        public string Name { get; set; }

        [DisplayName("Info:")]
        public string Description { get; set; }

        public virtual ICollection<Bar> Bars { get; set; }
    }
}
