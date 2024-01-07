using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Constants;
using E_commerceAPI.Application.Dtos;
using E_commerceAPI.Application.Dtos.User;
using E_commerceAPI.Application.Helpers;
using E_commerceAPI.Application.Middlewares.Exceptions;
using E_commerceAPI.Application.Repositories.EndpointRepository;
using E_commerceAPI.Application.Repositories.UserRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Domain.Entities.Identity;
using E_commerceAPI.Infrastructure.Services.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace E_commerceAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private IUserWriteRepository _userWriteRepository;
        private IUserReadRepository _userReadRepository;
        private AccessTokenOptions _accessTokenOptions;
        private IEndpointReadRepository _endpointReadRepository;
        public IConfiguration _configuration { get; }

        public UserService(UserManager<AppUser> userManager, IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository, IConfiguration configuration, IEndpointReadRepository endpointReadRepository)
        {
            _userManager = userManager;
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
            _configuration = configuration;
            _accessTokenOptions = _configuration.GetSection("AccessTokenOptions").Get<AccessTokenOptions>();
            _endpointReadRepository = endpointReadRepository;
        }

        public async Task CreateAsync(CreateUserDto createUserDto)
        {

            IdentityResult result = await _userManager.CreateAsync(new()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                PhoneNumber = createUserDto.PhoneNumber,
                UserName = createUserDto.Email
            }, createUserDto.Password);

            if (!result.Succeeded)
            {
                List<ValidationError> validationErrors = result.Errors.Select(error => new ValidationError
                {
                    PropertyName = error.Code,
                    ErrorMessage = error.Description
                }).ToList();
                throw new ValidationErrorsException(Messages.User.ValidationError, validationErrors);

            }

        }

        public async Task DeleteUser(Guid userId)
        {
            var user = await _userReadRepository.GetByIdAsync(userId.ToString());
            if (user is null)
                throw new NotFoundException(Messages.User.UserNotFound);

            user.IsDeleted = true;

            await _userWriteRepository.SaveAsync();
        }


        public async Task HardDeleteUser(Guid userId)
        {
            bool result = await _userWriteRepository.RemoveAsync(userId.ToString());

            if (!result)
                throw new NotFoundException(Messages.User.UserNotFound);
            await _userWriteRepository.SaveAsync();
        }
        public async Task UpdatePasswordAsync(Guid userId, string password, string resetToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();

                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, password);
                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user);
                else
                    throw new ValidationErrorException(Messages.User.PasswordUpdateFailed);
            }
            else
                throw new NotFoundException(Messages.User.UserNotFound);
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate = accessTokenDate.AddMinutes(_accessTokenOptions.RefreshTokenExpiration);
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                List<ValidationError> validationErrors = result.Errors.Select(error => new ValidationError
                {
                    PropertyName = error.Code,
                    ErrorMessage = error.Description
                }).ToList();
                throw new ValidationErrorsException(Messages.User.ValidationError, validationErrors);

            }
        }

        public async Task<AppUser> GetByIdAsync(Guid userId)
        {
            var user = await _userReadRepository.GetByIdAsync(userId.ToString());
            if (user is null)
                throw new NotFoundException(Messages.User.UserNotFound);

            return user;
        }

        public async Task<ListUserDto> GetAllUsersAsync(int page, int size)
        {
            var users = await _userManager.Users
                 .Skip(page * size)
                 .Take(size)
                 .ToListAsync();

            var userDto = users.Select(user => new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                CreatedDate = user.CreatedDate,

            }).ToList();

            return new() { TotalUserCount = users.Count, Users = userDto };
        }

        public async Task AssignRoleToUserAsnyc(Guid userId, string[] roles)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);

                var res = await _userManager.AddToRolesAsync(user, roles);
                Console.WriteLine(res);
            }
        }
        public async Task<string[]> GetRolesToUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return userRoles.ToArray();
            }
            return new string[] { };
        }

        public async Task<bool> HasRolePermissionToEndpointAsync(Guid userId, string code)
        {
            var userRoles = await GetRolesToUserAsync(userId);

            if (!userRoles.Any())
                return false;

            Endpoint? endpoint = await _endpointReadRepository.Table
                     .Include(e => e.Roles)
                     .FirstOrDefaultAsync(e => e.Code == code);

            if (endpoint == null)
                return false;

            var hasRole = false;
            var endpointRoles = endpoint.Roles.Select(r => r.Name);


            foreach (var userRole in userRoles)
            {
                foreach (var endpointRole in endpointRoles)
                    if (userRole == endpointRole)
                        return true;
            }

            return false;
        }
    }
}
