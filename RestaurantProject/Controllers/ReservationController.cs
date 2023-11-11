using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Models;
using RestaurantProject.Services;

namespace RestaurantProject.Controllers
{
    public class ReservationController : Controller
    {
        private IReservationDataService _reservations;

        public ReservationController(IReservationDataService reservation)
        {
            _reservations = reservation;
        }
        //Get Reservation Table contents
        public async Task<IActionResult> ReserveView()
        {
            var reservations = await _reservations.GetReservationsAsync();
            return View(reservations);
        }

        public async Task<IActionResult> Delete(Reservation model)
        {
            var reservation = await _reservations.DeleteReservationAsync(model);

            return RedirectToAction("ReserveView");
        }


    }
}
