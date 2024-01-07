using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid BrandId { get; set; }
        public string Name { get; set; }
        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, CustomApiResponse<Unit>>
        {
            private IBrandService _brandService;
            public UpdateBrandCommandHandler(IBrandService brandService)
            {
                _brandService = brandService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandService.UpdateBrandAsync(new() { BrandId = request.BrandId, Name = request.Name });
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
