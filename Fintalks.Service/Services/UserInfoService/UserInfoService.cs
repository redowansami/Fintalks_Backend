using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Fintalks.Common.Commands;
using Fintalks.DB.DBEntity;
using Fintalks.Repository.Repositories.UserInfoRepository;

namespace Fintalks.Service.Services.UserInfoService
{
    public class UserInfoService(IUserInfoRepository _userInfoRepository, IMapper _mapper)
        : IUserInfoService
    {
        public async Task<bool> CreateUserInfo(CreateUserInfoCommand createUserInfo)
        {
            var user = _mapper.Map<DBUserInfo>(createUserInfo);
            var result = await _userInfoRepository.CreateUserInfo(user);
            return result is not null;
        }
    }
}
