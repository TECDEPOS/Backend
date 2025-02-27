using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Repository.Repositories;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels;
using DEP.Service.ViewModels.Statistic;

namespace DEP.Service.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository repo;
        private readonly IDepartmentRepository departmentRepository;
        public PersonService(IPersonRepository repo, IDepartmentRepository departmentRepo)
        {
            this.repo = repo;
            this.departmentRepository = departmentRepo;
        }

        public async Task<Person?> AddPerson(Person person)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            person.HiringDate = TimeZoneInfo.ConvertTimeFromUtc(person.HiringDate, localTimeZone);
            person.HiringDate = person.HiringDate.Date;
            person.EndDate = person.HiringDate.AddYears(4);
            return await repo.AddPerson(person);
        }

        public async Task<bool> DeletePerson(int id)
        {
            return await repo.DeletePerson(id);
        }

        public Task<Person> GetPersonById(int personId)
        {
            return repo.GetPersonById(personId);
        }
        //public Task<Person> GetPersonById(int personId, int roleId)
        //{
        //    return repo.GetPersonById(personId, roleId);
        //}

        public async Task<List<Person>> GetPersons()
        {
            return await repo.GetPersons();
        }


        public async Task<List<Person>> GetPersonsByCourseId(int courseId)
        {
            return await repo.GetPersonsByCourseId(courseId);
        }

        public async Task<List<Person>> GetPersonsByEducationalLeaderId(int leaderId)
        {
            return await repo.GetPersonsByCourseId(leaderId);
        }

        public async Task<List<Person>> GetPersonsByDepartmentAndLocation(int departmentId, int locationId)
        {
            return await repo.GetPersonsByDepartmentAndLocation(departmentId, locationId);
        }

        public async Task<List<Person>> GetPersonsByName(string name)
        {
            return await repo.GetPersonsByName(name);
        }

        public async Task<List<Person>> GetPersonsNotInCourse(int courseId)
        {
            return await repo.GetPersonsNotInCourse(courseId);
        }

        public async Task<List<PersonToTabelsViewModel>> GetPersonsTabel()
        {
            var people = await repo.GetPersons();

            List<PersonToTabelsViewModel> NewPeople = new List<PersonToTabelsViewModel>();

            foreach (var item in people)
            {
                PersonToTabelsViewModel peps = new PersonToTabelsViewModel()
                {
                    Name = item.Name,
                    Initials = item.Initials,
                    HiringDate = item.HiringDate,
                    EndDate = item.EndDate,
                    SvuEligible = item.SvuEligible,
                    EducationalConsultant = item.EducationalConsultant,
                    OperationCoordinator = item.OperationCoordinator,
                    Department = item.Department,
                    Location = item.Location
                };

                NewPeople.Add(peps);
            }

            return NewPeople;
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            return await repo.UpdatePerson(person);
        }
    }
}
