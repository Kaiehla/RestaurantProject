using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Models;
using System.Diagnostics;

namespace RestaurantProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //updated
        public IActionResult BookForm()
        {
            return View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
