using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocations();
        Task<Location> DeleteLocation(int id);
        Task<Location> AddLocation(Location location);
        Task<Location> UpdateLocation(Location location);
    }
}
