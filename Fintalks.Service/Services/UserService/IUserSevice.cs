using Fintalks.Common.Commands;
using Fintalks.Common.DTOs;
using Fintalks.DB.DBEntity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Fintalks.Service.Services.UserService
{
    public interface IUserSevice
    {
        public Task<bool> IsUserNameTaken(string userName);
        public Task<bool> IsEmailTaken(string email);
        public Task<IEnumerable<UserResponseDTO>> GetUsers();
        public Task<UserResponseDTO> GetUserByID(Guid id);
        public Task<DBUser> GetDBUserByID(Guid id);
        public Task DeleteUser(Guid id);
    }
}
