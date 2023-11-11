using RestaurantProject.Data;
using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.Services
{
    public class PackageMenuDataService : IPackageMenuDataService
    {
        private List<Package_Menu> _packageMenu;
        private AppDbContext _appDbContext;

        public PackageMenuDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Package_Menu>> GetPackage_MenusAsync()
        {
            var packageMenu = await _appDbContext.Package_Menu.ToListAsync();
            return packageMenu;
        }

        public async Task<List<Package_Menu>> AddPackage_MenuAsync(Package_Menu model)
        {
            await _appDbContext.Package_Menu.AddAsync(model);
            await _appDbContext.SaveChangesAsync();

            return null;
        }

        public async Task<List<Package_Menu>> UpdatePackage_MenuAsync(Package_Menu model)
        {
            return null;
        }

        public async Task<List<Package_Menu>> DeletePackage_MenuAsync(Package_Menu model)
        {
            return null;
        }

    }
}
