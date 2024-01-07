using E_commerceAPI.Application.Constants;
using E_commerceAPI.Application.Middlewares.Exceptions;
using E_commerceAPI.Application.Repositories.UserRepository;

namespace E_commerceAPI.Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserReadRepository _userReadRepository;

        public UserBusinessRules(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task UserIdShouldExistWhenSelected(Guid UserId)
        {
            var result = await _userReadRepository.GetSingleAsync(b => b.Id == UserId);
            if (result is null) throw new NotFoundException(Messages.User.UserNotFound);
        }

    }
}
