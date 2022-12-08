using Berger.Application.Interfaces;
using Berger.Application.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Berger.Web.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : AbstractController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] UserRequestModel request)
        {
            try
            {
                await _userService.Create(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserRequestModel request)
        {
            try
            {
                var response = await _userService.Authenticate(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }
    }
}
