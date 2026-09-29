using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Fintalks.Common.Commands;
using Fintalks.Common.Exceptions;
using Fintalks.Common.Models;
using Fintalks.DB.DBEntity;
using Fintalks.Repository.Repositories;

namespace Fintalks.Service.Services.UserInfoService
{
    public class UserInfoService(IUserInfoRepository _userInfoRepository) : IUserInfoService
    {
        public async Task<DBUserInfo> GetUserInfoByID(int DBUserID)
        {
            var userInfo = await _userInfoRepository.GetUserInfoById(DBUserID);
            if (userInfo is null)
                throw new NotFoundException("User Info", DBUserID);
            return userInfo;
        }
    }
}
