using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Brands.Commands.HardDeleteBrand
{
    public class HardDeleteBrandCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid BrandId { get; set; }
        public class HardDeleteBrandCommandHandler : IRequestHandler<HardDeleteBrandCommand, CustomApiResponse<Unit>>
        {
            private IBrandService _brandService;

            public HardDeleteBrandCommandHandler(IBrandService brandService)
            {
                _brandService = brandService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(HardDeleteBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandService.HardDeleteBrandAsync(request.BrandId);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
