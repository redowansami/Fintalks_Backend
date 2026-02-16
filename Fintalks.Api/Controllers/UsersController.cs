using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fintalks.Common.Commands;
using Fintalks.Common.DTOs;
using Fintalks.DB;
using Fintalks.DB.DBEntity;
using Fintalks.Service.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fintalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> CreateUser(CreateUserCommand user)
        {
            var createUser = await _userService.CreateUser(user);
            return CreatedAtAction("GetDBUser", new { id = createUser.UserID }, createUser);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DBUser>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DBUser>> GetDBUser(Guid id)
        {
            var user = await _userService.GetUserByID(id);

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserResponseDTO>> UpdateUser(
            Guid id,
            UpdateUserCommand UpdateUser
        )
        {
            var UpdatedUser = await _userService.UpdateUser(id, UpdateUser);
            return Ok(UpdatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
