namespace BarZ.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BarZ.Areas.Bar_reviews.Models.Bars.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Bars.ViewModels;
    using BarZ.Data.Models;

    public interface IBarsService
    {
        Image GetBarImage(Bar model);
        IEnumerable<BarViewModel> GetAll();
        BarViewModel GetById(int? id);
        BarUpdateBindingModel GetByIdForUpdateMethod(int id);
        IEnumerable<BarViewModel> GetAllBarsInDestination(int id);
        BarDeleteBindingModel GetByIdForDeleteMethod(int? id);
        IEnumerable<BarViewModel> ShowBarsByFeature(int id);
        Task<int> CreateAsync(BarCreateBindingModel bar);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(BarUpdateBindingModel model, string[] selectedFeatures);
        List<BarFeatureViewModel> PopulateSelectedFeaturesData(BarUpdateBindingModel bar);
        IEnumerable<BarViewModel> SearchForABar(string name);
    }
}
