using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Models;
using RestaurantProject.Services;

namespace RestaurantProject.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerDataService _customers;
        //private CustomerDetailsModel _customerDetails;

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

        public async Task<IActionResult> CustomerDetails(int id)
        {
            return PartialView("_CustomerDetails", await _customers.GetSingleCustomerAsync(id));
        }

        public async Task<IActionResult> CustomerDetailsViewOnly(int id)
        {
            return PartialView("_CustomerDetailsViewOnly", await _customers.GetSingleCustomerAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(Customer customer)
        {
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var customers = await _customers.GetCustomersAsync();
            var customer = customers.Where(x => x.Id == id).FirstOrDefault();
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            await _customers.UpdateCustomerAsync(customer);
            return RedirectToAction("CustomerView");
        }
    }
}