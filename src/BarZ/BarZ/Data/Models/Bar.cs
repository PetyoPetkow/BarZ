namespace BarZ.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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

        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime BeginningOfTheWorkDay { get; set; }

        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime EndOfTheWorkDay { get; set; }

        [Required]
        public string Description { get; set; }

        public string FacebookPageUrl { get; set; }

        [Required]
        public int DestinationId { get; set; }

        public virtual Destination Destination {get; set; }

        public virtual ICollection<Feature> Features { get; set; }
    }
}
