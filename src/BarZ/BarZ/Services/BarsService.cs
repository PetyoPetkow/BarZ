namespace BarZ.Services
{
    using BarZ.Areas.Bar_reviews.Models.Bars.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Bars.ViewModels;
    using BarZ.Data;
    using BarZ.Data.Models;
    using BarZ.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BarsService : IBarsService
    {
        private readonly ApplicationDbContext dbContext;

        public BarsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(BarCreateBindingModel model)
        { 
            Bar bar = new Bar();
            bar.Name = model.Name;
            bar.BeginningOfTheWorkDay = model.BeginningOfTheWorkDay;
            bar.EndOfTheWorkDay = model.EndOfTheWorkDay;
            bar.Description = model.Description;
            bar.FacebookPageUrl = model.FacebookPageUrl;
            bar.DestinationId = model.DestinationId;

            await this.dbContext.Bars.AddAsync(bar);
            await this.dbContext.SaveChangesAsync();

            return bar.Id;
        }

        public IEnumerable<BarViewModel> GetAll()
        {
            IEnumerable<BarViewModel> bars = this.dbContext.Bars
                .Select(bar => new BarViewModel
                {
                    Id = bar.Id,
                    Name = bar.Name,
                    BeginningOfTheWorkDay = bar.BeginningOfTheWorkDay,
                    EndOfTheWorkDay = bar.EndOfTheWorkDay,
                    Description = bar.Description,
                    FacebookPageUrl = bar.FacebookPageUrl,
                    Destination = bar.Destination,
                })
                .ToList();
            return bars;
        }

        public BarViewModel GetById(int? id)
        {
            BarViewModel bar = dbContext.Bars
               .Select(bar => new BarViewModel
               {
                   Id = bar.Id,
                   Name = bar.Name,
                   BeginningOfTheWorkDay = bar.BeginningOfTheWorkDay,
                   EndOfTheWorkDay = bar.EndOfTheWorkDay,
                   Description = bar.Description,
                   FacebookPageUrl = bar.FacebookPageUrl,
                   Destination = bar.Destination,
               })
               .Where(bar => bar.Id == id)
               .SingleOrDefault();

            return bar;
        }
    }
}
