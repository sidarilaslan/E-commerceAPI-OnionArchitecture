using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.AuthorizationEndpoint.Queries
{
    public class GetRolesToEndpointQuery : IRequest<CustomApiResponse<GetRolesToEndpointQueryResponse>>
    {
        public string Menu { get; set; }
        public string Code { get; set; }

        public class GetRolesToEndpointQueryHandler : IRequestHandler<GetRolesToEndpointQuery, CustomApiResponse<GetRolesToEndpointQueryResponse>>
        {
            private IAuthorizationEndpointService _authorizationEndpointService;
            public GetRolesToEndpointQueryHandler(IAuthorizationEndpointService authorizationEndpointService)
            {
                _authorizationEndpointService = authorizationEndpointService;
            }
            public async Task<CustomApiResponse<GetRolesToEndpointQueryResponse>> Handle(GetRolesToEndpointQuery request, CancellationToken cancellationToken)
            {
                var roles = await _authorizationEndpointService.GetAssignedRolesToEndpointAsync(request.Code, request.Menu);
                return CustomApiResponse<GetRolesToEndpointQueryResponse>.Success(new() { Roles = roles }, StatusCodes.Status200OK);
            }
        }
    }
}
