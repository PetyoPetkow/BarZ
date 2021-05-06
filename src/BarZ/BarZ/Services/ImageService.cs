using BarZ.Data;
using BarZ.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using BarZ.Data.Models;
using System.Linq;

namespace BarZ.Services
{
    public class ImageService : IImageService
    {
        private const string ImagesFolder = "Images";
        private const string contentRoot = "wwwroot";
        private readonly ApplicationDbContext dbContext;

        public ImageService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<string[]> Upload(IFormFile file, string imageDir)
        {
            var data = new string[3];
            var imageName = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(file.FileName);

            data[0] = "~/" + contentRoot + "/" + ImagesFolder;
            data[1] = imageName;
            data[2] = extension;

            var fullPath = imageDir + "\\" + ImagesFolder + "\\" + imageName + extension;

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return data;
        }
        public async Task Delete(int id)
        {
            Image image = this.dbContext.Images
               .Where(i => i.BarId == id)
               .SingleOrDefault();

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", image.ImageName+image.ImageExtention);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    } 
}