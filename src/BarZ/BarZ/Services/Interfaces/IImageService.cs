namespace BarZ.Services.Interfaces
{
    using BarZ.Data.Models;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public interface IImageService
    {
        public Task<string[]> Upload(IFormFile file, string imageDir);
        Task Delete(int id);

    }
}
