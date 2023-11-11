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
            var packageMenus = await _appDbContext.Package_Menu.ToListAsync();
            var restoTables = await _appDbContext.RestoTable.ToListAsync();

            foreach (var reservation in reservations)
            {
                var customer = customers.Where(x => x.Id == reservation.CustomerId).FirstOrDefault();
                var packageMenu = packageMenus.Where(x => x.Id == reservation.PackageId).FirstOrDefault();
                var restoTable = restoTables.Where(x => x.Id == reservation.TablesId).FirstOrDefault();

                reservationsExtra.Add(new ReservationExtra
                {
                    Reservation = reservation,
                    Customer = customer,
                    Package_Menu = packageMenu,
                    RestoTable = restoTable
                });
            }

            return reservationsExtra;
        }

        public async Task<List<Reservation>> AddReservationAsync(Reservation model)
        {
            await _appDbContext.Reservation.AddAsync(model);
            await _appDbContext.SaveChangesAsync();

            //di ako sure
            return null;
        }

        public async Task<Reservation> DeleteReservationAsync(Reservation model)
        {
            var reservation  = await _appDbContext.Reservation.FindAsync(model.ReserveId);

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








    }
}
