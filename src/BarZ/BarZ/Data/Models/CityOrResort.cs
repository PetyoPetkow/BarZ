using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarZ.Data.Models
{
    public class CityOrResort
    {
        public CityOrResort()
        {
            this.Bars = new HashSet<Bar>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string Name { get; set; }

        public virtual ICollection<Bar> Bars { get; set; }
    }
}
