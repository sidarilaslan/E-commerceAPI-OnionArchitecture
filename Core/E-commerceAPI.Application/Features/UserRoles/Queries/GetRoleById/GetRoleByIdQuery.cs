using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.UserRoles.Queries.GetRoleById
{
    public class GetRoleByIdQuery : IRequest<CustomApiResponse<GetRoleByIdQueryResponse>>
    {
        public Guid RoleId { get; set; }
        public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, CustomApiResponse<GetRoleByIdQueryResponse>>
        {
            private IUserRoleService _roleService;

            public GetRoleByIdQueryHandler(IUserRoleService roleService)
            {
                _roleService = roleService;
            }
            public async Task<CustomApiResponse<GetRoleByIdQueryResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _roleService.GetRoleById(request.RoleId);
                return CustomApiResponse<GetRoleByIdQueryResponse>.Success(new() { RoleId = data.roleId, RoleName = data.roleName }, StatusCodes.Status200OK);
            }
        }
    }
}
