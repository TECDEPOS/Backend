﻿using DEP.Repository.Context;
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
                .Include(x => x.Files)
                .ThenInclude(y => y.FileTag)
                .Include(x => x.PersonModules)
                .ThenInclude(y => y.Module)
                .Include(x => x.EducationalConsultant)
                .Include(x => x.OperationCoordinator)
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
                .Where(x => x.Name.ToLower().Contains(name.ToLower())).OrderBy(x => x.Name)
                .Include(x => x.Location)
                .Include(x => x.Department)
                .Include(x => x.Files)
                .ThenInclude(y => y.FileTag)
                .Include(x => x.PersonModules)
                .ThenInclude(y => y.Module)
                .Include(x => x.EducationalConsultant)
                .Include(x => x.OperationCoordinator)
                .ToListAsync();
            return person;
        }

        public async Task<Person> GetPersonById(int id)
        {
            var person = await context.Persons
                .Include(x => x.Location)
                .Include(x => x.Department)
                .Include(x => x.Files)
                .ThenInclude(y => y.FileTag)
                .Include(x => x.PersonModules)
                .ThenInclude(y => y.Module)
                .Include(x => x.EducationalConsultant)
                .Include(x => x.OperationCoordinator)
                .FirstOrDefaultAsync(x => x.PersonId == id);
            return person;
        }
    }
}