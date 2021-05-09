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

    public class BarsService : IBarsService
    {
        private const string ImagesFolder = "/Images/";

        private readonly ApplicationDbContext dbContext;
        public readonly IImageService ImageService;

        public BarsService(ApplicationDbContext dbContext, IImageService service)
        {
            this.dbContext = dbContext;
            this.ImageService = service;
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
               })
               .Where(bar => bar.Id == id)
               .SingleOrDefault();

            return bar;
        }

        public BarUpdateBindingModel GetByIdForUpdateMethod(int id)
        {
            BarUpdateBindingModel bar = this.dbContext.Bars
                .Select(b => new BarUpdateBindingModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    PictureAdress = b.PictureAdress,
                    BeginningOfTheWorkDay = b.BeginningOfTheWorkDay,
                    EndOfTheWorkDay = b.EndOfTheWorkDay,
                    Description = b.Description,
                    FacebookPageUrl = b.FacebookPageUrl,
                    DestinationId = b.DestinationId
                })
                .Where(b => b.Id == id)
                .SingleOrDefault();

            return bar;
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

        public async Task<bool> UpdateAsync(BarUpdateBindingModel model)
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
            if (doesTheNewModelHavaAPicture)
            {
                ImageService.Delete(bar.Id);
                var res = await ImageService.Upload(model.image);

                fullPath = ImagesFolder + res[1] + res[2];

                image.ImageDir = res[0];
                image.ImageName = res[1];
                image.ImageExtention = res[2];
            }

            bar.Name = model.Name;

            bool isFullPathNotEmpty = fullPath != string.Empty;
            if (isFullPathNotEmpty)
            {
                bar.PictureAdress = fullPath;
            }
            bar.BeginningOfTheWorkDay = model.BeginningOfTheWorkDay;
            bar.EndOfTheWorkDay = model.EndOfTheWorkDay;
            bar.Description = model.Description;
            bar.FacebookPageUrl = model.FacebookPageUrl;
            bar.DestinationId = model.DestinationId;

            this.dbContext.Bars.Update(bar);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Bar bar = this.GetBarById(id);

            bool isNull = bar == null;
            if (isNull)
            {
                return false;
            }

            ImageService.Delete(id);

            this.dbContext.Bars.Remove(bar);
            await this.dbContext.SaveChangesAsync();

            return true;
        }
   
        private Bar GetBarById(int id)
        {
            Bar bar = this.dbContext.Bars
                .Where(l => l.Id == id)
                .SingleOrDefault();

            return bar;
        }
    }
}
