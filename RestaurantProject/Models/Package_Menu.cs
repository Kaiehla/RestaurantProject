using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantProject.Models
{
    [Table("Package_Menu")]
    public class Package_Menu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public int Status { get; set; }
    }
}
