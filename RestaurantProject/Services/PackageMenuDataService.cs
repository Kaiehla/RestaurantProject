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
            var packageMenu = await _appDbContext.PackageMenu.ToListAsync();
            return packageMenu;
        }

        public async Task<List<PackageMenu>> AddPackageMenuAsync(PackageMenu model)
        {
            await _appDbContext.PackageMenu.AddAsync(model);
            await _appDbContext.SaveChangesAsync();

            return null;
        }

        public async Task<List<PackageMenu>> UpdatePackageMenuAsync(PackageMenu model)
        {
            return null;
        }

        public async Task<List<PackageMenu>> DeletePackageMenuAsync(PackageMenu model)
        {
            return null;
        }

        public async Task<List<PackageFullDetails>> GetPackageFullDetailsAsync()
        {
            var asd = await _appDbContext.PackageMenu.ToListAsync();

            var packageFullDetails = await (from pi in _appDbContext.PackageItems
                                            join pm in _appDbContext.PackageMenu
                                            on pi.PackageId equals pm.Id
                                            select new PackageFullDetails()
                                            {
                                                PackageMenuId = pm.Id,
                                                PackageName = pm.PackageName,
                                                PackageDescription = pm.PackageDescription,
                                                PackageItem = pi.Item,
                                                ImageLink = pm.ImageLink,
                                                Price = pm.Price,
                                                Duration = pm.Duration,
                                                RecommendedNumber = pm.RecommendedNumber
                                            }).ToListAsync();

            return packageFullDetails;
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