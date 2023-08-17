using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface IPersonModuleRepository
    {
        Task<PersonModule> GetPersonModule(int personId, int moduleId, DateTime date);
        Task<List<PersonModule>> GetPersonModules(int personId, int moduleId);
        Task<PersonModule> AddPersonModule(PersonModule personModule);
        Task<PersonModule> UpdatePersonModule(PersonModule personModule);
        Task<PersonModule> DeletePersonModule(int personId, int moduleId, DateTime date);
    }
}
