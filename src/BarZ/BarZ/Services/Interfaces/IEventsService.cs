using BarZ.Areas.Bar_reviews.Models.Events.BindingModels;
using BarZ.Areas.Bar_reviews.Models.Events.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarZ.Services.Interfaces
{
    public interface IEventsService
    {
        IEnumerable<EventViewModel> GetAllFutureEvents();
        IEnumerable<EventViewModel> GetAllPastEvents();
        EventUpdateBindingModel GetByIdForUpdateMethod(int? id);
        EventDeleteBindingModel GetByIdForDeleteMethod(int? id);
        EventViewModel GetById(int? id);
        Task<int> CreateAsync(EventCreateBindingModel feature);
        Task<bool> UpdateAsync(EventUpdateBindingModel model);
        Task<bool> DeleteAsync(int id);
    }
}
