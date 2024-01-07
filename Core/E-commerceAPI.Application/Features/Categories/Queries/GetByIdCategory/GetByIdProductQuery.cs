using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Categories.Queries.GetByIdCategory
{
    public class GetByIdCategoryQuery : IRequest<CustomApiResponse<GetByIdCategoryQueryResponse>>
    {
        public Guid CategoryId { get; set; }
        public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CustomApiResponse<GetByIdCategoryQueryResponse>>
        {
            private ICategoryService _categoryService;

            public GetByIdCategoryQueryHandler(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<CustomApiResponse<GetByIdCategoryQueryResponse>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
            {
                var categoryDto = await _categoryService.GetCategoryByIdAsync(request.CategoryId);
                return CustomApiResponse<GetByIdCategoryQueryResponse>.Success(new() { Category = categoryDto }, StatusCodes.Status200OK);
            }
        }
    }
}
