namespace BarZ.Services.Interfaces
{
    using System.Collections.Generic;

    using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;

    public interface IDestinationsService
    {
        IEnumerable<IdNameViewModel> GetAll();

    }
}
