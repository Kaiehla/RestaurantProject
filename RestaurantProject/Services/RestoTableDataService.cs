using RestaurantProject.Data;
using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantProject.Services
{
    public class RestoTableDataService : IRestoTableDataService
    {
        private List<RestoTable> _restoTable;
        private AppDbContext _appDbContext;

        public RestoTableDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Gets the data of the Table table Asynchronously
        public async Task<List<RestoTable>> GetRestoTablesAsync()
        {
            var restoTables = await _appDbContext.RestoTable.ToListAsync();
            return restoTables;
        }

        public async Task<List<RestoTable>> AddRestoTableAsync(RestoTable table)
        {
            return null;
        }

        public async Task<RestoTable> DeleteRestoTableAsync(RestoTable table)
        {
            return null;
        }

        public async Task<List<RestoTable>> UpdateRestoTableAsync(RestoTable table)
        {
            return null;
        }


    }
}
