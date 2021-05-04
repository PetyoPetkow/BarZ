using BarZ.Areas.Bar_reviews.Models.Bars.BindingModels;
using BarZ.Areas.Bar_reviews.Models.Bars.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarZ.Services.Interfaces
{
    public interface IBarsService
    {
        BarViewModel GetById(int? id);
        IEnumerable<BarViewModel> GetAll();
        Task<int> CreateAsync(BarCreateBindingModel bar);
    }
}
