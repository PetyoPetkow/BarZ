namespace BarZ.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;
    using BarZ.Data.Models;

    public interface IBarsFeaturesService
    {
        Task<bool> AddFeatureToABar(int barId, int featureId);
    }
}
