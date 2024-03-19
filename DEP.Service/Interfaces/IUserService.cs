using DEP.Repository.Models;
using DEP.Service.ViewModels;

namespace DEP.Service.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<List<User>> GetUsersByEducationBossId(int id);
        Task<List<EducationBossViewModel>> GetEducationBossesExcel();
        Task<List<User>> GetUsersByUserRole(UserRole userRole);
        Task<User> GetUserById(int id);
        Task<List<User>> GetUserByName(string name);
        Task<User> GetUserByUsername(string username);
        Task<AddUserViewModel> AddUser(AddUserViewModel addRequest);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
