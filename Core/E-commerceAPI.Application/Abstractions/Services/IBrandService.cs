using E_commerceAPI.Application.Dtos.Brand;

namespace E_commerceAPI.Application.Abstractions.Services
{
    public interface IBrandService
    {
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(Guid brandId);
        Task HardDeleteBrandAsync(Guid brandId);
        Task<ListBrandDto> GetAllBrandAsync(int page, int size);
        Task<BrandDto> GetBrandByIdAsync(Guid brandId);
    }
}
