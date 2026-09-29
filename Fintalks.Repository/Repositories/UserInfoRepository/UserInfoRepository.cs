using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.DB;
using Fintalks.DB.DBEntity;
using Microsoft.EntityFrameworkCore;

namespace Fintalks.Repository.Repositories
{
    public class UserInfoRepository(ApplicationDBContext _context) : IUserInfoRepository
    {
        private IQueryable<DBUserInfo> query = _context.UserInfos;

        public async Task<DBUserInfo> CreateUserInfo(DBUserInfo userInfo)
        {
            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();
            return userInfo;
        }

        public async Task<DBUserInfo?> GetUserInfoById(int id)
        {
            return await query.FirstOrDefaultAsync(u => u.DBUserID == id);
        }

        public async Task<DBUserInfo> UpdateUserInfo(DBUserInfo updateUserInfo)
        {
            _context.Update(updateUserInfo);
            await _context.SaveChangesAsync();
            return updateUserInfo;
        }
    }
}
