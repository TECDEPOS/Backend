using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace DEP.Repository.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DatabaseContext context;

        public PersonRepository(DatabaseContext context) { this.context = context; }

        public async Task<Person?> AddPerson(Person person)
        {
            context.Persons.Add(person);
            var result = await context.SaveChangesAsync();
            if (result > 0)
            {
                return person;
            }

            return null;
        }

        public async Task<List<Person>> GetPersons()
        {
            var person = await context.Persons
                .Include(x => x.Location)
                .Include(x => x.Department)
                .Include(x => x.EducationalLeader)
                .Include(x => x.EducationalConsultant)
                .Include(x => x.OperationCoordinator)
                .Include(x => x.PersonCourses)
                .ToListAsync();
            return person;
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            context.Entry(person).State = EntityState.Modified;
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task UpdatePersons(List<Person> persons)
        {
            context.Persons.UpdateRange(persons);
            await context.SaveChangesAsync();
        }


        public async Task<bool> DeletePerson(int id)
        {
            var person = await context.Persons.FindAsync(id);

            if (person is null)
            {
                return false;
            }

            context.Persons.Remove(person);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Person>> GetPersonsByName(string name)
        {
            var person = await context.Persons
                .Where(x => x.Name.ToLower().Contains(name.ToLower()) || x.Initials.ToLower().Contains(name.ToLower()))
                .OrderBy(x => x.Name)
                .Include(x => x.Location)
                .Include(x => x.Department)
                .Include(x => x.Files)
                .ThenInclude(y => y.FileTag)
                .Include(x => x.PersonCourses)
                .ThenInclude(x => x.Course)
                .ThenInclude(y => y.Module)
                .Include(x => x.EducationalConsultant)
                .Include(x => x.OperationCoordinator)
                .ToListAsync();
            return person;
        }

        public async Task<Person?> GetPersonById(int personId)
        {
            var person = await context.Persons
                .Include(x => x.Location)
                .Include(x => x.Department)
                .Include(x => x.Files)
                .ThenInclude(y => y.FileTag)
                .ThenInclude(ft => ft.FileTagUserRoles)
                .Include(x => x.PersonCourses)
                .ThenInclude(x => x.Course)
                .ThenInclude(y => y.Module)
                .Include(x => x.EducationalConsultant)
                .Include(x => x.EducationalLeader)
                .Include(x => x.OperationCoordinator)
                .FirstOrDefaultAsync(x => x.PersonId == personId);

            return person;
        }

        public async Task<List<Person>> GetPersonsByUserId(int userId)
        {
            return await context.Persons
                .Where(p => p.EducationalConsultantId == userId ||
                            p.EducationalLeaderId == userId ||
                            p.OperationCoordinatorId == userId)
                .ToListAsync();
        }

        public async Task<List<Person>> GetPersonsByCourseId(int courseId)
        {
            var persons = new List<Person>();
            persons = await context.Persons.Include(x => x.PersonCourses).Include(x => x.Department).Include(x => x.Location).ToListAsync();

            var newPersons = new List<Person>();
            foreach (var person in persons)
            {
            var newPersonsCourses = new List<PersonCourse>();
                if (person.PersonCourses.Any(x => x.CourseId == courseId))
                {
                    foreach (var personCourse in person.PersonCourses)
                    {
                        if (personCourse.CourseId == courseId)
                        {
                            newPersonsCourses.Add(personCourse);
                        }
                    }
                    person.PersonCourses = newPersonsCourses;
                    newPersons.Add(person);
                }
            }

            return newPersons;
        }

        public async Task<List<Person>> GetPersonsNotInCourse(int courseId)
        {
            var persons = new List<Person>();
            persons = await context.Persons.Include(x => x.PersonCourses).Include(x => x.Department).Include(x => x.Location).ToListAsync();

            var newPersons = new List<Person>();
            foreach (var person in persons)
            {
                if (!person.PersonCourses.Any(x => x.CourseId == courseId))
                {
                    newPersons.Add(person);
                }
            }

            return newPersons;
        }

        public async Task<List<Person>> GetPersonsByDepartmentAndLocation(int departmentId, int locationId)
        {
            return await context.Persons
                .Include(p => p.Location)
                .Include(p => p.Department)               
                .Where(p => p.DepartmentId == departmentId && p.LocationId == locationId)
                .ToListAsync();
        }

        public async Task<List<Person>> GetPersonsExcel(int leaderId)
        {
            return await context.Persons
                .Include(p => p.Location)
                .Include(p => p.Department)
                .Include(p => p.PersonCourses).ThenInclude(pc => pc.Course).ThenInclude(c => c.Module)
                .Where(p => p.EducationalLeaderId == leaderId)
                .ToListAsync();
        }

        public async Task<List<Person>> GetPersonsByModuleId(int moduleId)
        {
            return await context.Persons
                .Where(p => p.PersonCourses.Any(pc => pc.Course.ModuleId == moduleId))
                .Distinct()
                .ToListAsync();
        }
    }
}
