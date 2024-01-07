using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Users.Queries.GetRolesToUser
{
    public class GetRolesToUserQuery : IRequest<CustomApiResponse<GetRolesToUserQueryResponse>>
    {
        public Guid UserId { get; set; }
        public class GetRolesToUserQueryHandler : IRequestHandler<GetRolesToUserQuery, CustomApiResponse<GetRolesToUserQueryResponse>>
        {
            private IUserService _userService;
            public GetRolesToUserQueryHandler(IUserService userService)
            {
                _userService = userService;
            }
            public async Task<CustomApiResponse<GetRolesToUserQueryResponse>> Handle(GetRolesToUserQuery request, CancellationToken cancellationToken)
            {
                var userRoles = await _userService.GetRolesToUserAsync(request.UserId);

                return CustomApiResponse<GetRolesToUserQueryResponse>.Success(new() { UserRoles = userRoles }, StatusCodes.Status200OK);
            }
        }
    }
}
