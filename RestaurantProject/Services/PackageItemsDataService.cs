using RestaurantProject.Data;
using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantProject.Services
{
    public class PackageItemsDataService : IPackageItemsDataService
    {
        private AppDbContext _appDbContext;
        public PackageItemsDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<PackageItems>> GetPackageItemsAsync()
        {
            return await _appDbContext.PackageItems.ToListAsync();
        }

        public async Task<List<PackageItems>> AddPackageItemAsync(PackageItems packageItem)
        {
            return null;
        }

        public async Task<List<PackageItems>> UpdatePackageItemAsync(PackageItems packageItem)
        {
            return null;
        }

        public async Task DeletePackageItemAsync(int packageId)
        {
            var items = await _appDbContext.PackageItems.Where(x => x.PackageId == packageId).ToListAsync();

            foreach (var item in items)
            {
                _appDbContext.PackageItems.Remove(item);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}