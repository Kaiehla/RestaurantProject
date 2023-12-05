namespace RestaurantProject.Models
{
    public class ReservationExtra
    {
        public Reservation Reservation { get; set; }
        public Customer Customer { get; set; }
        public PackageMenu PackageMenu { get; set; }
        public RestaurantTable RestaurantTable { get; set; }
    }
}
