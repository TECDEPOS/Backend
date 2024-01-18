using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface IPersonCourseService
    {
        Task<List<PersonCourse>> GetAllPersonCourses();
        Task<List<PersonCourse>> GetPersonCoursesByPerson(int personId);
        Task<List<PersonCourse>> GetPersonCoursesByCourse(int courseId);
        Task<PersonCourse> AddPersonCourse(PersonCourse personCourse);
        Task<PersonCourse> UpdatePersonCourse(PersonCourse personCourse);
        Task<bool> DeletePersonCourse(int personId, int courseId);
    }
}
