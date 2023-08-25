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
            return await context.Users.ToListAsync();
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

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
