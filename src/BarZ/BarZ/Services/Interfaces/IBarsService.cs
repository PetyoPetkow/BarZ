using BarZ.Areas.Bar_reviews.Models.Bars.ViewModels;
using System.Collections.Generic;

namespace BarZ.Services.Interfaces
{
    public interface IBarsService
    {
        BarViewModel GetById(int? id);
        IEnumerable<BarViewModel> GetAll();
    }
}
