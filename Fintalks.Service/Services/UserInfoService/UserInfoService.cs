using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Fintalks.Common.Commands;
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
    }
}
