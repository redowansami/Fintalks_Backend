using AutoMapper;
using Fintalks.Common.Commands;
using Fintalks.Common.Constants;
using Fintalks.Common.DTOs;
using Fintalks.Common.Exceptions;
using Fintalks.Common.Models;
using Fintalks.DB.DBEntity;
using Fintalks.Repository.Repositories;

namespace Fintalks.Service.Services.UserService
{
    public class UserService(IUserRepository _userRepository, IMapper _mapper) : IUserSevice
    {
        public async Task<bool> IsUserNameTaken(string userName)
        {
            return await _userRepository.IsUserNameTaken(userName);
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            return await _userRepository.IsEmailTaken(email);
        }

        public async Task<IEnumerable<UserResponseDTO>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            var userModels = _mapper.Map<IEnumerable<User>>(users);
            var userResponses = _mapper.Map<IEnumerable<UserResponseDTO>>(userModels);
            return userResponses;
        }

        public async Task<UserResponseDTO> GetUserByID(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
                throw new NotFoundException("User", id);
            var userModel = _mapper.Map<User>(user);
            var userResponse = _mapper.Map<UserResponseDTO>(userModel);
            return userResponse;
        }

        public async Task<DBUser> GetDBUserByID(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
                throw new NotFoundException("User", id);
            return user;
        }

        public async Task DeleteUser(Guid id)
        {
            var UserToDelete = await GetDBUserByID(id);
            await _userRepository.DeleteUser(UserToDelete);
        }
    }
}
