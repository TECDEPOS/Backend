using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;
using System.Reflection;
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

        public async Task<List<Course>> GetCoursesByModuleId(int moduleId)
        {
            return await repo.GetCoursesByModuleId(moduleId);
        }

        public async Task<List<Course>> GetCoursesByModuleIdAndUserId(int moduleId, int userId)
        {
            return await repo.GetCoursesByModuleIdAndUserId(moduleId, userId);
        }

        public async Task<bool> AddCourse(Course course)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            course.StartDate = TimeZoneInfo.ConvertTimeFromUtc(course.StartDate, localTimeZone);
            course.StartDate = course.StartDate.Date;

            course.Module = null;
            return await repo.AddCourse(course);
        }

        public async Task<bool> DeleteCourse(int id)
        {
            return await repo.DeleteCourse(id);
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await repo.GetCourseById(id);
        }

        public async Task<bool> UpdateCourse(Course course)
        {
            return await repo.UpdateCourse(course);
        }
    }
}
