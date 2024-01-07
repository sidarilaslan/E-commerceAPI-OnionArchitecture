using E_commerceAPI.Application.Repositories.ProductRepository;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_commerceAPI.Application.Features.Products.Queries.GetProductImages
{
    public class GetProductImagesQuery : IRequest<CustomApiResponse<List<GetProductImagesQueryResponse>>>
    {
        public Guid ProductId { get; set; }
        public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQuery, CustomApiResponse<List<GetProductImagesQueryResponse>>>
        {
            private IProductReadRepository _productReadRepository;

            public GetProductImagesQueryHandler(IProductReadRepository productReadRepository)
            {
                _productReadRepository = productReadRepository;
            }

            private readonly string BaseUrl = "https://localhost:44353";
            //todo get from configration
            public async Task<CustomApiResponse<List<GetProductImagesQueryResponse>>> Handle(GetProductImagesQuery request, CancellationToken cancellationToken)
            {
                var product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
                    .FirstOrDefaultAsync(p => p.Id == request.ProductId);

                var result = product?.ProductImageFiles.Select(p => new GetProductImagesQueryResponse
                {
                    Path = $"{BaseUrl}/{p.Path}",
                    FileName = p.FileName,
                    Id = p.Id
                }).ToList();

                return CustomApiResponse<List<GetProductImagesQueryResponse>>.Success(result, StatusCodes.Status200OK);
            }
        }
    }
}
