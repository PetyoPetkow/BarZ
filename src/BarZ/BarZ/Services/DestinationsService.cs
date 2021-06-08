namespace BarZ.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BarZ.Areas.Bar_reviews.Models.Destinations.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;
    using BarZ.Data;
    using BarZ.Data.Models;
    using BarZ.Services.Interfaces;

    public class DestinationsService : IDestinationsService
    {
        private readonly ApplicationDbContext dbContext;

        public DestinationsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<IdNameViewModel> GetAll()
        {

            IEnumerable<IdNameViewModel> destinations = this.dbContext.Destinations
                .Select(destination => new IdNameViewModel
                {
                    Id = destination.Id,
                    Name = destination.Name,
                })
                .OrderBy(destination => destination.Name)
                .ToList();

            return destinations;
        }

        public DestinationUpdateBindingModel GetByIdForUpdateMethod(int id)
        {
            DestinationUpdateBindingModel destination =dbContext.Destinations
                .Select(d => new DestinationUpdateBindingModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    Bars = d.Bars,
                })
                .Where(d => d.Id == id)
                .SingleOrDefault();

            return destination;
        }

        public async Task<bool> UpdateAsync(DestinationUpdateBindingModel model)
        {
            Destination destination = GetDestinationById(model.Id);
            
            bool isDestinationNull = destination == null;
            if (isDestinationNull)
            {
                return false;
            }

            destination.Name = model.Name;
            destination.Description = model.Description;

            this.dbContext.Destinations.Update(destination);
            await this.dbContext.SaveChangesAsync();

            return true;
        }
        private Destination GetDestinationById(int Id)
        {
            Destination destination = dbContext.Destinations
                .Where(d => d.Id == Id)
                .SingleOrDefault();

            return destination;
        }

    }
}
