using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Constants;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid UserId { get; set; }


        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, CustomApiResponse<Unit>>
        {
            private IUserService _userService;
            //private UserBusinessRules _userBusinessRules;

            public DeleteUserCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                //await _userBusinessRules.UserIdShouldExistWhenSelected(request.UserId);
                await _userService.DeleteUser(request.UserId);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK, Messages.User.UserDeleted);

            }
        }
    }
}
