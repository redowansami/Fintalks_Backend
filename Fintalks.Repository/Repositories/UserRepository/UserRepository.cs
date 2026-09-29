using Fintalks.Common.Interfaces;
using Fintalks.DB;
using Fintalks.DB.DBEntity;
using Fintalks.DB.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Fintalks.Repository.Repositories
{
    public class UserRepository(ApplicationDBContext _context) : IUserRepository
    {
        private IQueryable<DBUser> query = _context.Users;

        public async Task<DBUser> CreateUser(DBUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<DBUser>> GetUsers()
        {
            var abc = _context.Users.Where(x => x.IsEmailConfirmed);
            return await query.ToListAsync();
        }

        public async Task<DBUser?> GetUserById(Guid id)
        {
            return await query.FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<DBUser> UpdateUser(DBUser UpdateUser)
        {
            _context.Update(UpdateUser);
            await _context.SaveChangesAsync();
            return UpdateUser;
        }

        public async Task DeleteUser(DBUser userToDelete)
        {
            //_context.Users.Remove(userToDelete);
            if (userToDelete is ISoftDeletable)
            {
                _context.Users.SoftDelete(userToDelete);
            }
            else
            {
                _context.Users.Remove(userToDelete);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            return await query.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> IsUserNameTaken(string userName)
        {
            return await query.AnyAsync(u => u.UserName == userName);
        }
    }
}
