using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RestaurantProject.Models
{
    public class ReserveForm
    {
        //Lists for generating dropdown
        public List<string> PackageNames { get; set; }
        public List<decimal> Prices { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeOnly ReservationTime {  get; set; }
        [Required]
        public string PackageName { get; set; }
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
        [Required]
        public decimal Price { get; set; }
    }
}
