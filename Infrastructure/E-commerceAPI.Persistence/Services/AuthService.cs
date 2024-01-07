using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Abstractions.Token;
using E_commerceAPI.Application.Constants;
using E_commerceAPI.Application.Dtos.User;
using E_commerceAPI.Application.Helpers;
using E_commerceAPI.Application.Middlewares.Exceptions;
using E_commerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_commerceAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;



        public AuthService(ITokenHandler tokenHandler, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, IUserService userService, IMailService mailService)
        {
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _mailService = mailService;
        }

        public async Task PasswordResetAsync(string email)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                resetToken = resetToken.UrlEnCode();
                await _mailService.SendPasswordResetMailAsync(email, resetToken);
            }
            else
                throw new Exception();
        }

        public async Task<Application.Dtos.Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Application.Dtos.Token token = await _tokenHandler.CreateAccessToken(user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.AccessTokenExpiration);
                return token;
            }
            else
                throw new NotFoundException(Messages.User.UserNotFound);
        }

        public async Task<bool> VerifyResetTokenAsync(string userId, string resetToken)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
            }
            return false;
        }
        public async Task<LoginUserResponseDto> LoginAsync(string email, string password)
        {
            AppUser user = await _userManager.FindByNameAsync(email);
            if (user == null)
                user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                throw new NotFoundException(Messages.User.UserNotFound);

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                Application.Dtos.Token token = await _tokenHandler.CreateAccessToken(user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.AccessTokenExpiration);

                UserDto userDto = new UserDto()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    LastName = user.LastName,
                    CreatedDate = user.CreatedDate,
                    IsActive = user.IsActive,
                    IsDeleted = user.IsDeleted,
                    ModifiedDate = user.ModifiedDate,
                    PhoneNumber = user.PhoneNumber
                };

                return new() { UserDto = userDto, Token = token };
            }
            else
            {
                throw new ValidationErrorException(Messages.User.IncorrectPassword);

            }



        }
    }
}
