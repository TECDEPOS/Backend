using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;
using System;

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

        public async Task<List<Course>> GetCoursesByModuleId(int id)
        {
            return await repo.GetCoursesByModuleId(id);
        }

        public async Task<Course> AddCourse(Course course)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            course.StartDate = TimeZoneInfo.ConvertTimeFromUtc(course.StartDate, localTimeZone);
            course.StartDate = course.StartDate.Date;

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

        public async Task<Course> UpdateCourse(Course course)
        {
            return await repo.UpdateCourse(course);
        }
    }
}
