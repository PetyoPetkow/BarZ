namespace BarZ.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BarZ.Areas.Bar_reviews.Models.Features.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Features.ViewModels;
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
        public IEnumerable<FeatureViewModel> GetAll()
        {
            IEnumerable<FeatureViewModel> features = dbContext.Features
                .Select(feature => new FeatureViewModel()
                {
                    Id = feature.Id,
                    FeatureName = feature.FeatureName,
                })
                .OrderBy(feature => feature.FeatureName)
                .ToList();

            return features;
        }
        public IEnumerable<Feature> GetAllFeaturesForViewBag()
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

        public FeatureUpdateBindingModel GetByIdForUpdateMethod(int? id)
        {
            FeatureUpdateBindingModel feature = dbContext.Features
                .Select(feature => new FeatureUpdateBindingModel
                {
                    Id = feature.Id,
                    FeatureName = feature.FeatureName,
                })
                .Where(f => f.Id == id)
                .FirstOrDefault();

            return feature;
        }

        public FeatureDeleteBindingModel GetByIdForDeleteMethod(int? id)
        {
            FeatureDeleteBindingModel feature = dbContext.Features
                .Select(feature => new FeatureDeleteBindingModel
                {
                    Id = feature.Id,
                    FeatureName = feature.FeatureName,
                })
                .Where(f => f.Id == id)
                .FirstOrDefault();
            return feature;
        }

        public async Task<int> CreateAsync(FeatureCreateBindingModel model)
        {
            Feature feature = new Feature()
            {
                FeatureName = model.FeatureName,
                Bars=model.Bars,
            };

            await dbContext.Features.AddAsync(feature);
            await dbContext.SaveChangesAsync();

            return feature.Id;
        }
        
        public async Task<bool> UpdateAsync(FeatureUpdateBindingModel model)
        {
            Feature feature = GetById(model.Id);

            feature.FeatureName = model.FeatureName;

            dbContext.Update(feature);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(FeatureDeleteBindingModel model)
        {
            Feature feature = GetById(model.Id);

            dbContext.Features.Remove(feature);
            await dbContext.SaveChangesAsync();
            return true;
        }
        
        private Feature GetById(int id)
        {
            Feature feature = dbContext.Features
                .Where(f => f.Id == id)
                .FirstOrDefault();

            return feature;
        }
    }
}
