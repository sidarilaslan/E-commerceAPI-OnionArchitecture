using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Constants;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Users.Commands.UpdateUser
{
    public class UpdatePasswordCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string ResetToken { get; set; }



        public class UpdatePasswordHandler : IRequestHandler<UpdatePasswordCommand, CustomApiResponse<Unit>>
        {

            private IUserService _userService;
            //private UserBusinessRules _userBusinessRules;

            public UpdatePasswordHandler(IUserService userService)
            {
                _userService = userService;
                //_userBusinessRules = userBusinessRules;
            }

            public async Task<CustomApiResponse<Unit>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
            {
                //await _userBusinessRules.UserIdShouldExistWhenSelected(request.UserId);
                await _userService.UpdatePasswordAsync(request.UserId, request.Password, request.ResetToken);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK, Messages.User.ChangePassword);
            }
        }
    }
}
