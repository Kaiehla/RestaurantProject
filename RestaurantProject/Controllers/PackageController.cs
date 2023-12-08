using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Models;
using RestaurantProject.Services;

namespace RestaurantProject.Controllers
{
    public class PackageController : Controller
    {
        private IPackageMenuDataService _packageMenu;
        private IReservationDataService _reservation;
        private IPackageItemsDataService _packageItems;

        public PackageController(IPackageMenuDataService packageMenu, IReservationDataService reservation, IPackageItemsDataService packageItems)
        {
            _packageMenu = packageMenu;
            _reservation = reservation;
            _packageItems = packageItems;
        }

        public async Task<IActionResult> PackageView()
        {
            var packageMenu = await _packageMenu.GetPackageMenusAsync();
            return View(packageMenu);
        }



        public async Task<IActionResult> PackageMenuDetails(int id)
        {
            return PartialView("_PackageDetails", await _packageMenu.GetSinglePackageMenuAsync(id));
        }

        public async Task<IActionResult> PackageMenuDetailsViewOnly(int id)
        {
            return PartialView("_PackageDetailsViewOnly", await _packageMenu.GetSinglePackageMenuAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePackageMenu(PackageMenu package)
        { 
            await _packageMenu.UpdatePackageMenuAsync(package);
            return RedirectToAction("PackageView");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePackageMenu(int id)
        {
            if (await _reservation.PackageIsCurrentlyInUse(id) != null)
            {
                TempData["PackageIsInUse"] = true;
                return RedirectToAction("PackageView");
            }

            await _packageItems.DeletePackageItemAsync(id);
            await _packageMenu.DeletePackageMenuAsync(id);
            return RedirectToAction("PackageView");
        }
    }
}