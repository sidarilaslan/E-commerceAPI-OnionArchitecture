using E_commerceAPI.Application.ResponseTypes;
using E_E_commerceAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Products.Commands.HardDeleteProduct
{
    public class HardDeleteProductCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid ProductId { get; set; }
        public class HardDeleteProductHandler : IRequestHandler<HardDeleteProductCommand, CustomApiResponse<Unit>>
        {
            private IProductService _productService;
            public HardDeleteProductHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(HardDeleteProductCommand request, CancellationToken cancellationToken)
            {
                await _productService.HardDeleteProductAsync(request.ProductId);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }

    }
}
