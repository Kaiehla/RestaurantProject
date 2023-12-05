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
        public string ImageLink { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public int RecommendedNumber { get; set; }
    }
}
