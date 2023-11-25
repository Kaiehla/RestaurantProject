using RestaurantProject.Data;
using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Controllers;

namespace RestaurantProject.Services
{
    public class CustomerDataService : ICustomerDataService
    {
        private AppDbContext _appDbContext;

        public CustomerDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _appDbContext.Customer.ToListAsync();
		}

        public async Task<Customer> GetSingleCustomerAsync(int id)
        {
            var singleCustomer = await _appDbContext.Customer.Where(x => x.Id == id).FirstAsync();
            return singleCustomer;
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

	public async Task DeleteCustomerAsync(int customerId)
	 {
		var customer = await _appDbContext.Customer.FindAsync(customerId);
	
	     if (customer != null)
	     {
	         _appDbContext.Customer.Remove(customer);
	         await _appDbContext.SaveChangesAsync();
	     }
	 }
    }
}
