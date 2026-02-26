using Fintalks.Common.Commands;
using Fintalks.Common.DTOs;
using Fintalks.Service.Services.UserManagementService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fintalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController(IUserManagementService _userManagementService)
        : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> RegisterUser(RegisterUserCommand user)
        {
            var result = await _userManagementService.RegisterUser(user);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateUserProfile(
            Guid id,
            UpdateUserProfileCommand updateUserProfile
        )
        {
            var result = await _userManagementService.UpdateUserProfile(id, updateUserProfile);
            return result ? Ok("Updated") : BadRequest("Cannot be updated");
        }
    }
}
