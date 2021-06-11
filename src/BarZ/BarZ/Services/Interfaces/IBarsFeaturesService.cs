namespace BarZ.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IBarsFeaturesService
    {
        Task<bool> AddFeatureToABar(int barId, int featureId);
    }
}
