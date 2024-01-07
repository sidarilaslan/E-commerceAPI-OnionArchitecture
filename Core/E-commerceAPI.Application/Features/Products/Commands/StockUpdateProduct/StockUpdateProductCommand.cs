using E_commerceAPI.Application.ResponseTypes;
using E_E_commerceAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Products.Commands.UpdateProduct
{
    public class StockUpdateProductCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid ProductId { get; set; }
        public int StockQuantity { get; set; }


        public class StockUpdateProductCommandHandler : IRequestHandler<StockUpdateProductCommand, CustomApiResponse<Unit>>
        {
            private IProductService _productService;

            public StockUpdateProductCommandHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(StockUpdateProductCommand request, CancellationToken cancellationToken)
            {
                await _productService.StockUpdateToProductAsync(request.ProductId, request.StockQuantity);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }

    }
}