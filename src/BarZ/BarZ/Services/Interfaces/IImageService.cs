namespace BarZ.Services.Interfaces
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    
    public interface IImageService
    {
        Task<string[]> Upload(IFormFile file);
        void Delete(int id);

    }
}
