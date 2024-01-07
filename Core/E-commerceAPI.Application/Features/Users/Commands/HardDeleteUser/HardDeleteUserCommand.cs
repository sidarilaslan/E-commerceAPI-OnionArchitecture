using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Constants;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Users.Commands.HardDeleteUser
{
    public class HardDeleteUserCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid UserId { get; set; }

        public class HardDeleteUserCommandHandler : IRequestHandler<HardDeleteUserCommand, CustomApiResponse<Unit>>
        {
            private IUserService _userService;
            //private UserBusinessRules _userBusinessRules;

            public HardDeleteUserCommandHandler(IUserService userService)
            {
                _userService = userService;
                //_userBusinessRules = userBusinessRules;
            }

            public async Task<CustomApiResponse<Unit>> Handle(HardDeleteUserCommand request, CancellationToken cancellationToken)
            {
                //await _userBusinessRules.UserIdShouldExistWhenSelected(request.UserId);
                await _userService.HardDeleteUser(request.UserId);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK, Messages.User.UserDeleted);
            }
        }
    }
}
