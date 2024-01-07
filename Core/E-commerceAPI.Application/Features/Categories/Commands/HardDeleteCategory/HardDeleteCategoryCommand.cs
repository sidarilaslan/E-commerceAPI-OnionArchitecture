using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Categories.Commands.HardDeleteCategory
{
    public class HardDeleteCategoryCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid CategoryId { get; set; }

        public class HardDeleteCategoryCommandHandler : IRequestHandler<HardDeleteCategoryCommand, CustomApiResponse<Unit>>
        {
            private ICategoryService _categoryService;

            public HardDeleteCategoryCommandHandler(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(HardDeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryService.HardDeleteCategoryAsync(request.CategoryId);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
