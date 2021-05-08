using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string PictureAdress { get; set; }

        public virtual Image Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime BeginningOfTheWorkDay { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime EndOfTheWorkDay { get; set; }

        [Required]
        public string Description { get; set; }

        public string FacebookPageUrl { get; set; }

        [Required]
        public int DestinationId { get; set; }
        public virtual Destination Destination {get; set; }
    }
}
