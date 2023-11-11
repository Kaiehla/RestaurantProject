using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantProject.Models
{
    [Table("RestoTable")]
    public class RestoTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string TableName { get; set; }
        public int SeatingCapacity { get; set; }
        public string Availability {  get; set; }
        
    }
}
