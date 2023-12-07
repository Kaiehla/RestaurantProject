using RestaurantProject.Data;
using RestaurantProject.Models;

namespace RestaurantProject.Services
{
    //an Interface has a collection of undefined methods that must be defined in the class that inherits it (ReservationDataServices)
    public interface IReservationDataService
    {
        Task<List<ReservationExtra>> GetReservationsAsync();
        Task AddReservationAsync(Reservation reservation);
        Task<Reservation> DeleteReservationAsync(Reservation model);
        Task<List<Reservation>> UpdateReservationAsync(Reservation reservation);
    }
}
