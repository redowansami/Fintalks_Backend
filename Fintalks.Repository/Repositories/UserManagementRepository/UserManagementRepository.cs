using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.DB;

namespace Fintalks.Repository.Repositories.UserManagementRepository
{
    public class UserManagementRepository(ApplicationDBContext _context) : IUserManagementRepository
    {
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
