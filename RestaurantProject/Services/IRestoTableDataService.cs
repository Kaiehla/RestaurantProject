using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantProject.Models;

namespace RestaurantProject.Services
{
    public interface IRestoTableDataService
    {
        Task<List<RestoTable>> GetRestoTablesAsync();
        Task<List<RestoTable>> AddRestoTableAsync(RestoTable table); //Di kailangan since hindi pwede mag add ng table by itself?
        Task<RestoTable> DeleteRestoTableAsync(RestoTable table);
        Task<List<RestoTable>> UpdateRestoTableAsync(RestoTable table);
    }
}
