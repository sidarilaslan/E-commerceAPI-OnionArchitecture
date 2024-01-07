using E_commerceAPI.Application.ResponseTypes;
using E_E_commerceAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Products.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<CustomApiResponse<GetAllProductQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, CustomApiResponse<GetAllProductQueryResponse>>
        {
            private IProductService _productService;

            public GetAllProductQueryHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<CustomApiResponse<GetAllProductQueryResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                var productList = await _productService.GetAllProductAsync(request.Page, request.Size);
                return CustomApiResponse<GetAllProductQueryResponse>.Success(new() { Products = productList }, StatusCodes.Status200OK);
            }

        }
    }
}
