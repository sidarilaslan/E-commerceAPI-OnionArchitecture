using E_commerceAPI.Application.CustomAttributes;
using E_commerceAPI.Application.Enums;
using E_commerceAPI.Application.Features.UserRoles.Commands.CreateRole;
using E_commerceAPI.Application.Features.UserRoles.Commands.DeleteRole;
using E_commerceAPI.Application.Features.UserRoles.Commands.UpdateRole;
using E_commerceAPI.Application.Features.UserRoles.Queries.GetAllRoles;
using E_commerceAPI.Application.Features.UserRoles.Queries.GetRoleById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserRolesController : BaseController
    {
        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Read, Definition = "Get All Roles", Menu = "Roles")]
        public async Task<IActionResult> GetRoles([FromQuery] GetAllRoleQuery getAllRoleQuery)
        {
            var response = await Mediator.Send(getAllRoleQuery);
            return Ok(response);
        }

        [HttpGet("{RoleId}")]
        [AuthorizeDefinition(ActionType = ActionType.Read, Definition = "Get Role By Id", Menu = "Roles")]
        public async Task<IActionResult> GetRoles([FromRoute] GetRoleByIdQuery getRoleByIdQuery)
        {
            var response = await Mediator.Send(getRoleByIdQuery);
            return Ok(response);
        }

        [HttpPost()]
        [AuthorizeDefinition(ActionType = ActionType.Write, Definition = "Create Role", Menu = "Roles")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand createRoleCommandRequest)
        {
            var response = await Mediator.Send(createRoleCommandRequest);
            return Ok(response);
        }

        [HttpPut("{RoleId}")]
        [AuthorizeDefinition(ActionType = ActionType.Update, Definition = "Update Role", Menu = "Roles")]
        public async Task<IActionResult> UpdateRole([FromBody, FromRoute] UpdateRoleCommand updateRoleCommandRequest)
        {
            var response = await Mediator.Send(updateRoleCommandRequest);
            return Ok(response);
        }

        [HttpDelete("[action]/{RoleId}")]
        [AuthorizeDefinition(ActionType = ActionType.Delete, Definition = "Hard Delete Role", Menu = "Roles")]
        public async Task<IActionResult> HardDeleteRole([FromRoute] DeleteRoleCommand deleteRoleCommandRequest)
        {
            var response = await Mediator.Send(deleteRoleCommandRequest);
            return Ok(response);
        }
    }
}
