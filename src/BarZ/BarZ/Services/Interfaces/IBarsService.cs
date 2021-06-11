namespace BarZ.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BarZ.Areas.Bar_reviews.Models.Bars.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Bars.ViewModels;
    using BarZ.Data.Models;

    public interface IBarsService
    {  
        IEnumerable<BarViewModel> GetAll();
        IEnumerable<BarViewModel> GetAllBarsInDestination(int id);
        IEnumerable<BarViewModel> ShowBarsByFeature(int id);
        IEnumerable<BarViewModel> SearchForABar(string name);
        Image GetBarImage(Bar model);
        BarViewModel GetById(int? id);
        BarUpdateBindingModel GetByIdForUpdateMethod(int id);
        BarDeleteBindingModel GetByIdForDeleteMethod(int? id);
        List<BarFeatureViewModel> PopulateSelectedFeaturesData(BarUpdateBindingModel bar);
        Task<int> CreateAsync(BarCreateBindingModel bar);
        Task<bool> UpdateAsync(BarUpdateBindingModel model, string[] selectedFeatures);
        Task<bool> DeleteAsync(int id);
    }
}
