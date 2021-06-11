namespace BarZ.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BarZ.Areas.Bar_reviews.Models.Features.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Features.ViewModels;
    using BarZ.Data.Models;

    public interface IFeaturesService
    {
        IEnumerable<FeatureViewModel> GetAll();
        IEnumerable<Feature> GetAllFeaturesForViewBag();
        FeatureUpdateBindingModel GetByIdForUpdateMethod(int? id);
        FeatureDeleteBindingModel GetByIdForDeleteMethod(int? id);
        Task<int> CreateAsync(FeatureCreateBindingModel feature);
        Task<bool> UpdateAsync(FeatureUpdateBindingModel model);
        Task<bool> DeleteAsync(FeatureDeleteBindingModel model);
    }
}
