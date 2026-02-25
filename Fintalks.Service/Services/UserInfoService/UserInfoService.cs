using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Fintalks.Common.Commands;
using Fintalks.Common.Exceptions;
using Fintalks.Common.Models;
using Fintalks.DB.DBEntity;
using Fintalks.Repository.Repositories.UserInfoRepository;

namespace Fintalks.Service.Services.UserInfoService
{
    public class UserInfoService(IUserInfoRepository _userInfoRepository, IMapper _mapper)
        : IUserInfoService
    {
        public async Task<bool> CreateUserInfo(CreateUserInfoCommand createUserInfo, DBUser newUser)
        {
            var userInfo = _mapper.Map<UserInfo>(createUserInfo);
            var dBUserInfo = _mapper.Map<DBUserInfo>(userInfo);
            dBUserInfo.User = newUser;
            var result = await _userInfoRepository.CreateUserInfo(dBUserInfo);
            return result is not null;
        }

        public async Task<DBUserInfo> GetUserInfoByID(int DBUserID)
        {
            var userInfo = await _userInfoRepository.GetUserInfoById(DBUserID);
            if (userInfo is null)
                throw new NotFoundException("User Info", DBUserID);
            return userInfo;
        }

        public async Task<bool> UpdateUserInfo(int DBUserID, UpdateUserInfoCommand updateUserInfo)
        {
            var userInfoToUpdate = await GetUserInfoByID(DBUserID);
            var userInfo = _mapper.Map(updateUserInfo, userInfoToUpdate);
            var updatedUser = await _userInfoRepository.UpdateUserInfo(userInfo);
            return updatedUser is not null;
        }
    }
}
