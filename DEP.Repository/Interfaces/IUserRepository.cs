using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string name);
        Task<User> AddUser(User addRequest);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
