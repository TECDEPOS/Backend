﻿using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<List<Course>> GetCoursesByModuleId(int id);
        Task<Course> GetCourseById(int id);
        Task<Course> AddCourse(Course personModule);
        Task<Course> UpdateCourse(Course personModule);
        Task<Course> DeleteCourse(int id);
    }
}