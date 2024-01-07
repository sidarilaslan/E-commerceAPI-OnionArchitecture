using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Dtos.User;
using E_commerceAPI.Application.Features.Users.Rules;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Users.Queries.GetByIdUser
{
    public class GetByIdUserQuery : IRequest<CustomApiResponse<GetByIdUserQueryResponse>>
    {
        public Guid UserId { get; set; }

        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, CustomApiResponse<GetByIdUserQueryResponse>>
        {
            private IUserService _userService;
            private UserBusinessRules _userBusinessRules;
            public GetByIdUserQueryHandler(IUserService userService, UserBusinessRules userBusinessRules)
            {
                _userService = userService;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<CustomApiResponse<GetByIdUserQueryResponse>> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserIdShouldExistWhenSelected(request.UserId);

                var user = await _userService.GetByIdAsync(request.UserId);
                UserDto userDto = new()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CreatedDate = user.CreatedDate,
                    IsActive = user.IsActive,
                    IsDeleted = user.IsDeleted,
                    ModifiedDate = user.ModifiedDate,
                    PhoneNumber = user.PhoneNumber,
                };
                return CustomApiResponse<GetByIdUserQueryResponse>.Success(new() { User = userDto }, StatusCodes.Status200OK);
            }
        }
    }
}
