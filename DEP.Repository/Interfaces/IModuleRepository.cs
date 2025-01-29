using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface IModuleRepository
    {
        Task<List<Module>> GetModules();
        Task<bool> AddModule(Module module);
        Task<Module> UpdateModule(Module module);
        Task<Module> DeleteModule(int id);
    }
}
