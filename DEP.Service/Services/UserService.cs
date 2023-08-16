using DEP.Repository.Models;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels;

namespace DEP.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserService service;

        public UserService(IUserService service)
        {
            this.service = service;
        }

        public async Task<List<User>> GetUsers()
        {
            return await service.GetUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await service.GetUserById(id);
        }

        public async Task<User> GetUserByName(string name)
        {
            return await service.GetUserByName(name);
        }

        public async Task<AddUserViewModel> AddUser(AddUserViewModel viewModel)
        {
            var user = await service.AddUser(viewModel);

            if (user == null)
            {
                return null;
            }

            return viewModel;
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await service.DeleteUser(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await service.UpdateUser(user);
        }
    }
}
