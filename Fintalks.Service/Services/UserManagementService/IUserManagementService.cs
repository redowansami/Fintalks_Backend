using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.Common.Commands;

namespace Fintalks.Service.Services.UserManagementService
{
    public interface IUserManagementService
    {
        public Task<string> CreateUser(RegisterUserCommand registerUser);
        public Task<string> UpdateUserProfile(Guid id, UpdateUserProfileCommand updateUserProfile);
        public Task<string> FailedCreateUser(RegisterUserCommand registerUser);
    }
}
