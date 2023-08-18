using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;

namespace DEP.Service.Services
{
    public class PersonModuleService : IPersonModuleService
    {
        private readonly IPersonModuleRepository repo;
        public PersonModuleService(IPersonModuleRepository repo) { this.repo = repo; }

        public async Task<PersonModule> AddPersonModule(PersonModule personModule)
        {
            return await repo.AddPersonModule(personModule);
        }

        public async Task<PersonModule> DeletePersonModule(int personId, int moduleId, DateTime date)
        {
            return await repo.DeletePersonModule(personId, moduleId, date);
        }

        public async Task<PersonModule> GetPersonModule(int personId, int moduleId, DateTime date)
        {
            return await repo.GetPersonModule(personId,moduleId, date);
        }

        public async Task<List<PersonModule>> GetPersonModules(int personId, int moduleId)
        {
            return await repo.GetPersonModules(personId, moduleId);
        }

        public async Task<PersonModule> UpdatePersonModule(PersonModule personModule)
        {
            return await repo.UpdatePersonModule(personModule);
        }
    }
}
