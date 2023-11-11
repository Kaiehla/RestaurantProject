using RestaurantProject.Models;

namespace RestaurantProject.Services
{
    public interface IPackageMenuDataService
    {
        Task<List<Package_Menu>> GetPackage_MenusAsync();
        Task<List<Package_Menu>> AddPackage_MenuAsync(Package_Menu packageMenu);
        Task<List<Package_Menu>> UpdatePackage_MenuAsync(Package_Menu packageMenu);
        Task<List<Package_Menu>> DeletePackage_MenuAsync(Package_Menu packageMenu);
    }
}
