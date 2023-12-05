namespace RestaurantProject.Models
{
    public class PackageFullDetails
    {
        public int PackageMenuId { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription { get; set; }
        public string PackageItem { get ; set; }
        public string ImageLink { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public int RecommendedNumber { get; set; }
    }
}
