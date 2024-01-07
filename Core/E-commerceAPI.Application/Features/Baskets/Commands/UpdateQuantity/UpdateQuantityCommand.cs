using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Baskets.Commands.UpdateQuantity
{
    public class UpdateQuantityCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid BasketItemId { get; set; }
        public int Quantity { get; set; }

        public class UpdateQuantityCommandHandler : IRequestHandler<UpdateQuantityCommand, CustomApiResponse<Unit>>
        {
            private IBasketService _basketService;

            public UpdateQuantityCommandHandler(IBasketService basketService)
            {
                _basketService = basketService;
            }
            public async Task<CustomApiResponse<Unit>> Handle(UpdateQuantityCommand request, CancellationToken cancellationToken)
            {
                await _basketService.UpdateQuantityAsync(new()
                {
                    BasketItemId = request.BasketItemId,
                    Quantity = request.Quantity
                });

                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
