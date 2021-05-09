namespace BarZ.Services
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using BarZ.Data;
    using BarZ.Data.Models;
    using BarZ.Services.Interfaces;

    public class ImageService : IImageService
    {
        private const string ImagesFolder = "Images";
        private const string contentRoot = "wwwroot";
        private readonly ApplicationDbContext dbContext;

        public ImageService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string[]> Upload(IFormFile file)
        {
            bool isFileNull = file == null;
            if (isFileNull)
            {
                return null;
            }

            var data = new string[3];
            var imageName = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(file.FileName);

            data[0] = "~/" + contentRoot + "/" + ImagesFolder;
            data[1] = imageName;
            data[2] = extension;

            var fullPath = contentRoot + "\\" + ImagesFolder + "\\" + imageName + extension;

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return data;
        }

        public void Delete(int id)
        {
            Image image = this.GetImageById(id);
       
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\", image.ImageName+image.ImageExtention);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
       
        private Image GetImageById(int id)
        {
            Image image = this.dbContext.Images
               .Where(i => i.BarId == id)
               .SingleOrDefault();

            return image;
        }
    } 
}