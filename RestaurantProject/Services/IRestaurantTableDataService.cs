using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantProject.Data;
using RestaurantProject.Models;

namespace RestaurantProject.Services
{
    public interface IRestaurantTableDataService
    {
        Task<List<RestaurantTable>> GetRestaurantTablesAsync();
        Task<List<RestaurantTable>> AddRestaurantTableAsync(RestaurantTable table); //Di kailangan since hindi pwede mag add ng table by itself?
        Task DeleteRestaurantTableAsync(int id);
        Task UpdateRestaurantTableAsync(RestaurantTable table);
        Task<RestaurantTable> GetFreeRestaurantTableAsync(int numOfGuest);
        Task<RestaurantTable> FreeTableExistsAsync();
        Task<RestaurantTable> GetSingleTableAsync(int id);
    }
}
