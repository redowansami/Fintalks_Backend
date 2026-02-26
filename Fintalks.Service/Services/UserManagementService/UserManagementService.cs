using AutoMapper;
using Fintalks.Common.Commands;
using Fintalks.Common.Constants;
using Fintalks.Common.Exceptions;
using Fintalks.Common.Models;
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
        public async Task<string> RegisterUser(RegisterUserCommand registerUser)
        {
            await IsUnique(registerUser);

            var createUser = _mapper.Map<CreateUserCommand>(registerUser);
            var user = _mapper.Map<User>(createUser);
            var dbUser = _mapper.Map<DBUser>(user);

            var createUserInfo = _mapper.Map<CreateUserInfoCommand>(registerUser);
            var userInfo = _mapper.Map<UserInfo>(createUserInfo);
            var dbUserInfo = _mapper.Map<DBUserInfo>(userInfo);

            var success = await _userManagementRepository.RegisterUser(dbUser, dbUserInfo);
            return success ? UserConst.Message.Register.success : UserConst.Message.Register.failed;
        }

        public async Task<bool> UpdateUserProfile(
            Guid id,
            UpdateUserProfileCommand updateUserProfile
        )
        {
            var user = await _userService.GetDBUserByID(id);
            var userInfo = await _userInfoService.GetUserInfoByID(user.ID);

            var updateUserCommand = _mapper.Map<UpdateUserCommand>(updateUserProfile);
            _mapper.Map(updateUserCommand, user);

            var updateUserInfoCommand = _mapper.Map<UpdateUserInfoCommand>(updateUserProfile);
            _mapper.Map(updateUserInfoCommand, userInfo);

            var success = await _userManagementRepository.UpdateUserProfile(user, userInfo);

            return success;
        }

        private async Task IsUnique(RegisterUserCommand registerUser)
        {
            bool userNameExists = await _userService.IsUserNameTaken(registerUser.UserName);
            bool emailExists = await _userService.IsEmailTaken(registerUser.Email);

            List<string> errors = new();
            if (userNameExists)
                errors.Add(ErrorConst.Message.userNameExists);
            if (emailExists)
                errors.Add(ErrorConst.Message.emailExists);
            if (errors.Any())
                throw new ConflictException(string.Join(", ", errors));
        }
    }
}
