using E_commerceAPI.Application.Abstractions.Token;
using E_commerceAPI.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E_commerceAPI.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        public IConfiguration _configuration { get; }
        private AccessTokenOptions _accessTokenOptions;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _accessTokenOptions = _configuration.GetSection("AccessTokenOptions").Get<AccessTokenOptions>();
        }

        public async Task<Application.Dtos.Token> CreateAccessToken(AppUser user)
        {
            Application.Dtos.Token token = new();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_accessTokenOptions.SecurityKey));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);


            token.AccessTokenExpiration = DateTime.Now.AddMinutes(_accessTokenOptions.AccessTokenExpiration);
            token.RefreshTokenExpiration = DateTime.Now.AddMinutes(_accessTokenOptions.RefreshTokenExpiration);

            JwtSecurityToken jwtSecurityToken = new(
                audience: _accessTokenOptions.Audience,
                issuer: _accessTokenOptions.Issuer,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                expires: token.AccessTokenExpiration,
                claims: new List<Claim>
                {
                    new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new(ClaimTypes.NameIdentifier, user.Id.ToString())
                }
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        private string CreateRefreshToken()
        {
            byte[] bytes = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }
    }
}
