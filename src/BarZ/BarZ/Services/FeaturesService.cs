namespace BarZ.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;
    using BarZ.Data;
    using BarZ.Data.Models;
    using BarZ.Services.Interfaces;

    public class FeaturesService : IFeaturesService
    {
        private readonly ApplicationDbContext dbContext;

        public FeaturesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Feature> GetAll()
        {
            IEnumerable<Feature> features = dbContext.Features
                .Select(feature => new Feature()
                {
                    Id = feature.Id,
                    FeatureName = feature.FeatureName,
                })
                .OrderBy(feature => feature.FeatureName)
                .ToList();

            return features;
        }
    }
}
