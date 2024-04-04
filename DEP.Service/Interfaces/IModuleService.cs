using DEP.Repository.Models;
using DEP.Service.ViewModels;

namespace DEP.Service.Interfaces
{
    public interface IModuleService
    {
        Task<List<Module>> GetModules();
        Task<List<ModuleExcelViewModel>> GetModulesExcel();
        Task<Module> AddModule(Module module);
        Task<Module> UpdateModule(Module module);
        Task<Module> DeleteModule(int id);
    }
}
