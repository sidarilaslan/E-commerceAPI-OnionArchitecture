using E_commerceAPI.Application.Abstractions.Services;
using MediatR;

namespace E_commerceAPI.Application.Features.Users.Commands.UpdateRefreshToken
{
    public class RefreshTokenLoginCommand : IRequest<Dtos.Token>
    {
        public string RefreshToken { get; set; }
        public class RefreshTokenLoginHandler : IRequestHandler<RefreshTokenLoginCommand, Dtos.Token>
        {
            private IAuthService _authService;
            public RefreshTokenLoginHandler(IAuthService authService)
            {
                _authService = authService;
            }

            public async Task<Dtos.Token> Handle(RefreshTokenLoginCommand request, CancellationToken cancellationToken)
            {
                return await _authService.RefreshTokenLoginAsync(request.RefreshToken);

            }
        }

    }
}
