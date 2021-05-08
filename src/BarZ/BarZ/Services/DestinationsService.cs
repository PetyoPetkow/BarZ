using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;
using BarZ.Data;
using BarZ.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarZ.Services
{
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

    }
}
