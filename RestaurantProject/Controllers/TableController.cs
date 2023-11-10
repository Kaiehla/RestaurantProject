using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Models;
using RestaurantProject.Services;

namespace RestaurantProject.Controllers
{
    public class TableController : Controller
    {
        private IRestoTableDataService _restoTable;

        public TableController(IRestoTableDataService restoTable)
        {
            _restoTable = restoTable;
        }

        public async Task<IActionResult> TableView()
        {
            var restoTables = await _restoTable.GetRestoTablesAsync();
            return View(restoTables);
        }
    }
}
