using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartments();
        Task<bool> AddDepartment(Department department);
        Task<bool> UpdateDepartment(Department department);
        Task<bool> DeleteDepartment(int id);
    }
}
