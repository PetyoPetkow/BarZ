namespace BarZ.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BarZ.Areas.Bar_reviews.Models.Destinations.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;
    using BarZ.Data.Models;

    public interface IDestinationsService
    {
        IEnumerable<IdNameViewModel> GetAll();
        DestinationUpdateBindingModel GetByIdForUpdateMethod(int id);
        Task<bool> UpdateAsync(DestinationUpdateBindingModel model);
        DestinationViewModel GetByIdForDetailsMethod(int? id);
        Task<int> CreateAsync(DestinationCreateBindingModel model);
        Task<bool> DeleteAsync(int id);
        Destination GetByIdForDeleteMethod(int? id);
    }
}
