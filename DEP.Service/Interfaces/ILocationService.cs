using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocations();
        Task<Location> GetLocationById(int id);
        Task<Location> GetLocationByName(string name);
        Task<bool> DeleteLocation(int id);
        Task<bool> AddLocation(Location location);
        Task<bool> UpdateLocation(Location location);
    }
}
