using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels.Statistic;

namespace DEP.Service.Services
{
    public class PersonCourseService : IPersonCourseService
    {
        private readonly IPersonCourseRepository repo;

        public PersonCourseService(IPersonCourseRepository repo)
        {
            this.repo = repo;
        }

        public async Task<PersonCourse> AddPersonCourse(PersonCourse personCourse)
        {
            return await repo.AddPersonCourse(personCourse);
        }

        public async Task<bool> DeletePersonCourse(int personId, int courseId)
        {
            return await repo.DeletePersonCourse(personId, courseId);
        }

        public async Task<List<PersonCourse>> GetAllPersonCourses()
        {
            return await repo.GetAllPersonCourses();
        }

        public async Task<List<PersonCourse>> GetPersonCoursesByCourse(int courseId)
        {
            return await repo.GetPersonCoursesByCourse(courseId);
        }

        public async Task<List<PersonCourse>> GetPersonCoursesByPerson(int personId)
        {
            return await repo.GetPersonCoursesByPerson(personId);
        }

        public async Task<PersonCourse> UpdatePersonCourse(PersonCourse personCourse)
        {
            return await repo.UpdatePersonCourse(personCourse);
        }
    }
}
