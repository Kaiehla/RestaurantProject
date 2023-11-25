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

        public async Task UpdateCustomerAsync(Customer customer)
        {
            var selectedCustomer = await _appDbContext.Customer.Where(x => x.Id == customer.Id).FirstOrDefaultAsync();

            if (selectedCustomer != null)
            {
                selectedCustomer.FirstName = customer.FirstName;
                selectedCustomer.LastName = customer.LastName;
                selectedCustomer.PhoneNumber = customer.PhoneNumber;
                selectedCustomer.Email = customer.Email;
                selectedCustomer.CityAdd = customer.CityAdd;

                await _appDbContext.SaveChangesAsync();
            }
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
