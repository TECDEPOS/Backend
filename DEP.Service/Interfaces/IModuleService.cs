using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface IModuleService
    {
        Task<Module> GetModuleById(int id);
        Task<List<Module>> GetModules();
        //Task<List<Module>> GetModulesByType(int type);
        Task<Module> AddModule(Module module);
        Task<Module> UpdateModule(Module module);
        Task<Module> DeleteModule(int id);
    }
}
