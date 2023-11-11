using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantProject.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Package_Menu> Package_Menu { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<RestoTable> RestoTable { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
