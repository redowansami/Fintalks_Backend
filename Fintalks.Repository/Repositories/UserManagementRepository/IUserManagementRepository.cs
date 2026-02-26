using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.Common.Commands;
using Fintalks.DB.DBEntity;

namespace Fintalks.Repository.Repositories.UserManagementRepository
{
    public interface IUserManagementRepository
    {
        public Task<bool> RegisterUser(DBUser dbUser, DBUserInfo dbUserInfo);
        public Task<bool> UpdateUserProfile(DBUser updateUser, DBUserInfo updateUserInfo);
        public Task Commit();
    }
}
