using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.UserRoles.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, CustomApiResponse<Unit>>
        {
            private IUserRoleService _roleService;

            public UpdateRoleCommandHandler(IUserRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
            {
                var result = await _roleService.UpdateRole(request.RoleId, request.RoleName);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
