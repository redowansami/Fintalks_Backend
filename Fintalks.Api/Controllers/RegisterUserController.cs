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
        public async Task<ActionResult<string>> CreateUser(RegisterUserCommand user)
        {
            var result = await _userManagementService.CreateUser(user);
            return result;
        }
    }
}
