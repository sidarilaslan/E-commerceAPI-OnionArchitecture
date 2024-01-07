using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Baskets.Commands.RemoveBasketItem
{
    public class RemoveBasketItemCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid BasketItemId { get; set; }

        public class RemoveBasketItemCommandHandler : IRequestHandler<RemoveBasketItemCommand, CustomApiResponse<Unit>>
        {
            private IBasketService _basketService;

            public RemoveBasketItemCommandHandler(IBasketService basketService)
            {
                _basketService = basketService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(RemoveBasketItemCommand request, CancellationToken cancellationToken)
            {
                await _basketService.RemoveBasketItemAsync(request.BasketItemId);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);

            }
        }
    }
}
