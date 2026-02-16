using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Fintalks.Api.Exceptions;
using Fintalks.Common.Commands;
using Fintalks.Common.DTOs;
using Fintalks.Common.Models;
using Fintalks.DB.DBEntity;
using Fintalks.Repository.Repositories.UserRepository;

namespace Fintalks.Service.Services.UserService
{
    public class UserService(IUserRepository _userRepository, IMapper _mapper) : IUserSevice
    {
        public async Task<UserResponseDTO> CreateUser(CreateUserCommand createUser)
        {
            var user = _mapper.Map<User>(createUser);
            var DBuser = _mapper.Map<DBUser>(user);
            var createdUser = await _userRepository.CreateUser(DBuser);
            var userResponse = _mapper.Map<User>(createdUser);

            return _mapper.Map<UserResponseDTO>(userResponse);
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
            {
                throw new NotFoundException("User", id);
            }
            var userModel = _mapper.Map<User>(user);
            var userResponse = _mapper.Map<UserResponseDTO>(userModel);
            return userResponse;
        }

        public async Task<DBUser> GetDBUserByID(Guid id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<UserResponseDTO> UpdateUser(Guid id, UpdateUserCommand UpdateUser)
        {
            var UserToUpdate = await GetDBUserByID(id);
            var user = _mapper.Map(UpdateUser, UserToUpdate);
            var updatedUser = await _userRepository.UpdateUser(id, user);
            var userModel = _mapper.Map<User>(updatedUser);
            return _mapper.Map<UserResponseDTO>(userModel);
        }

        public async Task DeleteUser(Guid id)
        {
            var UserToDelete = await GetDBUserByID(id);
            await _userRepository.DeleteUser(UserToDelete);
        }
    }
}
