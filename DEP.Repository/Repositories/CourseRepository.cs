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
                        x.Module.Name,
                        x.Module.Description
                    }
                }).ToListAsync();

            var courses = new List<Course>();
            var personCourses = new List<PersonCourse>();
            foreach (var item in tempList)
            {
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
                        Name = item.Module.Name,
                        Description = item.Module.Description,
                    }
                });
            }

            return courses;
        }

        public Task<Course> GetCourseById(int id)
        {
            var course = context.Courses.Include(x => x.PersonCourses).ThenInclude(x => x.Person)
                .Include(x => x.Module)
                .FirstOrDefaultAsync(x => x.CourseId == id);

            return course;
        }

        //TODO: Lav om og flyt til PersonCourseRepository
        public async Task<List<Course>> GetPersonModules(int personId, int moduleId)
        {
            //var tempList = await context.Courses.Where(pm => pm.PersonId == personId && pm.ModuleId == moduleId)
            //    .Select(x => new
            //    {
            //        x.PersonModuleId,
            //        x.PersonId,
            //        x.ModuleId,
            //        x.StartDate,
            //        x.EndDate,
            //        x.Status,
            //        x.ModuleType,
            //        Person = new
            //        {
            //            x.Person.Name,
            //            x.Person.Initials
            //        },
            //        Module = new
            //        {
            //            x.Module.Name,
            //            x.Module.Description
            //        }
            //    }).ToListAsync();

            //var personModules = new List<Course>();
            //foreach (var item in tempList)
            //{
            //    personModules.Add(new Course()
            //    {
            //        PersonModuleId = item.PersonModuleId,
            //        PersonId = item.PersonId,
            //        ModuleId = item.ModuleId,
            //        StartDate = item.StartDate,
            //        EndDate = item.EndDate,
            //        ModuleType = item.ModuleType,
            //        Status = item.Status,
            //        Person = new Person()
            //        {
            //            Name = item.Person.Name,
            //            Initials = item.Person.Initials,
            //        },
            //        Module = new Module()
            //        {
            //            Name = item.Module.Name,
            //            Description = item.Module.Description,
            //        }
            //    });
            //}

            //return personModules;

            //var personModules = await context.PersonModules.Include(x => x.Person).Include(x => x.Module).Where(pm => pm.PersonId == personId && pm.ModuleId == moduleId).ToListAsync();
            return null;
        }

        //TODO: Lav om og flyt til PersonCourseRepository
        public async Task<List<Course>> GetPersonModulesByPerson(int personId)
        {
            //var tempList = await context.Courses.Where(pm => pm.PersonId == personId)
            //    .Select(x => new
            //    {
            //        x.PersonModuleId,
            //        x.PersonId,
            //        x.ModuleId,
            //        x.StartDate,
            //        x.EndDate,
            //        x.Status,
            //        x.ModuleType,
            //        Person = new
            //        {
            //            x.Person.Name,
            //            x.Person.Initials
            //        },
            //        Module = new
            //        {
            //            x.Module.Name,
            //            x.Module.Description
            //        }
            //    }).ToListAsync();

            //var personModules = new List<Course>();
            //foreach (var item in tempList)
            //{
            //    personModules.Add(new Course()
            //    {
            //        PersonModuleId = item.PersonModuleId,
            //        PersonId = item.PersonId,
            //        ModuleId = item.ModuleId,
            //        StartDate = item.StartDate,
            //        EndDate = item.EndDate,
            //        ModuleType = item.ModuleType,
            //        Status = item.Status,
            //        Person = new Person()
            //        {
            //            Name = item.Person.Name,
            //            Initials = item.Person.Initials,
            //        },
            //        Module = new Module()
            //        {
            //            Name = item.Module.Name,
            //            Description = item.Module.Description,
            //        }
            //    });
            //}

            //return personModules;
            return null;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            context.Entry(course).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return course;
        }
    }
}
