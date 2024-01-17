using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;

namespace DEP.Service.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository repo;
        public CourseService(ICourseRepository repo) { this.repo = repo; }

        public async Task<List<Course>> GetAllCourses()
        {
            return await repo.GetAllCourses();
        }

        public async Task<Course> AddCourse(Course course)
        {
            course.Module = null;
            return await repo.AddCourse(course);
        }

        public async Task<Course> DeleteCourse(int id)
        {
            return await repo.DeleteCourse(id);
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await repo.GetCourseById(id);
        }

        //Flyt til PersonCourseService
        public async Task<List<Course>> GetPersonModules(int personId, int moduleId)
        {
            return await repo.GetPersonModules(personId, moduleId);
        }

        //Flyt til PersonCourseService
        public async Task<List<Course>> GetPersonModulesByPerson(int personId)
        {
            return await repo.GetPersonModulesByPerson(personId);
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            return await repo.UpdateCourse(course);
        }
    }
}
