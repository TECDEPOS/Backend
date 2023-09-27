using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface IPersonModuleService
    {
        Task<List<PersonModule>> GetAllPersonModules();
        Task<PersonModule> GetPersonModule(int id);
        Task<List<PersonModule>> GetPersonModules(int personId, int moduleId);
        Task<List<PersonModule>> GetPersonModulesByPerson(int personId);
        Task<PersonModule> AddPersonModule(PersonModule personModule);
        Task<PersonModule> UpdatePersonModule(PersonModule personModule);
        Task<PersonModule> DeletePersonModule(int id);
    }
}
