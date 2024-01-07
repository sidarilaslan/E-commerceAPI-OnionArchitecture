using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid BrandId { get; set; }
        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, CustomApiResponse<Unit>>
        {

            private IBrandService _brandService;

            public DeleteBrandCommandHandler(IBrandService brandService)
            {
                _brandService = brandService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandService.DeleteBrandAsync(request.BrandId);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
