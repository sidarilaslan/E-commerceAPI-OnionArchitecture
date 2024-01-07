using E_commerceAPI.Application.Dtos.Category;

namespace E_commerceAPI.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(Guid categoryId);
        Task HardDeleteCategoryAsync(Guid categoryId);
        Task<ListCategoryDto> GetAllCategoryAsync(int page, int size);
        Task<CategoryDto> GetCategoryByIdAsync(Guid categoryId);
    }
}
