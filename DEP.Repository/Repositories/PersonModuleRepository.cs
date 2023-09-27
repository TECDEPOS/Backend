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

        public async Task<PersonModule> DeletePersonModule(int id)
        {
            var personModule = await context.PersonModules
                .FirstOrDefaultAsync(x => x.PersonModuleId == id);

            if (personModule != null)
            {
                context.PersonModules.Remove(personModule);
                await context.SaveChangesAsync();
            }

            return personModule;
        }

        public async Task<List<PersonModule>> GetAllPersonModules()
        {
            var tempList = await context.PersonModules
                .Select(x => new
                {
                    x.PersonModuleId,
                    x.PersonId,
                    x.ModuleId,
                    x.StartDate,
                    x.EndDate,
                    x.Status,
                    x.ModuleType,
                    Person = new
                    {
                        x.Person.Name,
                        x.Person.Initials
                    },
                    Module = new
                    {
                        x.Module.Name,
                        x.Module.Description
                    }
                }).ToListAsync();

            var personModules = new List<PersonModule>();
            foreach (var item in tempList)
            {
                personModules.Add(new PersonModule()
                {
                    PersonModuleId = item.PersonModuleId,
                    PersonId = item.PersonId,
                    ModuleId = item.ModuleId,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    ModuleType = item.ModuleType,
                    Status = item.Status,
                    Person = new Person()
                    {
                        Name = item.Person.Name,
                        Initials = item.Person.Initials,
                    },
                    Module = new Module()
                    {
                        Name = item.Module.Name,
                        Description = item.Module.Description,
                    }
                });
            }

            return personModules;
        }

        public Task<PersonModule> GetPersonModule(int id)
        {
            var personModule = context.PersonModules.Include(x => x.Person).Include(x => x.Module)
                .FirstOrDefaultAsync(x => x.PersonModuleId == id);

            return personModule;
        }

        public async Task<List<PersonModule>> GetPersonModules(int personId, int moduleId)
        {
            var tempList = await context.PersonModules.Where(pm => pm.PersonId == personId && pm.ModuleId == moduleId)
                .Select(x => new
                {
                    x.PersonModuleId,
                    x.PersonId,
                    x.ModuleId,
                    x.StartDate,
                    x.EndDate,
                    x.Status,
                    x.ModuleType,
                    Person = new
                    {
                        x.Person.Name,
                        x.Person.Initials
                    },
                    Module = new
                    {
                        x.Module.Name,
                        x.Module.Description
                    }
                }).ToListAsync();

            var personModules = new List<PersonModule>();
            foreach (var item in tempList)
            {
                personModules.Add(new PersonModule()
                {
                    PersonModuleId = item.PersonModuleId,
                    PersonId = item.PersonId,
                    ModuleId = item.ModuleId,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    ModuleType = item.ModuleType,
                    Status = item.Status,
                    Person = new Person()
                    {
                        Name = item.Person.Name,
                        Initials = item.Person.Initials,
                    },
                    Module = new Module()
                    {
                        Name = item.Module.Name,
                        Description = item.Module.Description,
                    }
                });
            }

            return personModules;

            //var personModules = await context.PersonModules.Include(x => x.Person).Include(x => x.Module).Where(pm => pm.PersonId == personId && pm.ModuleId == moduleId).ToListAsync();
        }

        public async Task<List<PersonModule>> GetPersonModulesByPerson(int personId)
        {
            var tempList = await context.PersonModules.Where(pm => pm.PersonId == personId)
                .Select(x => new
                {
                    x.PersonModuleId,
                    x.PersonId,
                    x.ModuleId,
                    x.StartDate,
                    x.EndDate,
                    x.Status,
                    x.ModuleType,
                    Person = new
                    {
                        x.Person.Name,
                        x.Person.Initials
                    },
                    Module = new
                    {
                        x.Module.Name,
                        x.Module.Description
                    }
                }).ToListAsync();

            var personModules = new List<PersonModule>();
            foreach (var item in tempList)
            {
                personModules.Add(new PersonModule()
                {
                    PersonModuleId = item.PersonModuleId,
                    PersonId = item.PersonId,
                    ModuleId = item.ModuleId,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    ModuleType = item.ModuleType,
                    Status = item.Status,
                    Person = new Person()
                    {
                        Name = item.Person.Name,
                        Initials = item.Person.Initials,
                    },
                    Module = new Module()
                    {
                        Name = item.Module.Name,
                        Description = item.Module.Description,
                    }
                });
            }

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
