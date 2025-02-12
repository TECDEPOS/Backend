using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DatabaseContext context;
        public CourseRepository(DatabaseContext context) { this.context = context; }

        public async Task<bool> AddCourse(Course course)
        {
            context.Courses.Add(course);
            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            var course = await context.Courses.FindAsync(id);

            if (course is null)
            {
                return false;
            }

            context.Courses.Remove(course);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            var tempList = await context.Courses
                .Select(x => new
                {
                    x.CourseId,
                    x.ModuleId,
                    x.StartDate,
                    x.EndDate,
                    x.CourseType,
                    PersonCourses = x.PersonCourses.Select(pc => new
                    {
                        pc.Status,
                        pc.CourseId,
                        pc.PersonId,
                        Person = new
                        {
                            pc.Person.Name
                        }
                    }),
                    Module = new
                    {
                        x.Module.ModuleId,
                        x.Module.Name,
                        x.Module.Description
                    }
                }).ToListAsync();

            var courses = new List<Course>();
            var personCourses = new List<PersonCourse>();
            foreach (var item in tempList)
            {
                // Making a new instance of list per iteration otherwise all courses will share the same list of PersonCourse.
                personCourses = new List<PersonCourse>();

                foreach (var x in item.PersonCourses)
                {
                    personCourses.Add(new PersonCourse()
                    {
                        PersonId = x.PersonId,
                        CourseId = x.CourseId,
                        Status = x.Status,
                        Person = new Person()
                        {
                            Name = x.Person.Name,
                        },
                    });
                }
                courses.Add(new Course()
                {
                    CourseId = item.CourseId,
                    ModuleId = item.ModuleId,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    CourseType = item.CourseType,
                    PersonCourses = personCourses,
                    Module = new Module()
                    {
                        ModuleId = item.ModuleId,
                        Name = item.Module.Name,
                        Description = item.Module.Description,
                    }
                });
            }

            return courses;
        }

        public async Task<List<Course>> GetCoursesByModuleId(int moduleId)
        {
            return await context.Courses.Where(x => x.ModuleId == moduleId).Include(x => x.PersonCourses).OrderBy(x => x.StartDate).OrderBy(x => x.EndDate).ToListAsync();
        }

        public async Task<List<Course>> GetCoursesByModuleIdAndUserId(int moduleId, int userId)
        {
            
            var courses = new List<Course>();
            courses = await context.Courses.Where(x => x.ModuleId == moduleId).Include(x => x.PersonCourses).OrderBy(x => x.StartDate).OrderBy(x => x.EndDate).ToListAsync();
            
            var newCourses = new List<Course>();

            foreach (var course in courses)
            {
                bool any = course.PersonCourses.Any(x => x.PersonId == userId);
                
                if (!any)
                {
                    newCourses.Add(course);
                }
            }

            return newCourses;
        }
        
        public Task<Course> GetCourseById(int id)
        {
            var course = context.Courses.Include(x => x.PersonCourses).ThenInclude(x => x.Person)
                .Include(x => x.Module)
                .FirstOrDefaultAsync(x => x.CourseId == id);

            return course;
        }

        public async Task<bool> UpdateCourse(Course course)
        {
            context.Entry(course).State = EntityState.Modified;
            var result = await context.SaveChangesAsync();

            return result > 0;
        }
        
        public async Task<List<Course>> GetCourseWithPerson(int moduleId)
        {
            return await context.Courses
                .Include(c => c.PersonCourses).ThenInclude(pc => pc.Person).ThenInclude(p => p.Department)
                .Include(c => c.PersonCourses).ThenInclude(pc => pc.Person).ThenInclude(p => p.Location)
                .Where(c => c.ModuleId == moduleId).ToListAsync();
        }
    }
}
