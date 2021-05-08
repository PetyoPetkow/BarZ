namespace BarZ.Services
{
    using BarZ.Areas.Bar_reviews.Models.Bars.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Bars.ViewModels;
    using BarZ.Data;
    using BarZ.Data.Models;
    using BarZ.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class BarsService : IBarsService
    {
        private const string ImagesFolder = "/Images/";
        private readonly ApplicationDbContext dbContext;

        public IImageService ImageService { get; }

        public BarsService(ApplicationDbContext dbContext, IImageService service)
        {
            this.dbContext = dbContext;
            this.ImageService = service;
        }

        public async Task<int> CreateAsync(BarCreateBindingModel model)//,string ImageDir)
        {
            Bar bar = new Bar();
            var fullPath=string.Empty;
            if (model.image!=null)
            {
                var res = await ImageService.Upload(model.image);//, ImageDir);

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

            
            dbContext.SaveChanges();

            return bar.Id;
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

        public async Task<bool> DeleteAsync(int id)
        {
            Bar bar = this.GetBarById(id);

            bool isNull = bar == null;
            if (isNull)
            {
                return false;
            }

            await ImageService.Delete(id);

            this.dbContext.Bars.Remove(bar);
            await this.dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateAsync(BarUpdateBindingModel model/*, string ImageDir*/)
        {
            Bar bar = GetBarById(model.Id);
            Image image = GetBarImage(bar);
            var fullPath = string.Empty;

            if (model.image!=null)
            {
                
                var res = await ImageService.Upload(model.image);//, ImageDir);

                fullPath = ImagesFolder + res[1] + res[2];

                dbContext.Images.Add(new Image()
                {
                    ImageDir = res[0],
                    ImageName = res[1],
                    ImageExtention = res[2],
                    Bar = bar,
                });
            }
            //var res =await ImageService.Upload(model.image);//, ImageDir);

            //var fullPath = ImagesFolder + res[1] + res[2];


            bool isBarNull = bar == null;
            if (isBarNull)
            {
                return false;
            }

            bar.Name = model.Name;
            bar.Image = image;

            if (fullPath!=string.Empty)
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

        public BarUpdateBindingModel GetByIdForUpdateMethod(int id)
        {
            
            
            BarUpdateBindingModel bar = this.dbContext.Bars
                .Select(b => new BarUpdateBindingModel
                {
                    Id = b.Id,
                    Name = b.Name,
                  
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
        private Bar GetBarById(int id)
        {
            Bar bar = this.dbContext.Bars
                .Where(l => l.Id == id)
                .SingleOrDefault();

            return bar;
        }
        public Image GetBarImage(Bar model)
        {
            Image image = this.dbContext.Images.Where(x=>x.BarId==model.Id).FirstOrDefault();
      


            return image;
        }
        
        
    }
}
