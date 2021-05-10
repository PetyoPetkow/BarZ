namespace BarZ.Data.Models
{
    using System.Collections.Generic;
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
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Bar> Bars { get; set; }
    }
}
