using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.CustomAttributes;
using E_commerceAPI.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppServicesController : BaseController
    {
        private IAppService _appService;

        public AppServicesController(IAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("[action]")]
        [AuthorizeDefinition(ActionType = ActionType.Read, Definition = "Get Authorize Definition Endpoints", Menu = "App Services")]
        public IActionResult GetAuthorizeDefinitionEndpoints()
        {
            var result = _appService.GetAuthorizeDefinitionEndpoints(typeof(Program));
            var resultList = result.Select(item => new { Name = item.Name, Actions = item.Actions }).ToList();
            return Ok(resultList);
        }
    }
}
