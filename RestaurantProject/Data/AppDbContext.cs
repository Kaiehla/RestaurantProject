using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantProject.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<PackageMenu> PackageMenu { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<RestaurantTable> RestaurantTable { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
