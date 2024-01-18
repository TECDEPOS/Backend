using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);
        Task<Course> AddCourse(Course personModule);
        Task<Course> UpdateCourse(Course personModule);
        Task<Course> DeleteCourse(int id);
    }
}
