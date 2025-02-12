using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person?> AddPerson(Person person);
        Task<bool> UpdatePerson(Person person);
        Task<List<Person>> GetPersonsByCourseId(int courseId);
        Task<List<Person>> GetPersonsNotInCourse(int courseId);
        Task<List<Person>> GetPersonsByName(string name);
        Task<List<Person>> GetPersonsByDepartmentAndLocation(int departmentId, int locationId);
        Task<List<Person>> GetPersonsExcel(int leaderId);
        Task<Person> GetPersonById(int personId);
        //Task<Person> GetPersonById(int personId, int roleId);
        Task<bool> DeletePerson(int id);
        Task<List<Person>> GetPersons();
        Task<List<Person>> GetPersonsByModuleId(int moduleId);
    }
}
