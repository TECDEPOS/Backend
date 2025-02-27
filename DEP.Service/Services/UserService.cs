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

        public async Task<UserViewModel> AddUser(AddUserViewModel viewModel)
        {
            var defaultPass = configuration.GetSection("UserSettings:DefaultPassword").Value;
            authService.CreatePasswordHash(defaultPass, out byte[] passwordHash, out byte[] passwordSalt);

            User newUser = new User
            {
                UserName = viewModel.Username,
                Name = viewModel.Name,
                LocationId = viewModel.LocationId,
                DepartmentId = viewModel.DepartmentId,
                EducationBossId = viewModel.EducationBossId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserRole = viewModel.UserRole,
                PasswordExpiryDate = DateTime.Now.AddDays(-1)
            };

            var createdUser = await userRepository.AddUser(newUser);

            return new UserViewModel
            {
                UserId = createdUser.UserId,
                Name = createdUser.Name,
                LocationId = createdUser.LocationId,
                LocationName = createdUser.Location?.Name,
                DepartmentId = createdUser.DepartmentId,
                DepartmentName = createdUser.Department?.Name,
                EducationBossId = createdUser.EducationBossId,
                EducationBossName = createdUser.EducationBoss?.Name,
                UserRole = createdUser.UserRole
            };
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

            // Check if the role is changing
            bool isRoleChanging = user.UserRole != viewModel.UserRole;

            // Fetch persons where this user is assigned as a role
            if (isRoleChanging)
            {
                var affectedPersons = await personRepository.GetPersonsByUserId(user.UserId);

                foreach (var person in affectedPersons)
                {
                    // If user is no longer eligible for a role, set it to null
                    if (user.UserRole == UserRole.Uddannelsesleder && person.EducationalLeaderId == user.UserId)
                    {
                        person.EducationalLeaderId = null;
                    }
                    if (user.UserRole == UserRole.Pædagogisk_konsulent && person.EducationalConsultantId == user.UserId)
                    {
                        person.EducationalConsultantId = null;
                    }
                    if (user.UserRole == UserRole.Driftskoordinator && person.OperationCoordinatorId == user.UserId)
                    {
                        person.OperationCoordinatorId = null;
                    }
                }

                // Update all affected persons
                await personRepository.UpdatePersons(affectedPersons);
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
