using E_commerceAPI.Application.ResponseTypes;
using E_E_commerceAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid ProductId { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<DeleteProductCommand, CustomApiResponse<Unit>>
        {
            private IProductService _productService;

            public CreateProductCommandHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                await _productService.DeleteProductAsync(request.ProductId);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);

            }
        }
    }
}
