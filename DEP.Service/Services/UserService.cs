using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Repository.ViewModels;
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
        private readonly IPersonRepository personRepository;

        public UserService(IUserRepository userRepository, IAuthService authService, IConfiguration configuration, IPersonRepository personRepository)
        {
            this.userRepository = userRepository;
            this.authService = authService;
            this.configuration = configuration;
            this.personRepository = personRepository;
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

        public async Task<UserDashboardViewModel?> GetUserDashboardById(int id)
        {
            return await userRepository.GetUserDashboardById(id);
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
                LocationId = viewModel.LocationId,
                DepartmentId = viewModel.DepartmentId,
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

        public async Task<bool> ReassignUser(ReassignUserViewModel model)
        {
            return await userRepository.ReassignUser(model);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await userRepository.DeleteUser(id);
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await userRepository.UpdateUser(user);
        }

        public async Task<bool> UpdateUserFromViewModel(UserViewModel viewModel)
        {
            var user = await userRepository.GetUserById(viewModel.UserId);

            if (user is null)
            {
                return false;
            }

            // Map updated values to existing user
            user.Name = viewModel.Name;
            user.DepartmentId = viewModel.DepartmentId;
            user.EducationBossId = viewModel.EducationBossId;
            user.LocationId = viewModel.LocationId;
            user.UserRole = viewModel.UserRole;


            return await userRepository.UpdateUser(user);
        }

        public async Task<List<EducationBossViewModel>> GetEducationBossesExcel()
        {
            var bosses = await userRepository.GetEducationBossesExcel();
            var viewModel = new List<EducationBossViewModel>();

            foreach (var boss in bosses)
            {
                var bossViewModel = new EducationBossViewModel
                {
                    UserId = boss.UserId,
                    Name = boss.Name,
                    UserRole = boss.UserRole
                };

                viewModel.Add(bossViewModel);
            }

            return viewModel;
        }

        public async Task<List<EducationLeaderViewModel>> GetEducationLeadersExcel()
        {
            var leaders = await userRepository.GetEducationLeadersExcel();
            var viewModel = new List<EducationLeaderViewModel>();

            foreach (var leader in leaders)
            {
                var persons = new List<Person>();
                var person = await personRepository.GetPersonsExcel((int)leader.UserId);

                persons.AddRange(person);

                var leaderViewModel = new EducationLeaderViewModel
                {
                    UserId = leader.UserId,
                    Name = leader.Name,
                    UserRole = leader.UserRole,
                    EducationBossId = leader.EducationBossId,
                    Educators = persons.ToList(),
                };

                viewModel.Add(leaderViewModel);
            }

            return viewModel;
        }
    }
}
