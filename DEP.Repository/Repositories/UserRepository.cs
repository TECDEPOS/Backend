using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext context;

        public UserRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await context.Users
                .Include(u => u.Department)
                .Include(u => u.Location)
                .Include(u => u.EducationBoss)
                .ToListAsync();
        }

        public async Task<List<User>> GetEducationLeadersExcel()
        {
            var result = await context.Users
                .Where(u => u.UserRole == UserRole.Uddannelsesleder)
                .Select(el => new
                {
                    UserId = el.UserId,
                    Name = el.Name,
                    UserRole = el.UserRole,
                    EducationBossId = el.EducationBossId,
                })
                .ToListAsync();

            var leaders = new List<User>();
            foreach (var leader in result)
            {
                leaders.Add(new User()
                {
                    UserId = leader.UserId,
                    Name = leader.Name,
                    UserRole = leader.UserRole,
                    EducationBossId = leader.EducationBossId,
                });
            }

            return leaders;
        }

        public async Task<List<User>> GetEducationBossesExcel()
        {
            var result = await context.Users
                .Where(u => u.UserRole == UserRole.Uddannelseschef)
                .Select(eb => new
                {
                    UserId = eb.UserId,
                    Name = eb.Name,
                    UserRole = eb.UserRole,
                })
                .ToListAsync();

            var bosses = new List<User>();
            foreach (var user in result)
            {
                bosses.Add(new User()
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    UserRole = user.UserRole,
                });
            }
            return bosses;
        }

        public async Task<List<User>> GetUsersByEducationBossId(int id)
        {
            return await context.Users.Where(x => x.EducationBossId == id).ToListAsync();
        }

        public async Task<List<User>> GetUsersByUserRole(UserRole userRole)
        {
            return await context.Users.Where(x => x.UserRole == userRole).ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<List<User>> GetUserByName(string name)
        {
            return await context.Users.Where(x => x.Name.Contains(name.ToLower())).ToListAsync();
        }

        public async Task<User> GetUserByRefreshToken(string refreshToken)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
        }

        public async Task<bool> AddUser(User addRequest)
        {
            context.Users.Add(addRequest);
            int result = await context.SaveChangesAsync();

            //Return false if a user was not saved to the DB
            if (result < 1)
            {
                return false;
            }
            return true;
        }

        public async Task<User> UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user is null)
            {
                return false;
            }

            var personList = await context.Persons.Where(x => x.EducationalConsultantId == id || x.OperationCoordinatorId == id).ToListAsync();
            foreach (var person in personList)
            {
                if (person.EducationalConsultantId == id)
                {
                    person.EducationalConsultantId = null;
                }
                if (person.OperationCoordinatorId == id)
                {
                    person.OperationCoordinatorId = null;
                }
            }

            var educationalLeaders = await context.Users.Where(x => x.EducationBossId == id).ToListAsync();
            foreach (var leader in educationalLeaders)
            {
                leader.EducationBossId = null;
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
