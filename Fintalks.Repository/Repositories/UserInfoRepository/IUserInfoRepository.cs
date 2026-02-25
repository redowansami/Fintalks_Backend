using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.DB.DBEntity;

namespace Fintalks.Repository.Repositories.UserInfoRepository
{
    public interface IUserInfoRepository
    {
        public Task<DBUserInfo> CreateUserInfo(DBUserInfo userInfo);
        public Task<DBUserInfo> UpdateUserInfo(DBUserInfo updateUserInfo);
        public Task<DBUserInfo?> GetUserInfoById(int id);
    }
}
