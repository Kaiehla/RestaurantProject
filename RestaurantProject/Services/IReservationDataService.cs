using RestaurantProject.Data;
using RestaurantProject.Models;

namespace RestaurantProject.Services
{
    //an Interface has a collection of undefined methods that must be defined in the class that inherits it (ReservationDataServices)
    public interface IReservationDataService
    {
        Task<List<ReservationExtra>> GetReservationsAsync();
        Task AddReservationAsync(Reservation reservation);
        Task<Reservation> DeleteReservationAsync(int id);
        Task<List<Reservation>> UpdateReservationAsync(Reservation reservation);
        Task<Reservation> PackageIsCurrentlyInUse(int id);
        Task<Reservation> TableIsCurrentlyInUse(int id);
    }
}
