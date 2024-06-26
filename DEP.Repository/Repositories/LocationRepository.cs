﻿using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DatabaseContext context;
        public LocationRepository(DatabaseContext context) { this.context = context; }

        public async Task<Location> AddLocation(Location location)
        {
            context.Locations.Add(location);
            await context.SaveChangesAsync();

            return location;
        }

        public async Task<Location> DeleteLocation(int id)
        {
            var location = await context.Locations.FirstOrDefaultAsync(l => l.LocationId == id);

            if (location != null)
            {
                context.Locations.Remove(location);
                await context.SaveChangesAsync();
            }

            return location;
        }

        public async Task<List<Location>> GetLocations()
        {
            var locations = await context.Locations.ToListAsync();

            return locations;
        }

        public async Task<Location> GetLocationById(int id)
        {
            var location = await context.Locations.FindAsync(id);

            return location;
        }

        public async Task<Location> GetLocationByName(string name)
        {
            var location = await context.Locations.FirstOrDefaultAsync(x => x.Name.Contains(name.ToLower()));

            return location;
        }

        public async Task<Location> UpdateLocation(Location location)
        {
            context.Entry(location).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return location;
        }
    }
}
