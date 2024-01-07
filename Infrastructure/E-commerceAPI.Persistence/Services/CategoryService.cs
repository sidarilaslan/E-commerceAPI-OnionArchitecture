using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Dtos.Category;
using E_commerceAPI.Application.Repositories.CategoryRepository;
using E_commerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_commerceAPI.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryWriteRepository _categoryWriteRepository;
        private ICategoryReadRepository _categoryReadRepository;

        public CategoryService(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }



        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = new Category()
            {
                Name = createCategoryDto.Name,
            };
            await _categoryWriteRepository.AddAsync(category);
            await _categoryWriteRepository.SaveAsync();
        }

        public async Task DeleteCategoryAsync(Guid categoryId)
        {
            var category = await _categoryReadRepository.GetByIdAsync(categoryId.ToString());
            category.IsDeleted = true;

            await _categoryWriteRepository.SaveAsync();
        }

        public async Task<ListCategoryDto> GetAllCategoryAsync(int page, int size)
        {
            var categoryList = await _categoryReadRepository.Table.Select(category => new CategoryDto
            {
                CategoryId = category.Id,
                Name = category.Name
            }).Skip(page * size).Take(size).ToListAsync();
            return new() { Categories = categoryList, TotalCategoryCount = categoryList.Count };
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid categoryId)
        {
            var category = await _categoryReadRepository.GetByIdAsync(categoryId.ToString());
            return new CategoryDto()
            {
                CategoryId = category.Id,
                Name = category.Name
            };
        }

        public async Task HardDeleteCategoryAsync(Guid categoryId)
        {
            await _categoryWriteRepository.RemoveAsync(categoryId.ToString());
            await _categoryWriteRepository.SaveAsync();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categoryReadRepository.GetByIdAsync(updateCategoryDto.CategoryId.ToString());
            category.Name = updateCategoryDto.Name;
            _categoryWriteRepository.Update(category);
            await _categoryWriteRepository.SaveAsync();
        }

    }
}
