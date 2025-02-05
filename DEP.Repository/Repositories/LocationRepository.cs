using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DatabaseContext context;
        public LocationRepository(DatabaseContext context) { this.context = context; }

        public async Task<bool> AddLocation(Location location)
        {
            context.Locations.Add(location);
            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteLocation(int id)
        {
            var location = await context.Locations.FindAsync(id);

            if (location == null)
            {
                return false;
            }

            context.Locations.Remove(location);
            return await context.SaveChangesAsync() > 0;
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

        public async Task<bool> UpdateLocation(Location location)
        {
            context.Entry(location).State = EntityState.Modified;
            var result = await context.SaveChangesAsync();

            return result > 0;
        }
    }
}
