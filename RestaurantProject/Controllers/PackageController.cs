using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Models;
using RestaurantProject.Services;

namespace RestaurantProject.Controllers
{
    public class PackageController : Controller
    {
        private IPackageMenuDataService _packageMenu;

        public PackageController(IPackageMenuDataService packageMenu)
        {
            _packageMenu = packageMenu;
        }

        public async Task<IActionResult> PackageView()
        {
            var packageMenu = await _packageMenu.GetPackage_MenusAsync();
            return View(packageMenu);
        }

    }
}
