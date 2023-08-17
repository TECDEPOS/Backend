using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartments();
        Task<Department> AddDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Task<bool> DeleteDepartment(int id);
    }
}
