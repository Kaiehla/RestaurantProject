using RestaurantProject.Models;

namespace RestaurantProject.Services
{
    public interface ICustomerDataService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<List<Customer>> AddCustomerAsync(Customer customer);
        Task<List<Customer>> DeleteCustomerAsync(Customer customer);
        Task<List<Customer>> UpdateCustomerAsync(Customer customer);
    }
}
