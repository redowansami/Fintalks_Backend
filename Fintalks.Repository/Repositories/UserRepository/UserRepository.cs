using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Fintalks.Common.Commands;
using Fintalks.Common.Models;
using Fintalks.DB;
using Fintalks.DB.DBEntity;
using Microsoft.EntityFrameworkCore;

namespace Fintalks.Repository.Repositories.UserRepository
{
    public class UserRepository(ApplicationDBContext _context) : IUserRepository
    {
        public async Task<DBUser> CreateUser(DBUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<DBUser>> GetUsers()
        {
            IQueryable<DBUser> query = _context.Users.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<DBUser?> GetUserById(Guid id)
        {
            IQueryable<DBUser> query = _context.Users.AsNoTracking();
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
    }
}
