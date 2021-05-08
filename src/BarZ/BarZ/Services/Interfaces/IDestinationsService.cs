using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarZ.Services.Interfaces
{
    public interface IDestinationsService
    {
        IEnumerable<IdNameViewModel> GetAll();

    }
}
