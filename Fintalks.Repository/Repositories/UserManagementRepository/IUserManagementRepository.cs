using System;
using System.Collections.Generic;
using System.Text;

namespace Fintalks.Repository.Repositories.UserManagementRepository
{
    public interface IUserManagementRepository
    {
        public Task Commit();
    }
}
