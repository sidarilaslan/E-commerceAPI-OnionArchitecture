using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<CustomApiResponse<GetOrderByIdQueryResponse>>
    {
        public Guid OrderId { get; set; }
        public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, CustomApiResponse<GetOrderByIdQueryResponse>>
        {
            private IOrderService _orderService;

            public GetOrderByIdQueryHandler(IOrderService orderService)
            {
                _orderService = orderService;
            }
            public async Task<CustomApiResponse<GetOrderByIdQueryResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _orderService.GetOrderByIdAsync(request.OrderId);

                return CustomApiResponse<GetOrderByIdQueryResponse>.Success(new()
                {
                    OrderId = data.OrderId,
                    Address = data.Address,
                    BasketItems = data.BasketItems,
                    CreatedDate = data.CreatedDate,
                    Description = data.Description,
                    Completed = data.Completed
                }, StatusCodes.Status200OK);
            }
        }
    }
}
