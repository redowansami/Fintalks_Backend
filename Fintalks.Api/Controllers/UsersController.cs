using Fintalks.Common.Commands;
using Fintalks.Common.DTOs;
using Fintalks.Service.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Fintalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserSevice _userService) : ControllerBase
    {
        //[HttpPost]
        //public async Task<ActionResult<CreateUserResponseDTO>> CreateUser(CreateUserCommand user)
        //{
        //    var createUser = await _userService.CreateUser(user);
        //    return CreatedAtAction(nameof(GetUserByID), new { id = createUser.UserID }, createUser);
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTO>> GetUserByID(Guid id)
        {
            var user = await _userService.GetUserByID(id);
            return Ok(user);
        }

        //[HttpPut]
        //public async Task<ActionResult<UserResponseDTO>> UpdateUser(
        //    Guid id,
        //    UpdateUserCommand UpdateUser
        //)
        //{
        //    var UpdatedUser = await _userService.UpdateUser(id, UpdateUser);
        //    return Ok(UpdatedUser);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
