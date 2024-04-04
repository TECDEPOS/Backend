using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<List<Course>> GetCourseExcel(int moduleId);
        Task<List<Course>> GetCoursesByModuleId(int modelId);
        Task<List<Course>> GetCoursesByModuleIdAndUserId(int modelId, int userId);
        Task<Course> GetCourseById(int id);
        Task<Course> AddCourse(Course personModule);
        Task<Course> UpdateCourse(Course personModule);
        Task<Course> DeleteCourse(int id);
    }
}
