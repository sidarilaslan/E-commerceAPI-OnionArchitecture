using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.CustomAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;
using System.Security.Claims;

namespace E_commerceAPI.Infrastructure.Filters
{
    public class RolePermissionFilter : IAsyncActionFilter
    {
        private IUserService _userService;

        public RolePermissionFilter(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var name = context.HttpContext.User.Identity?.Name;
            string userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ;
            ;
            if (!string.IsNullOrEmpty(name) && name.Equals("sidar ilaslan") && userId != null && userId.Equals("cf1149f6-885c-41dc-28d3-08dc0d2d0c05"))
            {
                var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
                var attribute = descriptor.MethodInfo.GetCustomAttribute(typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;

                var httpAttribute = descriptor.MethodInfo.GetCustomAttribute(typeof(HttpMethodAttribute)) as HttpMethodAttribute;

                var code = $"{(httpAttribute != null ? httpAttribute.HttpMethods.First() : HttpMethods.Get)}.{attribute?.ActionType}.{attribute?.Definition.Replace(" ", "")}";

                var hasRole = await _userService.HasRolePermissionToEndpointAsync(new Guid(userId), code);

                if (!hasRole)
                    context.Result = new UnauthorizedResult();
                else
                    await next();
            }
            else
                await next();
        }
    }
}
