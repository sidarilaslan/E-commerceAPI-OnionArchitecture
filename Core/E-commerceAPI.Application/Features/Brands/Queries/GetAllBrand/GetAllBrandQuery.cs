using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Brands.Queries.GetAllBrand
{
    public class GetAllBrandQuery : IRequest<CustomApiResponse<GetAllBrandQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, CustomApiResponse<GetAllBrandQueryResponse>>
        {
            IBrandService _brandService;

            public GetAllBrandQueryHandler(IBrandService brandService)
            {
                _brandService = brandService;
            }

            public async Task<CustomApiResponse<GetAllBrandQueryResponse>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
            {
                var listBrandDto = await _brandService.GetAllBrandAsync(request.Page, request.Size);
                return CustomApiResponse<GetAllBrandQueryResponse>.Success(new() { Brands = listBrandDto.Brands, TotalBrandCount = listBrandDto.TotalBrandCount }, StatusCodes.Status200OK);
            }
        }
    }
}
