using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Repositories.ProductImageFileRepository;
using E_commerceAPI.Application.Repositories.ProductRepository;
using E_commerceAPI.Application.ResponseTypes;
using E_commerceAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Products.Commands.UploadProductImageFile
{
    public class UploadProductImageCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid ProductId { get; set; }
        public IFormFileCollection Files { get; set; }

        public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommand, CustomApiResponse<Unit>>
        {
            private IProductReadRepository _productReadRepository;
            private IProductImageFileWriteRepository _productImageFileWriteRepository;
            private IFileHelper _fileHelper;

            public UploadProductImageCommandHandler(IFileHelper fileHelper, IProductImageFileWriteRepository productImageFileWriteRepository, IProductReadRepository productReadRepository)
            {
                _fileHelper = fileHelper;
                _productImageFileWriteRepository = productImageFileWriteRepository;
                _productReadRepository = productReadRepository;
            }

            public async Task<CustomApiResponse<Unit>> Handle(UploadProductImageCommand request, CancellationToken cancellationToken)
            {
                List<(string fileName, string pathOrContainerName)> result = await _fileHelper.UploadFileAsync("products-images", request.Files);

                var product = await _productReadRepository.GetByIdAsync(request.ProductId.ToString());


                await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new ProductImageFile
                {
                    FileName = r.fileName,
                    Path = r.pathOrContainerName,
                    Products = new List<Product>() { product }
                }).ToList());

                await _productImageFileWriteRepository.SaveAsync();
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);

            }
        }
    }
}
