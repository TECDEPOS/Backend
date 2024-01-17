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

        public async Task<Module> AddModule(Module module)
        {
            context.Modules.Add(module);
            await context.SaveChangesAsync();

            return module;
        }

        public async Task<Module> DeleteModule(int id)
        {
            var module = await context.Modules.FirstOrDefaultAsync(m => m.ModuleId == id);

            if (module != null)
            {
                context.Modules.Remove(module);
                await context.SaveChangesAsync();
            }

            return module;
        }

        public async Task<Module> GetModuleById(int id)
        {
            var module = await context.Modules
                .Include(m => m.Courses).
                ThenInclude(c => c.PersonCourses).
                ThenInclude(x => x.Person)
                .FirstOrDefaultAsync(m => m.ModuleId == id);

            return module;
        }

        public async Task<List<Module>> GetModules()
        {
            var modules = await context.Modules.ToListAsync();

            return modules;
        }

        //public async Task<List<Module>> GetModulesByType(int type)
        //{
        //    var modules = await context.Modules.Where(m => m.ModuleType == (ModuleType)type).ToListAsync();

        //    return modules;
        //}

        public async Task<Module> UpdateModule(Module module)
        {
            context.Entry(module).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return module;
        }
    }
}
