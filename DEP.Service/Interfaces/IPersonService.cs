﻿using DEP.Repository.Models;
using DEP.Service.ViewModels;

namespace DEP.Service.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> GetPersons();
        Task<List<Person>> GetPersonsByName(string name);
        Task<Person> GetPersonById(int id);
        Task<List<PersonToTabelsViewModel>> GetPersonsTabel();
        Task<Person> DeletePerson(int id);
        Task<Person> AddPerson(Person person);
        Task<Person> UpdatePerson(Person person);

    }
}