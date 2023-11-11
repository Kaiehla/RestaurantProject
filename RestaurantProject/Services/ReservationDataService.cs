using RestaurantProject.Data;
using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.Services
{
    //The ReservationDataService class inherits the IReservationDataService class and must define all the methods listed within the IReservationDataService class
    public class ReservationDataService : IReservationDataService
    {
        //List that will contain all the information about the Reservation table (ReserveId, CustomerId, TablesId, etc.)
        private List<Reservation> _reservation;
        //AppdbContext contains information about the database (Table names)
        private AppDbContext _appDbContext;

        //Constructor
        public ReservationDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Gets the data of the Reservation table Asynchronously
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

        //Add data to Reservation table Asynchronously
        //The data must be within a list, and that list must be turned into a Task
        public async Task<List<Reservation>> AddReservationAsync(Reservation model)
        {
            await _appDbContext.Reservation.AddAsync(model);
            //It is important to save the changes or else it will not reflect on the database
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
