using E_commerceAPI.Application.Repositories.ProductRepository;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_commerceAPI.Application.Features.Products.Commands.RemoveProductImage
{
    public class RemoveProductImageCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid ProductId { get; set; }
        public Guid ImageId { get; set; }

        public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommand, CustomApiResponse<Unit>>
        {

            private IProductReadRepository _productReadRepository;
            private IProductWriteRepository _productWriteRepository;
            public RemoveProductImageCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
            {
                _productWriteRepository = productWriteRepository;
                _productReadRepository = productReadRepository;
            }
            public async Task<CustomApiResponse<Unit>> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
            {
                var product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
                 .FirstOrDefaultAsync(p => p.Id == request.ProductId);

                var productImageFile = product?.ProductImageFiles.FirstOrDefault(p => p.Id == request.ImageId);

                if (productImageFile != null)
                    product?.ProductImageFiles.Remove(productImageFile);

                await _productWriteRepository.SaveAsync();
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);

            }
        }
    }
}
