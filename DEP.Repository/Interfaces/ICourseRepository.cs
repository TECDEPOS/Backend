using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<List<Course>> GetCourseWithPerson(int moduleId);
        Task<List<Course>> GetCoursesByModuleId(int modelId);
        Task<List<Course>> GetCoursesByModuleIdAndUserId(int modelId, int userId);
        Task<Course> GetCourseById(int id);
        Task<bool> AddCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task<Course> DeleteCourse(int id);
    }
}
