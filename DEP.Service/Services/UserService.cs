using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels;
using Microsoft.Extensions.Configuration;

namespace DEP.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IAuthService authService;
        private readonly IConfiguration configuration;

        public UserService(IUserRepository userRepository, IAuthService authService, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.authService = authService;
            this.configuration = configuration;
        }

        public async Task<List<User>> GetUsers()
        {
            return await userRepository.GetUsers();
        }

        public async Task<List<User>> GetUsersByEducationBossId(int id)
        {
            return await userRepository.GetUsersByEducationBossId(id);
        }

        public async Task<List<User>> GetUsersByUserRole(UserRole userRole)
        {
            return await userRepository.GetUsersByUserRole(userRole);
        }

        public async Task<User> GetUserById(int id)
        {
            return await userRepository.GetUserById(id);
        }

        public async Task<List<User>> GetUserByName(string name)
        {
            return await userRepository.GetUserByName(name);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await userRepository.GetUserByUsername(username);
        }

        public async Task<AddUserViewModel> AddUser(AddUserViewModel viewModel)
        {
            //Gets the default password appsettings.json
            var defaultPass = configuration.GetSection("UserSettings:DefaultPassword").Value;

            //Creates a hash and salt from the provided password
            authService.CreatePasswordHash(defaultPass, out byte[] passwordHash, out byte[] passwordSalt);

            User newUser = new User()
            {
                UserName = viewModel.Username,
                Name = viewModel.Name,
                EducationBossId = viewModel.EducationBossId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserRole = viewModel.UserRole,
                PasswordExpiryDate = DateTime.Now.AddDays(-1) //Setting the expired password day to yesterday so first time users log in they're prompted to change it.
            };

            var success = await userRepository.AddUser(newUser);

            if (success == false)
            {
                return null;
            }
            return viewModel;
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await userRepository.DeleteUser(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await userRepository.UpdateUser(user);
        }
    }
}
