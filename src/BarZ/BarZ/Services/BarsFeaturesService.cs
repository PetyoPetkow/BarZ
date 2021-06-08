using BarZ.Data;
using BarZ.Data.Models;
using BarZ.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarZ.Services
{
    public class BarsFeaturesService : IBarsFeaturesService
    {
        private readonly ApplicationDbContext dbContext;

        public BarsFeaturesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddFeatureToABar(int barId, int featureId)
        {
            BarFeature barFeature = new BarFeature()
            {
                BarId = barId,
                FeatureId = featureId,
            };

            await this.dbContext.BarsFeatures.AddAsync(barFeature);
            await this.dbContext.SaveChangesAsync();

            return true;
        }
    }
}
