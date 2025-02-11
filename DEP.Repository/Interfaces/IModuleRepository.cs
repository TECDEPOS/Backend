using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface IModuleRepository
    {
        Task<List<Module>> GetModules();
        Task<bool> AddModule(Module module);
        Task<bool> UpdateModule(Module module);
        Task<bool> DeleteModule(int id);
    }
}
