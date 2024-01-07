using E_commerceAPI.Application.CustomAttributes;
using E_commerceAPI.Application.Enums;
using E_commerceAPI.Application.Features.Users.Commands.AssignRoleToUser;
using E_commerceAPI.Application.Features.Users.Commands.CreateUser;
using E_commerceAPI.Application.Features.Users.Commands.DeleteUser;
using E_commerceAPI.Application.Features.Users.Commands.HardDeleteUser;
using E_commerceAPI.Application.Features.Users.Commands.UpdateUser;
using E_commerceAPI.Application.Features.Users.Queries.GetAllUser;
using E_commerceAPI.Application.Features.Users.Queries.GetByIdUser;
using E_commerceAPI.Application.Features.Users.Queries.GetRolesToUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await Mediator.Send(createUserCommand);
            return Ok(response);
        }
        [HttpDelete("{UserId}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand deleteUserCommand)
        {
            var response = await Mediator.Send(deleteUserCommand);
            return Ok(response);
        }
        [HttpDelete("[action]/{UserId}")]
        [Authorize]
        [AuthorizeDefinition(ActionType = ActionType.Delete, Definition = "Hard Delete User", Menu = "Users")]
        public async Task<IActionResult> HardDelete([FromRoute] HardDeleteUserCommand hardDeleteUserCommand)
        {
            var response = await Mediator.Send(hardDeleteUserCommand);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommand updatePasswordCommand)
        {
            var response = await Mediator.Send(updatePasswordCommand);
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [AuthorizeDefinition(ActionType = ActionType.Read, Definition = "Get All Users", Menu = "Users")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserQuery getAllUserQuery)
        {
            var response = await Mediator.Send(getAllUserQuery);
            return Ok(response);
        }
        [HttpGet("[action]/{UserId}")]
        [Authorize]
        [AuthorizeDefinition(ActionType = ActionType.Read, Definition = "Get Roles To Users", Menu = "Users")]
        public async Task<IActionResult> GetRolesToUser([FromRoute] GetRolesToUserQuery getRolesToUserQuery)
        {
            var response = await Mediator.Send(getRolesToUserQuery);
            return Ok(response);
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserQuery getByIdUserQuery)
        {
            var response = await Mediator.Send(getByIdUserQuery);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize]
        [AuthorizeDefinition(ActionType = ActionType.Read, Definition = "Assign Role To User", Menu = "Users")]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserCommand assignRoleToUserCommand)
        {
            var response = await Mediator.Send(assignRoleToUserCommand);
            return Ok(response);
        }

    }
}
