using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly DatabaseContext context;
        public ModuleRepository(DatabaseContext context) { this.context = context; }

        public async Task<bool> AddModule(Module module)
        {
            context.Modules.Add(module);
            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteModule(int id)
        {
            var module = await context.Modules.FindAsync(id);

            if (module is null)
            {
                return false;
            }

            context.Modules.Remove(module);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Module>> GetModules()
        {
            var modules = await context.Modules.Include(m => m.Books).ToListAsync();
            return modules;
        }

        //public async Task<List<Module>> GetModulesByType(int type)
        //{
        //    var modules = await context.Modules.Where(m => m.ModuleType == (ModuleType)type).ToListAsync();

        //    return modules;
        //}

        public async Task<bool> UpdateModule(Module module)
        {
            context.Entry(module).State = EntityState.Modified;
            var result = await context.SaveChangesAsync();

            return result > 0;
        }
    }
}
