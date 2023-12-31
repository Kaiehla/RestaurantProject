﻿using RestaurantProject.Models;

namespace RestaurantProject.Services
{
    public interface ICustomerDataService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetSingleCustomerAsync(int id);
        Task AddCustomerAsync(ReserveForm reserve);
        Task DeleteCustomerAsync(int customerId);
        Task UpdateCustomerAsync(Customer customer);
    }
}