using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Baskets.Commands.AddItemToBasket
{
    public class AddItemToBasketCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommand, CustomApiResponse<Unit>>
        {
            private IBasketService _basketService;

            public AddItemToBasketCommandHandler(IBasketService basketService)
            {
                _basketService = basketService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
            {
                await _basketService.AddItemToBasketAsync(new()
                {
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                });
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
