using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Features.Categories.Queries.GetAllCategory
{
    public class GetAllCategoryQuery : IRequest<CustomApiResponse<GetAllCategoryQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, CustomApiResponse<GetAllCategoryQueryResponse>>
        {
            private ICategoryService _categoryService;

            public GetAllCategoryQueryHandler(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }


            public async Task<CustomApiResponse<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
            {
                var data = await _categoryService.GetAllCategoryAsync(request.Page, request.Size);
                return CustomApiResponse<GetAllCategoryQueryResponse>.Success(new() { Categories = data.Categories, TotalCategoryCount = data.TotalCategoryCount }, StatusCodes.Status200OK);
            }
        }
    }
}
