using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantProject.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int ReserveId { get; set; }

        public int CustomerId { get; set; }
        public int TablesId { get; set; }
        public int PackageId { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
        public int NumOfGuest { get; set; }
        public int Status { get; set; }
    }
}