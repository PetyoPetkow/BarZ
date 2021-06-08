namespace BarZ.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BarZ.Areas.Bar_reviews.Models.Bars.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Bars.ViewModels;
    using BarZ.Data;
    using BarZ.Data.Models;
    using BarZ.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public class BarsService : IBarsService
    {
        private const string ImagesFolder = "/Images/";

        private readonly ApplicationDbContext dbContext;
        public readonly IImageService ImageService;
        public readonly IFeaturesService featuresService;

        public BarsService(ApplicationDbContext dbContext, IImageService service, IFeaturesService featuresService)
        {
            this.dbContext = dbContext;
            this.ImageService = service;
            this.featuresService = featuresService;
        }

        public Image GetBarImage(Bar model)
        {
            Image image = this.dbContext.Images.Where(x => x.BarId == model.Id).FirstOrDefault();

            return image;
        }

        public IEnumerable<BarViewModel> GetAll()
        {
            IEnumerable<BarViewModel> bars = this.dbContext.Bars
                .Select(bar => new BarViewModel
                {
                    Id = bar.Id,
                    Name = bar.Name,
                    PictureAdress = bar.PictureAdress,
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
                   Features = bar.Features,
               })
               .Where(bar => bar.Id == id)
               .SingleOrDefault();

            return bar;
        }

        public BarUpdateBindingModel GetByIdForUpdateMethod(int id)
        {
            BarUpdateBindingModel bar = this.dbContext.Bars
                .Include(b => b.Features)
                .Select(b => new BarUpdateBindingModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    PictureAdress = b.PictureAdress,
                    BeginningOfTheWorkDay = b.BeginningOfTheWorkDay,
                    EndOfTheWorkDay = b.EndOfTheWorkDay,
                    Description = b.Description,
                    FacebookPageUrl = b.FacebookPageUrl,
                    DestinationId = b.DestinationId,
                    Features = b.Features,
                })
                .Where(b => b.Id == id)
                .SingleOrDefault();

            PopulateSelectedFeaturesData(bar);

            return bar;
        }

        public IEnumerable<BarViewModel> GetAllBarsInDestination(int id)
        {
            IEnumerable<BarViewModel> bars = this.dbContext.Bars
                .Select(bar => new BarViewModel
                {
                    Id = bar.Id,
                    Name = bar.Name,
                    PictureAdress = bar.PictureAdress,
                    BeginningOfTheWorkDay = bar.BeginningOfTheWorkDay,
                    EndOfTheWorkDay = bar.EndOfTheWorkDay,
                    Description = bar.Description,
                    FacebookPageUrl = bar.FacebookPageUrl,
                    Destination = bar.Destination,
                })
                .Where(bar => bar.Destination.Id == id)
                .ToList();
            return bars;
        }

        public async Task<int> CreateAsync(BarCreateBindingModel model)
        {
            Bar bar = new Bar();
            var fullPath=string.Empty;

            bool doesTheModelHaveAPicture = model.image != null;
            if (doesTheModelHaveAPicture)
            {
                var res = await ImageService.Upload(model.image);

                fullPath = ImagesFolder + res[1] + res[2];

                dbContext.Images.Add(new Image()
                {
                    ImageDir = res[0],
                    ImageName = res[1],
                    ImageExtention = res[2],
                    Bar = bar,
                });
            }

            bar.Name = model.Name;
            bar.PictureAdress = fullPath;
            bar.BeginningOfTheWorkDay = model.BeginningOfTheWorkDay;
            bar.EndOfTheWorkDay = model.EndOfTheWorkDay;
            bar.Description = model.Description;
            bar.FacebookPageUrl = model.FacebookPageUrl;
            bar.DestinationId = model.DestinationId;

            await this.dbContext.Bars.AddAsync(bar);
            await this.dbContext.SaveChangesAsync();
            this.dbContext.SaveChanges();

            return bar.Id;
        }

        public async Task<bool> UpdateAsync(BarUpdateBindingModel model, string[] selectedFeatures)
        {
            Bar bar = GetBarById(model.Id);
            Image image = GetBarImage(bar);
            var fullPath = string.Empty;

            bool isBarNull = bar == null;
            if (isBarNull)
            {
                return false;
            }

            bool doesTheNewModelHavaAPicture = model.image != null;
            bool doesTheOldModelHaveAPicture = image != null;
            if (doesTheNewModelHavaAPicture)
            {
                if (doesTheOldModelHaveAPicture)
                {
                    ImageService.Delete(bar.Id);
                }

                var res = await ImageService.Upload(model.image);

                fullPath = ImagesFolder + res[1] + res[2];

                dbContext.Images.Add(new Image()
                {
                    ImageDir = res[0],
                    ImageName = res[1],
                    ImageExtention = res[2],
                    Bar = bar,
                });
            }

            bool isFullPathNotEmpty = fullPath != string.Empty;
            if (isFullPathNotEmpty)
            {
                bar.PictureAdress = fullPath;
            }
            bar.Name = model.Name;
            bar.BeginningOfTheWorkDay = model.BeginningOfTheWorkDay;
            bar.EndOfTheWorkDay = model.EndOfTheWorkDay;
            bar.Description = model.Description;
            bar.FacebookPageUrl = model.FacebookPageUrl;
            bar.DestinationId = model.DestinationId;

            //---------------------------------------

            try
            {
                UpdateBarFeatures(selectedFeatures, bar);

                dbContext.Entry(bar).State = EntityState.Modified;
                dbContext.SaveChanges();

            }
            catch (RetryLimitExceededException)
            {
                System.Console.WriteLine("asdas");
            }

            this.dbContext.Bars.Update(bar);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Bar bar = this.GetBarById(id);
            Image image = GetBarImage(bar);

            bool isNull = bar == null;
            if (isNull)
            {
                return false;
            }

            if (image!=null)
            {
                ImageService.Delete(id);
            }

            this.dbContext.Bars.Remove(bar);
            await this.dbContext.SaveChangesAsync();

            return true;
        }
   
        private Bar GetBarById(int id)
        {
            Bar bar = this.dbContext.Bars
                .Include(b=>b.Features)
                .Where(l => l.Id == id)
                .SingleOrDefault();

            return bar;
        }

        public List<BarFeatureViewModel> PopulateSelectedFeaturesData(BarUpdateBindingModel bar)
        {
            var allFeatures = dbContext.Features;
            var barFeatures = new HashSet<int>(bar.Features.Select(f => f.Id));
            var viewModel = new List<BarFeatureViewModel>();

            foreach (var feature in allFeatures)
            {
                viewModel.Add(new BarFeatureViewModel
                {
                    FeatureId = feature.Id,
                    FeatureName = feature.FeatureName,
                    Selected = barFeatures.Contains(feature.Id),

                });
            }
            return viewModel;
        }

        private void UpdateBarFeatures(string[] selectedFeatures, Bar barToUpdate)
        {
            if (selectedFeatures==null)
            {
                barToUpdate.Features = new List<Feature>();
                return;
            }

            var selectedFeaturesHS = new HashSet<string>(selectedFeatures);
            var barFeatures = new HashSet<int>(barToUpdate.Features.Select(f => f.Id));
            foreach (var feature in dbContext.Features)
            {
                if (selectedFeaturesHS.Contains(feature.Id.ToString()))
                {
                    if (!barFeatures.Contains(feature.Id))
                    {
                        barToUpdate.Features.Add(feature);
                    }
                }
                else
                {
                    barToUpdate.Features.Remove(feature);
                }
            }
        }
    }
}
