using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Users.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<CustomApiResponse<GetAllUserQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, CustomApiResponse<GetAllUserQueryResponse>>
        {

            private IUserService _userService;
            public GetAllUserQueryHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<CustomApiResponse<GetAllUserQueryResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                var userListDto = await _userService.GetAllUsersAsync(request.Page, request.Size);
                return CustomApiResponse<GetAllUserQueryResponse>.Success(new() { Users = userListDto.Users, TotalUserCount = userListDto.TotalUserCount }, StatusCodes.Status200OK);
            }
        }
    }
}
