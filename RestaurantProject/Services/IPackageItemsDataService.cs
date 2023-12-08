using RestaurantProject.Models;

namespace RestaurantProject.Services
{
    public interface IPackageItemsDataService
    {
        Task<List<PackageItems>> GetPackageItemsAsync();
        Task<List<PackageItems>> AddPackageItemAsync(PackageItems packageItem);
        Task<List<PackageItems>> UpdatePackageItemAsync(PackageItems packageItem);
        Task DeletePackageItemAsync(int packageId);
    }
}
