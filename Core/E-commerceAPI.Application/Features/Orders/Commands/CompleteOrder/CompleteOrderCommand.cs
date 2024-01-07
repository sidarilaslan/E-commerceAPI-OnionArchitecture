using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Orders.Commands.CompleteOrder
{
    public class CompleteOrderCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid OrderId { get; set; }

        public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand, CustomApiResponse<Unit>>
        {
            private IOrderService _orderService;
            public CompleteOrderCommandHandler(IOrderService orderService)
            {
                _orderService = orderService;
            }
            public async Task<CustomApiResponse<Unit>> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
            {
                await _orderService.CompleteOrderAsync(request.OrderId);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
