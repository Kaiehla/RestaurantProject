using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantProject.Models
{
    [Table("PackageItems")]
    public class PackageItems
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [ForeignKey("PackageMenu")]
        public int PackageId { get; set; }
        public virtual PackageMenu PackageMenu { get; set; }

        public string Item { get; set; }

    }
}
