using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CustomApiResponse<Unit>>
        {

            private ICategoryService _categoryService;

            public UpdateCategoryCommandHandler(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryService.UpdateCategoryAsync(new() { Name = request.Name, CategoryId = request.CategoryId });
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
