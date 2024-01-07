using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Baskets.Queries.GetBasketItems
{
    public class GetBasketItemsQuery : IRequest<CustomApiResponse<List<GetBasketItemsQueryResponse>>>
    {
        public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQuery, CustomApiResponse<List<GetBasketItemsQueryResponse>>>
        {
            private IBasketService _basketService;

            public GetBasketItemsQueryHandler(IBasketService basketService)
            {
                _basketService = basketService;
            }

            public async Task<CustomApiResponse<List<GetBasketItemsQueryResponse>>> Handle(GetBasketItemsQuery request, CancellationToken cancellationToken)
            {
                var basketItems = await _basketService.GetBasketItemsAsync();

                return CustomApiResponse<List<GetBasketItemsQueryResponse>>.Success(basketItems.Select(b => new GetBasketItemsQueryResponse
                {
                    BasketItemId = b.Id.ToString(),
                    Name = b.Product.Name,
                    Price = b.Product.UnitPrice,
                    Quantity = b.Quantity
                }).ToList(), StatusCodes.Status200OK);

            }
        }
    }
}
