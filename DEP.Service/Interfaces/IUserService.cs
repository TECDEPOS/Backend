using DEP.Repository.Models;
using DEP.Repository.ViewModels;
using DEP.Service.ViewModels;

namespace DEP.Service.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<List<User>> GetUsersByEducationBossId(int id);
        Task<List<EducationBossViewModel>> GetEducationBossesExcel();
        Task<List<EducationBossViewModel>> GetSelctedEducationBossExcel(int id);
        Task<List<EducationLeaderViewModel>> GetSelectedEducationLeaderExcel(int id);
        Task<List<User>> GetUsersByUserRole(UserRole userRole);
        Task<User> GetUserById(int id);
        Task<UserDashboardViewModel?> GetUserDashboardById(int id);
        Task<List<User>> GetUserByName(string name);
        Task<User> GetUserByUsername(string username);
        Task<AddUserViewModel> AddUser(AddUserViewModel addRequest);
        Task<bool> ReassignUser(ReassignUserViewModel model);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
