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
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("RestaurantTable")]
        public int TablesId { get; set; }
        public virtual RestaurantTable RestaurantTable { get; set; }

        [ForeignKey("PackageMenu")]
        public int PackageId { get; set; }
        public virtual PackageMenu PackageMenu { get; set; }

        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
        public int NumOfGuest { get; set; }
        public int Status { get; set; }
    }
}