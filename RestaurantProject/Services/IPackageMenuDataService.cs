﻿using RestaurantProject.Models;

namespace RestaurantProject.Services
{
    public interface IPackageMenuDataService
    {
        Task<List<PackageMenu>> GetPackageMenusAsync();
        Task<List<PackageMenu>> AddPackageMenuAsync(PackageMenu packageMenu);
        Task<List<PackageMenu>> UpdatePackageMenuAsync(PackageMenu packageMenu);
        Task<List<PackageMenu>> DeletePackageMenuAsync(PackageMenu packageMenu);
    }
}
