using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<CustomApiResponse<Unit>>
    {
        public Guid CategoryId { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CustomApiResponse<Unit>>
        {
            private ICategoryService _categoryService;

            public DeleteCategoryCommandHandler(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }



            public async Task<CustomApiResponse<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryService.DeleteCategoryAsync(request.CategoryId);
                return CustomApiResponse<Unit>.Success(StatusCodes.Status200OK);
            }
        }
    }
}
