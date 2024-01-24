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

        public async Task<Course> AddCourse(Course course)
        {
            context.Courses.Add(course);
            await context.SaveChangesAsync();

            return course;
        }

        public async Task<Course> DeleteCourse(int id)
        {
            var course = await context.Courses
                .FirstOrDefaultAsync(x => x.CourseId == id);

            if (course != null)
            {
                context.Courses.Remove(course);
                int changes = await context.SaveChangesAsync();
            }

            return course;
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
        
        public async Task<List<Course>> GetCoursesByModuleId(int id)
        {
            return await context.Courses.Where(x => x.ModuleId == id).ToListAsync();
        }

        public Task<Course> GetCourseById(int id)
        {
            var course = context.Courses.Include(x => x.PersonCourses).ThenInclude(x => x.Person)
                .Include(x => x.Module)
                .FirstOrDefaultAsync(x => x.CourseId == id);

            return course;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            context.Entry(course).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return course;
        }
    }
}
