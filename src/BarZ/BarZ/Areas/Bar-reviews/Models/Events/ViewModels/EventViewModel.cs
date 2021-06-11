using BarZ.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarZ.Areas.Bar_reviews.Models.Events.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public DateTime DateAndTime { get; set; }

        public double? Fee { get; set; }

        public string Info { get; set; }

        public Bar Bar { get; set; }
    }
}
