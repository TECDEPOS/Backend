using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;

namespace DEP.Service.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository repo;
        public LocationService(ILocationRepository repo) { this.repo = repo; }

        public async Task<Location> AddLocation(Location location)
        {
            return await repo.AddLocation(location);
        }

        public async Task<Location> DeleteLocation(int id)
        {
            return await repo.DeleteLocation(id);
        }

        public async Task<List<Location>> GetLocations()
        {
            return await repo.GetLocations();
        }

        public async Task<Location> UpdateLocation(Location location)
        {
            return await repo.UpdateLocation(location);
        }
    }
}
