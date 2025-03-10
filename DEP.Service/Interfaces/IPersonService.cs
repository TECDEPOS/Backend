﻿using DEP.Repository.Models;
using DEP.Service.ViewModels;
using DEP.Service.ViewModels.Statistic;

namespace DEP.Service.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> GetPersons();
        Task<List<Person>> GetPersonsByName(string name);
        Task<List<Person>> GetPersonsByCourseId(int courseId);
        Task<List<Person>> GetPersonsNotInCourse(int courseId);
        Task<List<Person>> GetPersonsByDepartmentAndLocation(int departmentId, int locationId);
        Task<Person> GetPersonById(int personId);
        //Task<Person> GetPersonById(int personId, int roleId);
        Task<List<PersonToTabelsViewModel>> GetPersonsTabel();
        Task<bool> DeletePerson(int id);
        Task<Person?> AddPerson(Person person);
        Task<bool> UpdatePerson(Person person);
    }
}
