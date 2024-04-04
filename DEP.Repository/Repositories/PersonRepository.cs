using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DatabaseContext context;

        public PersonRepository(DatabaseContext context) { this.context = context; }

        public async Task<Person> AddPerson(Person person)
        {
            context.Persons.Add(person);
            await context.SaveChangesAsync();
            return person;
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

        public async Task<Person> UpdatePerson(Person person)
        {
            context.Entry(person).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> DeletePerson(int id)
        {
            var PersonToDelete = await context.Persons.FirstOrDefaultAsync(x => x.PersonId == id);

            context.Persons.Remove(PersonToDelete);
            await context.SaveChangesAsync();
            return PersonToDelete;
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

        public async Task<Person> GetPersonById(int personId, int roleId)
        {
            var person = await context.Persons
                .Include(x => x.Location)
                .Include(x => x.Department)
                .Include(x => x.Files)
                .ThenInclude(y => y.FileTag)
                .Include(x => x.PersonCourses)
                .ThenInclude(x => x.Course)
                .ThenInclude(y => y.Module)
                .Include(x => x.EducationalConsultant)
                .Include(x => x.OperationCoordinator)
                .FirstOrDefaultAsync(x => x.PersonId == personId);

            if (person == null)
            {
                return null;
            }

            if (roleId == 1)
            {
                person.Files = person.Files.Where(x => x.FileTag?.ControllerVisibility == true || x.FileTag == null).ToList();
            }
            else if (roleId == 2)
            {
                person.Files = person.Files.Where(x => x.FileTag?.EducationLeaderVisibility == true || x.FileTag == null).ToList();
            }
            else if (roleId == 3)
            {
                person.Files = person.Files.Where(x => x.FileTag?.EducationBossVisibility == true || x.FileTag == null).ToList();
            }
            else if (roleId == 4)
            {
                person.Files = person.Files.Where(x => x.FileTag?.PKVisibility == true || x.FileTag == null).ToList();
            }
            else if (roleId == 5)
            {
                person.Files = person.Files.Where(x => x.FileTag?.HRVisibility == true || x.FileTag == null).ToList();
            }
            else if (roleId == 6)
            {
                person.Files = person.Files.Where(x => x.FileTag?.DKVisibility == true || x.FileTag == null).ToList();
            }
            // Administrator
            else if (roleId == 0)
            {
                person.Files.Clear();
            }

            return person;
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
                .Where(p => p.DepartmentId == leaderId)
                .ToListAsync();
        }
    }
}
