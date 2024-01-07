using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Constants;
using E_commerceAPI.Application.Dtos.User;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CustomApiResponse<Unit>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CustomApiResponse<Unit>>
        {

            private IUserService _userService;
            public CreateUserCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {

                //todo mapping
                var createUser = new CreateUserDto()
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    Password = request.Password
                };
                await _userService.CreateAsync(createUser);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status201Created, Messages.User.UserCreated);
            }
        }
    }
}
