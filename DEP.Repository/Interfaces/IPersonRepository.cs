using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> AddPerson(Person person);
        Task<Person> UpdatePerson(Person person);
        Task<List<Person>> GetPersonsByName(string name);
        Task<Person> GetPersonById(int personId, int roleId);
        Task<Person> DeletePerson(int id);
        Task<List<Person>> GetPersons();
    }
}
