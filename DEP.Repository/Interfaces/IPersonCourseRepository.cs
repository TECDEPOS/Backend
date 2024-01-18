using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface IPersonCourseRepository
    {
        Task<List<PersonCourse>> GetAllPersonCourses();
        Task<List<PersonCourse>> GetPersonCoursesByPerson(int personId);
        Task<List<PersonCourse>> GetPersonCoursesByCourse(int courseId);
        Task<PersonCourse> AddPersonCourse(PersonCourse personCourse);
        Task<PersonCourse> UpdatePersonCourse(PersonCourse personCourse);
        Task<bool> DeletePersonCourse(int personId, int courseId);
    }
}
