using BarZ.Areas.Bar_reviews.Models.Bars.ViewModels;

namespace BarZ.Services.Interfaces
{
    public interface IBarsService
    {
        BarViewModel GetById(int? id);
    }
}
