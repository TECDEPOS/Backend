using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetLocations();
        Task<Location> GetLocationById(int id);
        Task<Location> GetLocationByName(string name);
        Task<bool> DeleteLocation(int id);
        Task<bool> AddLocation(Location location);
        Task<bool> UpdateLocation(Location location);
    }
}
