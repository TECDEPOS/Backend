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
        public PersonService(IPersonRepository repo) { this.repo = repo; }

        public async Task<Person> AddPerson(Person person)
        {
            return await repo.AddPerson(person);
        }

        public async Task<Person> DeletePerson(int id)
        {
            return await repo.DeletePerson(id);
        }

        public Task<Person> GetPersonById(int id)
        {
            return repo.GetPersonById(id);
        }

        public async Task<List<Person>> GetPersons()
        {
            return await repo.GetPersons();
        }

        public async Task<List<Person>> GetPersonsByName(string name)
        {
            return await repo.GetPersonsByName(name);
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
            return await repo.UpdatePerson(person);
        }
    }
}
