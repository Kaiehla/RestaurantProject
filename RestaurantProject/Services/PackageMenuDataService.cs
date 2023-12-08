using RestaurantProject.Data;
using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.Services
{
    public class PackageMenuDataService : IPackageMenuDataService
    {
        private List<PackageMenu> _packageMenu;
        private AppDbContext _appDbContext;

        public PackageMenuDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<PackageMenu>> GetPackageMenusAsync()
        {
            return await _appDbContext.PackageMenu.ToListAsync();
        }
        public async Task<PackageMenu> GetSinglePackageMenuAsync(int id)
        {
            var singlePackageMenu = await _appDbContext.PackageMenu.Where(x => x.Id == id).FirstAsync();
            return singlePackageMenu;
        }
        public async Task AddPackageMenuAsync(PackageMenu packageMenu)
        {
            await _appDbContext.PackageMenu.AddAsync(packageMenu);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task DeletePackageMenuAsync(int id)
        {
            var package = await _appDbContext.PackageMenu.FindAsync(id);

            _appDbContext.PackageMenu.Remove(package);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task UpdatePackageMenuAsync(PackageMenu packageMenu)
        {
            var selectedpackageMenu = await _appDbContext.PackageMenu.Where(x => x.Id == packageMenu.Id).FirstOrDefaultAsync();

            if (selectedpackageMenu != null)
            {
                selectedpackageMenu.PackageName = packageMenu.PackageName;
                selectedpackageMenu.PackageDescription = packageMenu.PackageDescription;
                selectedpackageMenu.Price = packageMenu.Price;
                selectedpackageMenu.Duration = packageMenu.Duration;

                await _appDbContext.SaveChangesAsync();
            }
        }
        public async Task<List<string>> GetPackagesAsync()
        {
            List<string> packages = await _appDbContext.PackageMenu.Select(pm => pm.PackageName).ToListAsync();
            return packages;
        }

        public async Task<List<decimal>> GetPricesAsync()
        {
            List<decimal> prices = await _appDbContext.PackageMenu.Select(pm => pm.Price).ToListAsync();
            return prices;
        }
        public async Task<List<int>> GetIdsAsync()
        {
            List<int> prices = await _appDbContext.PackageMenu.Select(pm => pm.Id).ToListAsync();
            return prices;
        }

        public async Task<Tuple<List<PackageMenu>, List<PackageItems>>> GetMenuAndDetailsAsync()
        {
            var packageMenu = await _appDbContext.PackageMenu.ToListAsync();
            var packageItems = await _appDbContext.PackageItems.ToListAsync();

            var tuple = new Tuple<List<PackageMenu>, List<PackageItems>>(packageMenu, packageItems);

            return tuple;
        }
    }
}