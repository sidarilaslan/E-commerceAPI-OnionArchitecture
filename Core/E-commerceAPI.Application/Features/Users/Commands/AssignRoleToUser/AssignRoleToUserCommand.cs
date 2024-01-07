using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Users.Commands.AssignRoleToUser
{
    public class AssignRoleToUserCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid UserId { get; set; }
        public string[] Roles { get; set; }
        public class AssignRoleToUserCommandHandler : IRequestHandler<AssignRoleToUserCommand, CustomApiResponse<Unit>>
        {
            private IUserService _userService;

            public AssignRoleToUserCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
            {
                await _userService.AssignRoleToUserAsnyc(request.UserId, request.Roles);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
