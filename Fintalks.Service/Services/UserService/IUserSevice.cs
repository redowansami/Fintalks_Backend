using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.Common.Commands;
using Fintalks.Common.DTOs;
using Fintalks.DB.DBEntity;

namespace Fintalks.Service.Services.UserService
{
    public interface IUserSevice
    {
        public Task<UserResponseDTO> CreateUser(CreateUserCommand createUser);

        public Task<IEnumerable<UserResponseDTO>> GetUsers();

        public Task<UserResponseDTO> GetUserByID(Guid id);

        public Task<UserResponseDTO> UpdateUser(Guid id, UpdateUserCommand UpdateUser);

        public Task DeleteUser(Guid id);
    }
}
