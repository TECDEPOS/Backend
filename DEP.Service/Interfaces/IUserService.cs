using DEP.Repository.Models;
using DEP.Service.ViewModels;

namespace DEP.Service.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string name);
        Task<AddUserViewModel> AddUser(AddUserViewModel addRequest);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
