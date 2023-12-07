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

        public async Task<RestaurantTable> GetFreeRestaurantTableAsync(int numOfGuest)
        {
            return await _appDbContext.RestaurantTable.Where(x => x.Availability == "Free").Where(x => x.SeatingCapacity >= numOfGuest).FirstOrDefaultAsync();
        }

        public async Task<RestaurantTable> FreeTableExistsAsync()
        {
            return await _appDbContext.RestaurantTable.Where(x => x.Availability == "Free").FirstOrDefaultAsync();
        }

        public async Task<List<RestaurantTable>> AddRestaurantTableAsync(RestaurantTable table)
        {
            return null;
        }

        public async Task<RestaurantTable> DeleteRestaurantTableAsync(RestaurantTable table)
        {
            return null;
        }

        public async Task UpdateRestaurantTableAsync(RestaurantTable table)
        {
            var selectedTable = await _appDbContext.RestaurantTable.Where(x => x.Id == table.Id).FirstOrDefaultAsync();

            if (selectedTable != null)
            {
                selectedTable.TableName = table.TableName;
                selectedTable.SeatingCapacity = table.SeatingCapacity;
                selectedTable.Availability = table.Availability;

                await _appDbContext.SaveChangesAsync();
            }
        }


    }
}
