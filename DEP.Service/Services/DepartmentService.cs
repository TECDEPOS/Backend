using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;

namespace DEP.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository depRepository;

        public DepartmentService(IDepartmentRepository depRepository)
        {
            this.depRepository = depRepository;
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await depRepository.GetDepartments();
        }

        public async Task<bool> AddDepartment(Department department)
        {
            return await depRepository.AddDepartment(department);
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            return await depRepository.UpdateDepartment(department);
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            return await depRepository.DeleteDepartment(id);
        }
    }
}
