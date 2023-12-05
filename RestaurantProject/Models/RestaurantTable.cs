using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantProject.Models
{
    [Table("RestaurantTable")]
    public class RestaurantTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string TableName { get; set; }
        public int SeatingCapacity { get; set; }
        public string Availability {  get; set; }
        
    }
}
