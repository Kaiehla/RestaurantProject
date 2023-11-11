using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Models;
using RestaurantProject.Services;

namespace RestaurantProject.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerDataService _customers;

        //Controller
        public CustomerController(ICustomerDataService customer)
        {
            _customers = customer;
        }

        //Get Customer Table contents
        public async Task<IActionResult> CustomerView()
        {
            var customers = await _customers.GetCustomersAsync();
            return View(customers);
        }
    }
}
