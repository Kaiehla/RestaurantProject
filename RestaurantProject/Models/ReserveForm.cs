using System.ComponentModel.DataAnnotations;

namespace RestaurantProject.Models
{
    public class ReserveForm
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeOnly ReservationTime {  get; set; }
        [Required]
        public int PackageId { get; set; }
        [Required]
        public int NumOfGuest { get; set; }
        [Required]
        public string FirstName {  get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CityAdd{ get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
