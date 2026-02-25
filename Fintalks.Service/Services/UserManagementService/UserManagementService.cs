using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Fintalks.Common.Commands;
using Fintalks.DB.DBEntity;
using Fintalks.Repository.Repositories.UserManagementRepository;
using Fintalks.Service.Services.UserInfoService;
using Fintalks.Service.Services.UserService;

namespace Fintalks.Service.Services.UserManagementService
{
    public class UserManagementService(
        IMapper _mapper,
        IUserSevice _userService,
        IUserInfoService _userInfoService,
        IUserManagementRepository _userManagementRepository
    ) : IUserManagementService
    {
        public async Task<string> CreateUser(RegisterUserCommand registerUser)
        {
            var createUser = _mapper.Map<CreateUserCommand>(registerUser);
            var newUser = await _userService.CreateUser(createUser);
            var userInfo = _mapper.Map<CreateUserInfoCommand>(registerUser);
            bool success = await _userInfoService.CreateUserInfo(userInfo, newUser);
            if (success)
            {
                await _userManagementRepository.Commit();
                return "User created successfully";
            }
            return "Could not create user";
        }

        public async Task<string> FailedCreateUser(RegisterUserCommand registerUser)
        {
            var createUser = _mapper.Map<CreateUserCommand>(registerUser);
            var newUser = await _userService.CreateUser(createUser);
            var userInfo = _mapper.Map<CreateUserInfoCommand>(registerUser);
            bool success = false;
            if (success)
            {
                await _userManagementRepository.Commit();
                return "User created successfully";
            }
            return "Could not create user";
        }

        public async Task<string> UpdateUserProfile(
            Guid id,
            UpdateUserProfileCommand updateUserProfile
        )
        {
            var updateUserCommand = _mapper.Map<UpdateUserCommand>(updateUserProfile);
            var updatedUser = await _userService.UpdateUser(id, updateUserCommand);
            var updateUserInfoCommand = _mapper.Map<UpdateUserInfoCommand>(updateUserProfile);
            var result = await _userInfoService.UpdateUserInfo(
                updatedUser.ID,
                updateUserInfoCommand
            );
            if (result)
                return "User updated successfully";
            return "Failed to Update User";
        }
    }
}
