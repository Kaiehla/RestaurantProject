namespace RestaurantProject.Models
{
    public class ReservationExtra
    {
        //public Reservation Reservation { get; set; }
        //public Customer Customer { get; set; }
        //public PackageMenu PackageMenu { get; set; }
        //public RestaurantTable RestaurantTable { get; set; }

        public string TableName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PackageName { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
        public string PhoneNumber { get; set; }
        public string NumOfGuest { get; set; }

    }
}
