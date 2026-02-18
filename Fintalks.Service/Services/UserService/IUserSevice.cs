using Fintalks.Common.Commands;
using Fintalks.Common.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Fintalks.Service.Services.UserService
{
    public interface IUserSevice
    {
        public Task<CreateUserResponseDTO> CreateUser(CreateUserCommand createUser);

        public Task<IEnumerable<UserResponseDTO>> GetUsers();

        public Task<UserResponseDTO> GetUserByID(Guid id);

        public Task<UserResponseDTO> UpdateUser(Guid id, UpdateUserCommand UpdateUser);

        public Task DeleteUser(Guid id);
    }
}
