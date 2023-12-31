﻿using RestaurantProject.Data;
using RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.Services
{
    public class PackageMenuDataService : IPackageMenuDataService
    {
        private List<PackageMenu> _packageMenu;
        private AppDbContext _appDbContext;

        public PackageMenuDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<PackageMenu>> GetPackageMenusAsync()
        {
            var packageMenu = await _appDbContext.PackageMenu.ToListAsync();
            return packageMenu;
        }

        public async Task<List<PackageMenu>> AddPackageMenuAsync(PackageMenu model)
        {
            await _appDbContext.PackageMenu.AddAsync(model);
            await _appDbContext.SaveChangesAsync();

            return null;
        }

        public async Task<List<PackageMenu>> UpdatePackageMenuAsync(PackageMenu model)
        {
            return null;
        }

        public async Task<List<PackageMenu>> DeletePackageMenuAsync(PackageMenu model)
        {
            return null;
        }

    }
}