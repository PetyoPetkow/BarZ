namespace BarZ.Services.Interfaces
{
    using System.Collections.Generic;

    using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;
    using BarZ.Data.Models;

    public interface IFeaturesService
    {
        IEnumerable<Feature> GetAll();

    }
}
