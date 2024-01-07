using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<CustomApiResponse<GetAllOrdersQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, CustomApiResponse<GetAllOrdersQueryResponse>>
        {
            private IOrderService _orderService;

            public GetAllOrdersQueryHandler(IOrderService orderService)
            {
                _orderService = orderService;
            }

            public async Task<CustomApiResponse<GetAllOrdersQueryResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                var data = await _orderService.GetAllOrdersAsync(request.Page, request.Size);
                return CustomApiResponse<GetAllOrdersQueryResponse>.Success(new() { Orders = data.Orders, TotalOrderCount = data.TotalOrderCount }, StatusCodes.Status200OK);
            }
        }
    }
}
