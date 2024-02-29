using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface IModuleService
    {
        Task<List<Module>> GetModules();
        Task<Module> AddModule(Module module);
        Task<Module> UpdateModule(Module module);
        Task<Module> DeleteModule(int id);
    }
}
