using E_commerceAPI.Application.Dtos.Product;
using E_commerceAPI.Application.ResponseTypes;
using E_E_commerceAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductQuery : IRequest<CustomApiResponse<GetByIdProductQueryResponse>>
    {
        public Guid ProductId { get; set; }

        public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, CustomApiResponse<GetByIdProductQueryResponse>>
        {
            private IProductService _productService;

            public GetByIdProductQueryHandler(IProductService productService)
            {
                _productService = productService;
            }
            public async Task<CustomApiResponse<GetByIdProductQueryResponse>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
            {
                ProductDto product = await _productService.GetProductByIdAsync(request.ProductId);

                return CustomApiResponse<GetByIdProductQueryResponse>.Success(new() { Product = product }, StatusCodes.Status200OK);
            }
        }
    }
}
