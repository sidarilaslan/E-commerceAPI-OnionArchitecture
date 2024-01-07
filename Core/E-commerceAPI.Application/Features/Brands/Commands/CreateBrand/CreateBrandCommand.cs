using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<CustomApiResponse<Unit>>
    {
        public string Name { get; set; }
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CustomApiResponse<Unit>>
        {
            private IBrandService _brandService;

            public CreateBrandCommandHandler(IBrandService brandService)
            {
                _brandService = brandService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandService.CreateBrandAsync(new() { Name = request.Name });
                return CustomApiResponse<Unit>.Success(StatusCodes.Status201Created);
            }
        }
    }
}
