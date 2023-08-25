using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetLocations();
        Task<Location> GetLocationById(int id);
        Task<Location> GetLocationByName(string name);
        Task<Location> DeleteLocation(int id);
        Task<Location> AddLocation(Location location);
        Task<Location> UpdateLocation(Location location);
    }
}
