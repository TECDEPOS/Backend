using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class PersonModuleRepository : IPersonModuleRepository
    {
        private readonly DatabaseContext context;
        public PersonModuleRepository(DatabaseContext context) { this.context = context; }

        public async Task<PersonModule> AddPersonModule(PersonModule personModule)
        {
            context.PersonModules.Add(personModule);
            await context.SaveChangesAsync();

            return personModule;
        }

        public async Task<PersonModule> DeletePersonModule(int personId, int moduleId, DateTime date)
        {
            var personModule = await context.PersonModules
                .FirstOrDefaultAsync(pm => pm.PersonId == personId && pm.ModuleId == moduleId && pm.StartDate == date);
            
            if (personModule != null)
            {
                context.PersonModules.Remove(personModule);
                await context.SaveChangesAsync();
            }

            return personModule;
        }

        public Task<PersonModule> GetPersonModule(int personId, int moduleId, DateTime date)
        {
            var personModule = context.PersonModules
                .FirstOrDefaultAsync(pm => pm.PersonId == personId && pm.ModuleId == moduleId && pm.StartDate == date);

            return personModule;
        }

        public async Task<List<PersonModule>> GetPersonModules(int personId, int moduleId)
        {
            var personModules = await context.PersonModules.Where(pm => pm.PersonId == personId && pm.ModuleId == moduleId).ToListAsync();

            return personModules;
        }

        public async Task<PersonModule> UpdatePersonModule(PersonModule personModule)
        {
            context.Entry(personModule).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return personModule;
        }
    }
}
