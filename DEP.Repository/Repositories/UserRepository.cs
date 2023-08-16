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

        public async Task<User> GetUserByName(string username)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Name == username);
        }

        public async Task<User> AddUser(User addRequest)
        {
            context.Users.Add(addRequest);
            await context.SaveChangesAsync();
            return addRequest;
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
