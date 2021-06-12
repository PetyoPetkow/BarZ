//namespace BarZ.Services
//{
//    using System.Threading.Tasks;

//    using BarZ.Data;
//    using BarZ.Data.Models;
//    using BarZ.Services.Interfaces;

//    public class BarsFeaturesService : IBarsFeaturesService
//    {
//        private readonly ApplicationDbContext dbContext;

//        public BarsFeaturesService(ApplicationDbContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }

//        public async Task<bool> AddFeatureToABar(int barId, int featureId)
//        {
//            BarFeature barFeature = new BarFeature()
//            {
//                BarId = barId,
//                FeatureId = featureId,
//            };

//            await this.dbContext.BarsFeatures.AddAsync(barFeature);
//            await this.dbContext.SaveChangesAsync();

//            return true;
//        }
//    }
//}
