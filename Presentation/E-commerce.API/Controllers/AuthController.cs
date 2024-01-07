using E_commerceAPI.Application.Features.Users.Commands.LoginUser;
using E_commerceAPI.Application.Features.Users.Commands.PasswordReset;
using E_commerceAPI.Application.Features.Users.Commands.UpdateRefreshToken;
using E_commerceAPI.Application.Features.Users.Commands.VerifyResetToken;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
        {
            var response = await Mediator.Send(loginUserCommand);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommand refreshTokenLoginCommand)
        {
            var response = await Mediator.Send(refreshTokenLoginCommand);
            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommand passwordResetCommand)
        {
            var response = await Mediator.Send(passwordResetCommand);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommand verifyResetTokenCommand)
        {
            var response = await Mediator.Send(verifyResetTokenCommand);
            return Ok(response);
        }
    }
}
