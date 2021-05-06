namespace BarZ.Services.Interfaces
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public interface IImageService
    {
        public Task<string[]> Upload(IFormFile file, string imageDir);
    }
}
