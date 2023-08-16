using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;

namespace DEP.Service.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository repo;
        public ModuleService(IModuleRepository repo) {  this.repo = repo; }

        public async Task<Module> AddModule(Module module)
        {
            return await repo.AddModule(module);
        }

        public async Task<Module> DeleteModule(int id)
        {
            return await repo.DeleteModule(id);
        }

        public async Task<Module> GetModuleById(int id)
        {
            return await repo.GetModuleById(id);
        }

        public async Task<List<Module>> GetModules()
        {
            return await repo.GetModules();
        }

        public async Task<List<Module>> GetModulesByType(int type)
        {
            return await repo.GetModulesByType(type);
        }

        public async Task<Module> UpdateModule(Module module)
        {
            return await repo.UpdateModule(module);
        }
    }
}
