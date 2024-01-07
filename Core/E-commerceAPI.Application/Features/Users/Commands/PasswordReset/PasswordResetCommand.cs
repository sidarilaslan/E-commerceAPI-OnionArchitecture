using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Constants;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Users.Commands.PasswordReset
{
    public class PasswordResetCommand : IRequest<CustomApiResponse<Unit>>
    {
        public string Email { get; set; }

        public class PasswordResetCommandHandler : IRequestHandler<PasswordResetCommand, CustomApiResponse<Unit>>
        {
            private IAuthService _authService;

            public PasswordResetCommandHandler(IAuthService authService)
            {
                _authService = authService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(PasswordResetCommand request, CancellationToken cancellationToken)
            {
                await _authService.PasswordResetAsync(request.Email);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK, Messages.User.ForgotPassword);
            }
        }
    }
}
