using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.Common.Commands;

namespace Fintalks.Service.Services.UserInfoService
{
    public interface IUserInfoService
    {
        public Task<bool> CreateUserInfo(CreateUserInfoCommand createUserInfo);
    }
}
