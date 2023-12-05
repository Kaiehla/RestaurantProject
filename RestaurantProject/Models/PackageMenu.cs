using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantProject.Models
{
    [Table("PackageMenu")]
    public class PackageMenu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int Id { get; set; }

        public string PackageName { get; set; }
        public string PackageDescription { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
