using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.DB.DBEntity;

namespace Fintalks.Repository.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public Task<DBUser> CreateUser(DBUser user);

        public Task<IEnumerable<DBUser>> GetUsers();

        public Task<DBUser> GetUserById(Guid id);

        public Task<DBUser> UpdateUser(Guid id, DBUser UpdateUser);

        public Task DeleteUser(DBUser userToDelete);
    }
}
