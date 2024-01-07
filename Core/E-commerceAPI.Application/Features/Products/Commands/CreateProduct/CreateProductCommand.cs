using E_commerceAPI.Application.ResponseTypes;
using E_E_commerceAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CustomApiResponse<Unit>>
    {
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public float UnitPrice { get; set; }
        public string Description { get; set; }
        public Guid? BrandId { get; set; }
        public string Code { get; set; }
        public string Color { get; set; }
        public Guid? CategoryId { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CustomApiResponse<Unit>>
        {
            private IProductService _productService;

            public CreateProductCommandHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                await _productService.CreateProductAsync(new()
                {
                    Code = request.Code,
                    Description = request.Description,
                    UnitPrice = request.UnitPrice,
                    Color = request.Color,
                    Name = request.Name,
                    StockQuantity = request.StockQuantity,
                    BrandId = request.BrandId,
                    CategoryId = request.CategoryId,
                });
                return CustomApiResponse<Unit>.Success(StatusCodes.Status201Created);
            }
        }


    }
}
