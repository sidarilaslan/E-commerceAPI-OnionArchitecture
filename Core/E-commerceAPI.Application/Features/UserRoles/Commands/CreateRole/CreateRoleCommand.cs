using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.UserRoles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<CustomApiResponse<Unit>>
    {
        public string RoleName { get; set; }
        public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CustomApiResponse<Unit>>
        {
            private IUserRoleService _roleService;

            public CreateRoleCommandHandler(IUserRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
            {
                await _roleService.CreateRole(request.RoleName);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status201Created);
            }
        }


    }
}
