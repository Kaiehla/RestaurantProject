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

        public async Task AddCustomerAsync(ReserveForm reservation)
        {
            var entry = new Customer
            {
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                Email = reservation.Email,
                PhoneNumber = reservation.PhoneNumber,
                CityAdd = reservation.CityAdd
            };

            await _appDbContext.Customer.AddAsync(entry);
            await _appDbContext.SaveChangesAsync();
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
