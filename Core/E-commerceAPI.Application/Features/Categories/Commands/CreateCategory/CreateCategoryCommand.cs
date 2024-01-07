using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CustomApiResponse<Unit>>
    {
        public string Name { get; set; }
        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CustomApiResponse<Unit>>
        {
            private ICategoryService _categoryService;

            public CreateCategoryCommandHandler(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<CustomApiResponse<Unit>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {

                await _categoryService.CreateCategoryAsync(new() { Name = request.Name });
                return CustomApiResponse<Unit>.Success(StatusCodes.Status201Created);
            }
        }
    }
}
