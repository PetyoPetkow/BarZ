namespace BarZ.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BarZ.Areas.Bar_reviews.Models.Destinations.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;

    public interface IDestinationsService
    {
        IEnumerable<IdNameViewModel> GetAll();
        DestinationUpdateBindingModel GetByIdForUpdateMethod(int id);
        Task<bool> UpdateAsync(DestinationUpdateBindingModel model);
        DestinationViewModel GetByIdForDetailsMethod(int? id);
    }
}
