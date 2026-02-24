using Fintalks.DB;
using Fintalks.DB.DBEntity;
using Microsoft.EntityFrameworkCore;

namespace Fintalks.Repository.Repositories.UserRepository
{
    public class UserRepository(ApplicationDBContext _context) : IUserRepository
    {
        private IQueryable<DBUser> query = _context.Users;

        public async Task<DBUser> CreateUser(DBUser user)
        {
            _context.Users.Add(user);
            //await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<DBUser>> GetUsers()
        {
            return await query.ToListAsync();
        }

        public async Task<DBUser?> GetUserById(Guid id)
        {
            return await query.FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<DBUser> UpdateUser(Guid id, DBUser UpdateUser)
        {
            _context.Update(UpdateUser);
            await _context.SaveChangesAsync();
            return UpdateUser;
        }

        public async Task DeleteUser(DBUser userToDelete)
        {
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            var user = await query.FirstOrDefaultAsync(u => u.Email == email);
            if (user is null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsUserNameTaken(string userName)
        {
            var user = await query.FirstOrDefaultAsync(u => u.UserName == userName);
            if (user is null)
            {
                return false;
            }
            return true;
        }
    }
}
