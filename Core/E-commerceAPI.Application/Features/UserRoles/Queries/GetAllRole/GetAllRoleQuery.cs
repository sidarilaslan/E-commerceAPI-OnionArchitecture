using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Features.UserRoles.Queries.GetAllRole;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.UserRoles.Queries.GetAllRoles
{
    public class GetAllRoleQuery : IRequest<CustomApiResponse<GetAllRoleQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, CustomApiResponse<GetAllRoleQueryResponse>>
        {
            private IUserRoleService _roleService;

            public GetAllRoleQueryHandler(IUserRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task<CustomApiResponse<GetAllRoleQueryResponse>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
            {
                var (datas, count) = _roleService.GetAllRoles(request.Page, request.Size);
                return CustomApiResponse<GetAllRoleQueryResponse>.Success(new() { Roles = datas, TotalRoleCount = count }, StatusCodes.Status200OK);
            }
        }
    }
}
