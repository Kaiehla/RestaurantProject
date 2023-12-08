using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Models;
using RestaurantProject.Services;

namespace RestaurantProject.Controllers
{
    public class TableController : Controller
    {
        private IRestaurantTableDataService _restoTable;
        private IReservationDataService _reservation;

        public TableController(IRestaurantTableDataService restoTable, IReservationDataService reservation)
        {
            _restoTable = restoTable;
            _reservation = reservation;
        }

        public async Task<IActionResult> TableView()
        {
            var restoTables = await _restoTable.GetRestaurantTablesAsync();
            return View(restoTables);
        }

        public async Task<IActionResult> TableDetails(int id)
        {
           return PartialView("_TableViewDetails",await _restoTable.GetSingleTableAsync(id));
        }

        public async Task<IActionResult> TableDetailsViewOnly(int id)
        {
            return PartialView("_TableViewDetailsViewOnly", await _restoTable.GetSingleTableAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTable(RestaurantTable table)
        {
            await _restoTable.UpdateRestaurantTableAsync(table);
            return RedirectToAction("TableView");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var reservation = await _reservation.TableIsCurrentlyInUse(id);
            if (reservation != null)
            {
                TempData["TableIsInUse"] = true;
                return RedirectToAction("TableView");
            }

            var reservationId = reservation.Id;
            
            await _reservation.DeleteReservationAsync(reservationId);
            await _restoTable.DeleteRestaurantTableAsync(id);
            return RedirectToAction("TableView");
        }
    }

}
