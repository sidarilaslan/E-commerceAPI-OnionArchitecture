using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Brands.Queries.GetByIdBrand
{
    public class GetByIdBrandQuery : IRequest<CustomApiResponse<GetByIdBrandQueryResponse>>
    {
        public Guid BrandId { get; set; }
        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, CustomApiResponse<GetByIdBrandQueryResponse>>
        {
            private IBrandService _brandService;

            public GetByIdBrandQueryHandler(IBrandService brandService)
            {
                _brandService = brandService;
            }

            public async Task<CustomApiResponse<GetByIdBrandQueryResponse>> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                var brandDto = await _brandService.GetBrandByIdAsync(request.BrandId);
                return CustomApiResponse<GetByIdBrandQueryResponse>.Success(new() { Brand = brandDto }, StatusCodes.Status200OK);
            }
        }
    }
}
