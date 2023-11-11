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

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("RestoTable")]
        public int TablesId { get; set; }
        public virtual RestoTable RestoTable { get; set; }

        [ForeignKey("Package_Menu")]
        public int PackageId { get; set; }
        public virtual Package_Menu Package_Menu { get; set; }

        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
        public int NumOfGuest { get; set; }
        public int Status { get; set; }
    }
}