using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class PersonCourseRepository : IPersonCourseRepository
    {
        private readonly DatabaseContext context;
        public PersonCourseRepository(DatabaseContext context)
        {
                this.context = context;
        }

        public async Task<PersonCourse> AddPersonCourse(PersonCourse personCourse)
        {
            context.PersonCourses.Add(personCourse);
            await context.SaveChangesAsync();
            return personCourse;
        }

        public async Task<bool> DeletePersonCourse(int personId, int courseId)
        {
            var personCourse = await context.PersonCourses
                .FirstOrDefaultAsync(x => x.PersonId == personId && x.CourseId == courseId);

            if (personCourse is not null)
            {
                context.PersonCourses.Remove(personCourse);
                int changes = await context.SaveChangesAsync();

                if (changes > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<List<PersonCourse>> GetAllPersonCourses()
        {
            return await context.PersonCourses
                .Include(pc => pc.Person)
                .Include(pc => pc.Course)
                .ToListAsync();
        }

        public async Task<List<PersonCourse>> GetPersonCoursesByCourse(int courseId)
        {
            return await context.PersonCourses
                .Where(x => x.CourseId == courseId)
                .Include(pc => pc.Person)
                .Include(pc => pc.Course)
                .ToListAsync();
        }

        public async Task<List<PersonCourse>> GetPersonCoursesByPerson(int personId)
        {
            return await context.PersonCourses
                .Where(x => x.PersonId == personId)
                .Include(pc => pc.Person)
                .Include(pc => pc.Course)
                .ToListAsync();
        }

        public async Task<PersonCourse> UpdatePersonCourse(PersonCourse personCourse)
        {
            context.Entry(personCourse).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return personCourse;
        }
    }
}
