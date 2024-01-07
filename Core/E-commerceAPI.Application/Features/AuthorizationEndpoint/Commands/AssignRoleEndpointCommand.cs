using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.AuthorizationEndpoint.Commands
{
    public class AssignRoleEndpointCommand : IRequest<CustomApiResponse<Unit>>
    {
        public string Menu { get; set; }
        public string Code { get; set; }
        public string[] Roles { get; set; }
        public Type? Type { get; set; }

        public class AssignRoleEndpointCommandHandler : IRequestHandler<AssignRoleEndpointCommand, CustomApiResponse<Unit>>
        {
            private IAuthorizationEndpointService _authorizationEndpointService;

            public AssignRoleEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService)
            {
                _authorizationEndpointService = authorizationEndpointService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(AssignRoleEndpointCommand request, CancellationToken cancellationToken)
            {
                await _authorizationEndpointService.AssignRoleEndpointAsync(request.Roles, request.Menu, request.Code, request.Type);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
