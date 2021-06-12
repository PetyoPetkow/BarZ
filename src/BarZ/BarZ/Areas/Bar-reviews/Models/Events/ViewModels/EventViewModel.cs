using BarZ.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BarZ.Areas.Bar_reviews.Models.Events.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        [DisplayName("DAte and time:")]
        public DateTime DateAndTime { get; set; }

        [DisplayName("Admission fee:")]
        public decimal? Fee { get; set; }

        public string FeeInDollars
        {
            get { return string.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", Fee); }
        }
        [DisplayName("Info:")]
        public string Info { get; set; }

        public Bar Bar { get; set; }
    }
}
