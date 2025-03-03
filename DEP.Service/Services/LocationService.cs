﻿using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;

namespace DEP.Service.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository repo;
        public LocationService(ILocationRepository repo) { this.repo = repo; }

        public async Task<bool> AddLocation(Location location)
        {
            return await repo.AddLocation(location);
        }

        public async Task<bool> DeleteLocation(int id)
        {
            return await repo.DeleteLocation(id);
        }

        public async Task<List<Location>> GetLocations()
        {
            return await repo.GetLocations();
        }

        public async Task<Location> GetLocationById(int id)
        {
            return await repo.GetLocationById(id);
        }

        public async Task<Location> GetLocationByName(string name)
        {
            return await repo.GetLocationByName(name);
        }

        public async Task<bool> UpdateLocation(Location location)
        {
            return await repo.UpdateLocation(location);
        }
    }
}
