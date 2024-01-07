using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.UserRoles.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest<CustomApiResponse<Unit>>
    {
        public string RoleId { get; set; }
        public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, CustomApiResponse<Unit>>
        {
            private IUserRoleService _roleService;

            public DeleteRoleCommandHandler(IUserRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
            {
                await _roleService.HardDeleteRole(request.RoleId);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
