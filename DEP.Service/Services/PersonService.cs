using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Repository.Repositories;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels;

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

        public async Task<Person> AddPerson(Person person)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            person.HiringDate = TimeZoneInfo.ConvertTimeFromUtc(person.HiringDate, localTimeZone);
            person.HiringDate = person.HiringDate.Date;
            person.EndDate = person.HiringDate.AddYears(4);
            return await repo.AddPerson(person);
        }

        public async Task<Person> DeletePerson(int id)
        {
            return await repo.DeletePerson(id);
        }

        public Task<Person> GetPersonById(int personId, int roleId)
        {
            return repo.GetPersonById(personId, roleId);
        }

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

        public async Task<Person> UpdatePerson(Person person)
        {
            person.EducationalLeaderId = person.EducationalLeader?.UserId;
            person.EducationalConsultantId = person.EducationalConsultant?.UserId;
            person.OperationCoordinatorId = person.OperationCoordinator?.UserId;
            person.LocationId = person.Location?.LocationId;
            person.DepartmentId = person.Department?.DepartmentId;
            return await repo.UpdatePerson(person);
        }

        public async Task<List<PersonPerDepartmentViewModel>> GetPersonPerDepartment(int moduleId)
        {
            var departments = await departmentRepository.GetDepartments();
            var persons = await repo.GetPersonsByModuleId(moduleId);

            // Group persons by DepartmentId and count them
            var personCounts = persons
            .GroupBy(p => p.DepartmentId)
            .Select(g => new
            {
                DepartmentId = g.Key,
                Count = g.Distinct().Count()
            })
            .ToList();

            // Create and populate the view model
            var result = departments
                .Select(d => new PersonPerDepartmentViewModel
                {
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.Name,
                    TeacherCount = personCounts.FirstOrDefault(pc => pc.DepartmentId == d.DepartmentId)?.Count ?? 0
                })
                .ToList();

            // Handle persons with no department
            var noDepartmentCount = personCounts.FirstOrDefault(pc => pc.DepartmentId == null)?.Count ?? 0;
            if (noDepartmentCount > 0)
            {
                result.Add(new PersonPerDepartmentViewModel
                {
                    DepartmentId = 0,  // Use 0 or any other value to indicate no department
                    DepartmentName = "Uden afdeling",
                    TeacherCount = noDepartmentCount
                });
            }

            return result;
        }
    }
}
