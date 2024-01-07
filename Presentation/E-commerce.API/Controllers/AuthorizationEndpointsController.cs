using E_commerceAPI.Application.Constants;
using E_commerceAPI.Application.CustomAttributes;
using E_commerceAPI.Application.Enums;
using E_commerceAPI.Application.Features.AuthorizationEndpoint.Commands;
using E_commerceAPI.Application.Features.AuthorizationEndpoint.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorizationEndpointsController : BaseController
    {
        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.AuthorizationEndpoints, ActionType = ActionType.Write, Definition = "Assign Role Endpoint")]
        public async Task<IActionResult> AssignRoleEndpoint(AssignRoleEndpointCommand assignRoleEndpointCommand)
        {
            assignRoleEndpointCommand.Type = typeof(Program);
            var response = await Mediator.Send(assignRoleEndpointCommand);
            return Ok(response);
        }
        [HttpPost("[action]")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.AuthorizationEndpoints, ActionType = ActionType.Write, Definition = "Assign Role Endpoint")]
        public async Task<IActionResult> GetRolesToEndpoint(GetRolesToEndpointQuery rolesToEndpointQuery)
        {
            var response = await Mediator.Send(rolesToEndpointQuery);
            return Ok(response);
        }
    }
}
