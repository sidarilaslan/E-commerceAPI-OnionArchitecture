using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Dtos.User;
using MediatR;

namespace E_commerceAPI.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResponse>
        {
            private IAuthService _authService;

            public LoginUserCommandHandler(IAuthService authService)
            {
                _authService = authService;
            }

            public async Task<LoginUserCommandResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                LoginUserResponseDto loginUserResponse = await _authService.LoginAsync(request.Email, request.Password);

                return new() { Token = loginUserResponse.Token, User = loginUserResponse.UserDto };

            }
        }
    }
}
