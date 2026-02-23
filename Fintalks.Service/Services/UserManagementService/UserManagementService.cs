using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Fintalks.Common.Commands;
using Fintalks.Service.Services.UserInfoService;
using Fintalks.Service.Services.UserService;

namespace Fintalks.Service.Services.UserManagementService
{
    public class UserManagementService(
        IMapper _mapper,
        IUserSevice _userService,
        IUserInfoService _userInfoService
    ) : IUserManagementService
    {
        public async Task<string> CreateUser(RegisterUserCommand registerUser)
        {
            var createUser = _mapper.Map<CreateUserCommand>(registerUser);
            var newUser = await _userService.CreateUser(createUser);
            var userInfo = _mapper.Map<CreateUserInfoCommand>(registerUser);
            userInfo.DBUserID = newUser.ID;
            bool success = await _userInfoService.CreateUserInfo(userInfo);
            if (success)
                return "User created successfully";
            return "Could not create user";
        }
    }
}
