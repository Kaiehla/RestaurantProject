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
            var entryCustomer = new Customer
            {
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                Email = reservation.Email,
                PhoneNumber = reservation.PhoneNumber,
                CityAdd = reservation.CityAdd
            };

            await _appDbContext.Customer.AddAsync(entryCustomer);
            await _appDbContext.SaveChangesAsync();

            //var entryReservation = new Reservation
            //{
            //    CustomerId = entryCustomer.Id,

            //    PackageId = reservation.PackageId,


        

	    public async Task DeleteCustomerAsync(int customerId)
	     {
            //Find the row in the customer table and Reservation table that has the given customerId
		    var customer = await _appDbContext.Customer.FindAsync(customerId);
            var reservation = await _appDbContext.Reservation.Where(x => x.CustomerId == customerId).FirstAsync();
	
	         if (customer != null)
	         {
                //Remove the row starting from Reservation table to avoid an SQL error
                _appDbContext.Reservation.Remove(reservation);
	            _appDbContext.Customer.Remove(customer);
	             await _appDbContext.SaveChangesAsync();
	         }
	     }
    }
}
