using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;

namespace DEP.Service.Services
{
    public class PersonModuleService : IPersonModuleService
    {
        private readonly IPersonModuleRepository repo;
        public PersonModuleService(IPersonModuleRepository repo) { this.repo = repo; }

        public async Task<List<PersonModule>> GetAllPersonModules()
        {
            return await repo.GetAllPersonModules();
        }

        public async Task<PersonModule> AddPersonModule(PersonModule personModule)
        {
            return await repo.AddPersonModule(personModule);
        }

        public async Task<PersonModule> DeletePersonModule(int id)
        {
            return await repo.DeletePersonModule(id);
        }

        public async Task<PersonModule> GetPersonModule(int id)
        {
            return await repo.GetPersonModule(id);
        }

        public async Task<List<PersonModule>> GetPersonModules(int personId, int moduleId)
        {
            return await repo.GetPersonModules(personId, moduleId);
        }

        public async Task<List<PersonModule>> GetPersonModulesByPerson(int personId)
        {
            return await repo.GetPersonModulesByPerson(personId);
        }

        public async Task<PersonModule> UpdatePersonModule(PersonModule personModule)
        {
            return await repo.UpdatePersonModule(personModule);
        }
    }
}
