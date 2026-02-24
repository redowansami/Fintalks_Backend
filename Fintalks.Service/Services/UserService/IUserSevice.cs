using Fintalks.Common.Commands;
using Fintalks.Common.DTOs;
using Fintalks.DB.DBEntity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Fintalks.Service.Services.UserService
{
    public interface IUserSevice
    {
        public Task<DBUser> CreateUser(CreateUserCommand createUser);

        public Task<IEnumerable<UserResponseDTO>> GetUsers();

        public Task<UserResponseDTO> GetUserByID(Guid id);

        public Task<UserResponseDTO> UpdateUser(Guid id, UpdateUserCommand UpdateUser);

        public Task DeleteUser(Guid id);
    }
}
