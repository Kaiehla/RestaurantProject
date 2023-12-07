using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Data;
using RestaurantProject.Models;
using RestaurantProject.Services;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RestaurantProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICustomerDataService _customer;
        private IPackageMenuDataService _packageMenu;
        private IReservationDataService _reservation;
        private IRestaurantTableDataService _restaurantTable;

        public HomeController(ILogger<HomeController> logger, ICustomerDataService customer, IPackageMenuDataService packageMenu, IReservationDataService reservation, IRestaurantTableDataService restaurantTable)
        {
            _logger = logger;
            _customer = customer;
            _packageMenu = packageMenu;
            _restaurantTable = restaurantTable;
            _reservation = reservation;
        }

        public async Task<IActionResult> Index()
        {
            var menuAndDetails = await _packageMenu.GetMenuAndDetailsAsync();
            return View(menuAndDetails);
        }

        [HttpGet]
        public async Task<IActionResult> BookForm(string packageName, decimal price)
        {
            var reserveForm = new ReserveForm();

            reserveForm.PackageNames = await _packageMenu.GetPackagesAsync();
            reserveForm.Prices = await _packageMenu.GetPricesAsync();
            reserveForm.PackageIds = await _packageMenu.GetIdsAsync();

            return View(reserveForm);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReservation(ReserveForm reserveForm)
        {
            //If there are no free tables, redirect to BookForm.cshtml and notify user
            if(await _restaurantTable.FreeTableExistsAsync() == null)
            {
                TempData["NoFreeTables"] = true;
                return RedirectToAction("BookForm");
            }

            //Select a table that is free and has enough seating capacity
            var freeTable = await _restaurantTable.GetFreeRestaurantTableAsync(reserveForm.NumOfGuest);

            //Check if there is a free table that matches the requirements (Free and has enough capacity for the number of guests)
            if(freeTable != null)
            {
                //Update the availability of the table and get its Id
                var tableId = freeTable.Id;
                freeTable.Availability = "Assigned";
                await _restaurantTable.UpdateRestaurantTableAsync(freeTable);

                //Create a customer entry using information from reserveForm
                var entryCustomer = new Customer
                {
                    FirstName = reserveForm.FirstName,
                    LastName = reserveForm.LastName,
                    Email = reserveForm.Email,
                    PhoneNumber = reserveForm.PhoneNumber,
                    CityAdd = reserveForm.CityAdd
                };

                await _customer.AddCustomerAsync(entryCustomer);
            

                //Create a reservation entry using information from reserveForm
                var entryReservation = new Reservation
                {
                    CustomerId = entryCustomer.Id,
                    TableId = tableId,
                    PackageId = reserveForm.PackageId,
                    ReservationDate = reserveForm.ReservationDate,
                    ReservationTime = reserveForm.ReservationTime.ToTimeSpan(),
                    NumOfGuest = reserveForm.NumOfGuest,
                    Status = 1
                };

                //Add reservation to table
                await _reservation.AddReservationAsync(entryReservation);
            
                return RedirectToAction("ConfirmBook");
            }
            else
            {
                TempData["NoTablesAvailableError"] = true;


                return RedirectToAction("BookForm", new { numOfGuest = reserveForm.NumOfGuest });
            }
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
