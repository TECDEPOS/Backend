﻿using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DatabaseContext context;

        public DepartmentRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await context.Departments.ToListAsync();
        }

        public async Task<bool> AddDepartment(Department department)
        {
            context.Departments.Add(department);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateDepartment(Department department)
        {
            context.Entry(department).State = EntityState.Modified;
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var dep = await context.Departments.FindAsync(id);

            if (dep is null)
            {
                return false;
            }

            context.Departments.Remove(dep);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
