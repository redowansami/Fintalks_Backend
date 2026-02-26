using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.Common.Commands;
using Fintalks.DB.DBEntity;

namespace Fintalks.Service.Services.UserManagementService
{
    public interface IUserManagementService
    {
        public Task<string> RegisterUser(RegisterUserCommand registerUser);
        public Task<bool> UpdateUserProfile(Guid id, UpdateUserProfileCommand updateUserProfile);
    }
}
