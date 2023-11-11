using RestaurantProject.Data;
using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.Services
{
    public class CustomerDataService : ICustomerDataService
    {
        private List<Customer> _cusotmer;
        private AppDbContext _appDbContext;

        public CustomerDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var customers = await _appDbContext.Customer.ToListAsync();
            return customers;
        }

        public async Task<List<Customer>> AddCustomerAsync(Customer customer)
        {
            return null;
        }

        public async Task<List<Customer>> DeleteCustomerAsync(Customer customer)
        {
            return null;
        }

        public async Task<List<Customer>> UpdateCustomerAsync(Customer customer)
        {
            return null;
        }
    }
}
