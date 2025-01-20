using DEP.Repository.Models;
using DEP.Repository.ViewModels;

namespace DEP.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<List<User>> GetEducationBossesExcel();
        Task<List<User>> GetEducationLeadersExcel();
        Task<List<User>> GetUsersByEducationBossId(int id);
        Task<List<User>> GetUsersByUserRole(UserRole userRole);
        Task<User> GetUserById(int id);
        Task<UserDashboardViewModel?> GetUserDashboardById(int id);
        Task<User> GetUserByUsername(string username);
        Task<List<User>> GetUserByName(string name);
        Task<User> GetUserByRefreshToken(string refreshToken);
        Task<bool> AddUser(User addRequest);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
