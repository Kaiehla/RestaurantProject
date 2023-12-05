using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Models;
using RestaurantProject.Services;

namespace RestaurantProject.Controllers
{
    public class TableController : Controller
    {
        private IRestaurantTableDataService _restoTable;

        public TableController(IRestaurantTableDataService restoTable)
        {
            _restoTable = restoTable;
        }

        public async Task<IActionResult> TableView()
        {
            var restoTables = await _restoTable.GetRestaurantTablesAsync();
            return View(restoTables);
        }
    }
}
