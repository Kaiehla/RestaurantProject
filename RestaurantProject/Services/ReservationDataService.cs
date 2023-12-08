using RestaurantProject.Data;
using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.Services
{
    public class ReservationDataService : IReservationDataService
    {
        private List<Reservation> _reservation;
        private AppDbContext _appDbContext;

        public ReservationDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<ReservationExtra>> GetReservationsAsync()
        {
            var reservationsExtra = new List<ReservationExtra>();
            var reservations = await _appDbContext.Reservation.ToListAsync();
            var customers = await _appDbContext.Customer.ToListAsync();
            var packageMenus = await _appDbContext.PackageMenu.ToListAsync();
            var restaurantTables = await _appDbContext.RestaurantTable.ToListAsync();

            foreach (var reservation in reservations)
            {
                var customer = customers.Where(x => x.Id == reservation.CustomerId).FirstOrDefault();
                var packageMenu = packageMenus.Where(x => x.Id == reservation.PackageId).FirstOrDefault();
                var restaurantTable = restaurantTables.Where(x => x.Id == reservation.TableId).FirstOrDefault();

                reservationsExtra.Add(new ReservationExtra
                {
                    Reservation = reservation,
                    Customer = customer,
                    PackageMenu = packageMenu,
                    RestaurantTable = restaurantTable
                });
            }

            return reservationsExtra;
        }

        public async Task AddReservationAsync(Reservation model)
        {
            await _appDbContext.Reservation.AddAsync(model);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Reservation> DeleteReservationAsync(int id)
        {
            var reservation  = await _appDbContext.Reservation.FindAsync(id);

            if (reservation != null)
            {
                _appDbContext.Reservation.Remove(reservation);
                await _appDbContext.SaveChangesAsync();
            }

            return reservation;
        }

        public async Task<List<Reservation>> UpdateReservationAsync(Reservation reservation)
        {
            //await _appDbContext.Reservation.ExecuteUpdateAsync(reservation);
            //await _appDbContext.SaveChangesAsync();

            return null;
        }
        public async Task<Reservation> PackageIsCurrentlyInUse(int id)
        {
            return await _appDbContext.Reservation.Where(x => x.PackageId == id).FirstOrDefaultAsync();
        }

        public async Task<Reservation> TableIsCurrentlyInUse(int id)
        {
            return await _appDbContext.Reservation.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

    }
}
