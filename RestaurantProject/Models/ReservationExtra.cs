namespace RestaurantProject.Models
{
    public class ReservationExtra
    {
        public Reservation Reservation { get; set; }
        public Customer Customer { get; set; }
        public Package_Menu Package_Menu { get; set; }
        public RestoTable RestoTable { get; set; }
    }
}
