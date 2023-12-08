using RestaurantProject.Data;
using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Razor;
using System;

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

        public async Task DeleteRestaurantTableAsync(int id)
        {
            var table = await _appDbContext.RestaurantTable.FindAsync(id);
            _appDbContext.RestaurantTable.Remove(table);
            await _appDbContext.SaveChangesAsync();
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

        public async Task<RestaurantTable> GetSingleTableAsync(int id)
        {
            var singleTable = await _appDbContext.RestaurantTable.Where(x => x.Id == id).FirstOrDefaultAsync();
            return singleTable;

        }

        

    }
}
