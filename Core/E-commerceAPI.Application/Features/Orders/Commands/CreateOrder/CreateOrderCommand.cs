using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CustomApiResponse<Unit>>
    {
        public string Description { get; set; }
        public string Address { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CustomApiResponse<Unit>>
        {
            private IOrderService _orderService;
            private IBasketService _basketService;

            public CreateOrderCommandHandler(IOrderService orderService, IBasketService basketService)
            {
                _orderService = orderService;
                _basketService = basketService;
            }
            public async Task<CustomApiResponse<Unit>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                Guid basketId = _basketService.GetUserActiveBasket.Id;
                await _orderService.CreateOrderAsync(new()
                {
                    Address = request.Address,
                    Description = request.Description,
                    BasketId = basketId
                });

                return CustomApiResponse<Unit>.Success(StatusCodes.Status201Created);
            }
        }
    }
}
