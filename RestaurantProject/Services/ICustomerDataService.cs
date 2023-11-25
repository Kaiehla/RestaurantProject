using RestaurantProject.Models;

namespace RestaurantProject.Services
{
    public interface ICustomerDataService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetSingleCustomerAsync(int id);
        Task AddCustomerAsync(ReserveForm reserve);
        Task<List<Customer>> DeleteCustomerAsync(Customer customer);
        Task<List<Customer>> UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int customerId);
    }
}
