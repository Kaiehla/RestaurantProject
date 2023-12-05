using RestaurantProject.Data;
using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantProject.Services
{
    public class RestaurantTableDataService : IRestaurantTableDataService
    {
        private List<RestaurantTable> _restoTable;
        private AppDbContext _appDbContext;

        public RestaurantTableDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Gets the data of the Table table Asynchronously
        public async Task<List<RestaurantTable>> GetRestaurantTablesAsync()
        {
            var restoTables = await _appDbContext.RestaurantTable.ToListAsync();
            return restoTables;
        }

        public async Task<List<RestaurantTable>> AddRestaurantTableAsync(RestaurantTable table)
        {
            return null;
        }

        public async Task<RestaurantTable> DeleteRestaurantTableAsync(RestaurantTable table)
        {
            return null;
        }

        public async Task<List<RestaurantTable>> UpdateRestaurantTableAsync(RestaurantTable table)
        {
            return null;
        }


    }
}
