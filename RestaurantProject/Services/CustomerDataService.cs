using RestaurantProject.Data;
using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task AddCustomerAsync(Customer customer)
        {
            await _appDbContext.Customer.AddAsync(customer);
            await _appDbContext.SaveChangesAsync();
        }

	    public async Task DeleteCustomerAsync(int customerId)
	    {
            //Find the row in the customer table and Reservation table that has the given customerId
		    var customer = await _appDbContext.Customer.FindAsync(customerId);

            try
            {
                var reservation = await _appDbContext.Reservation.Where(x => x.CustomerId == customerId).FirstAsync();
	             if (customer != null)
	             {
                    //Remove the row starting from Reservation table to avoid an SQL error
                    _appDbContext.Reservation.Remove(reservation);
	                _appDbContext.Customer.Remove(customer);
	                 await _appDbContext.SaveChangesAsync();
	             }
            }
            catch (InvalidOperationException)
            {
                if (customer != null)
                {
                    _appDbContext.Customer.Remove(customer);
                    await _appDbContext.SaveChangesAsync();
                }
            }
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
    }
}
