using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarZ.Data.Models
{
    public class Bar
    {
        public Bar()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string Name { get; set; }

        public DateTime? BeginningOfTheWorkDay { get; set; }

        public DateTime? EndOfTheWorkDay { get; set; }

        [Required]
        public string Description { get; set; }

        public string FacebookPageUrl { get; set; }

        [Required]
        public int DestinationId { get; set; }
        public virtual Destination Destination {get; set; }
    }
}
