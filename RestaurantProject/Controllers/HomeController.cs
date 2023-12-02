using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Models;
using RestaurantProject.Services;
using System.Diagnostics;

namespace RestaurantProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICustomerDataService _customer;

        public HomeController(ILogger<HomeController> logger, ICustomerDataService customer)
        {
            _logger = logger;
            _customer = customer;
        }

        public IActionResult Index()
        {
            return View();
        }
        //updated

        [HttpGet]
        public IActionResult BookForm(String packageId)
        {
            ViewData["packageId"] = packageId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReservation(ReserveForm reservation)
        {
            await _customer.AddCustomerAsync(reservation);

            return RedirectToAction("BookForm");
        }

        public IActionResult CustomerView()
        {
            return View();
        }

        //public IActionResult ReserveView()
        //{
        //    return View();
        //}

        public IActionResult TableView()
        {
            return View();
        }

        public IActionResult PackageView()
        {
            return View();
        }

        public IActionResult ConfirmBook()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
