using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface ICourseService
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
