using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);
        Task<List<Course>> GetPersonModules(int personId, int moduleId);
        Task<List<Course>> GetPersonModulesByPerson(int personId);
        Task<Course> AddCourse(Course personModule);
        Task<Course> UpdateCourse(Course personModule);
        Task<Course> DeleteCourse(int id);
    }
}
