using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Users.Commands.VerifyResetToken
{
    public class VerifyResetTokenCommand : IRequest<CustomApiResponse<VerifyResetTokenCommandResponse>>
    {
        public Guid UserId { get; set; }
        public string ResetToken { get; set; }

        public class VerifyResetTokenCommandHandler : IRequestHandler<VerifyResetTokenCommand, CustomApiResponse<VerifyResetTokenCommandResponse>>
        {
            private IAuthService _authService;

            public VerifyResetTokenCommandHandler(IAuthService authService)
            {
                _authService = authService;
            }

            public async Task<CustomApiResponse<VerifyResetTokenCommandResponse>> Handle(VerifyResetTokenCommand request, CancellationToken cancellationToken)
            {
                bool result = await _authService.VerifyResetTokenAsync(request.UserId.ToString(), request.ResetToken);
                return CustomApiResponse<VerifyResetTokenCommandResponse>.Success(new() { State = result }, StatusCodes.Status200OK);
            }
        }
    }
}
