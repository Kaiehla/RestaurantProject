using RestaurantProject.Models;

namespace RestaurantProject.Services
{
    public interface IPackageMenuDataService
    {
        Task<List<PackageMenu>> GetPackageMenusAsync();
        Task<PackageMenu> GetSinglePackageMenuAsync(int id);
        Task<List<string>> GetPackagesAsync();
        Task<List<decimal>> GetPricesAsync();
        Task<List<int>> GetIdsAsync();
        Task AddPackageMenuAsync(PackageMenu packageMenu);
        Task UpdatePackageMenuAsync(PackageMenu packageMenu);
        Task DeletePackageMenuAsync(int id);
        Task<Tuple<List<PackageMenu>, List<PackageItems>>> GetMenuAndDetailsAsync();
    }
}