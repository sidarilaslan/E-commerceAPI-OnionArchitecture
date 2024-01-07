using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Dtos.Brand;
using E_commerceAPI.Application.Repositories.BrandRepository;
using E_commerceAPI.Domain.Entities;

namespace E_commerceAPI.Persistence.Services
{
    public class BrandService : IBrandService
    {
        private IBrandWriteRepository _brandWriteRepository;
        private IBrandReadRepository _brandReadRepository;

        public BrandService(IBrandWriteRepository brandWriteRepository, IBrandReadRepository brandReadRepository)
        {
            _brandWriteRepository = brandWriteRepository;
            _brandReadRepository = brandReadRepository;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var brand = new Brand()
            {
                Name = createBrandDto.Name,
            };
            await _brandWriteRepository.AddAsync(brand);
            await _brandWriteRepository.SaveAsync();
        }

        public async Task DeleteBrandAsync(Guid brandId)
        {
            var brand = await _brandReadRepository.GetByIdAsync(brandId.ToString());
            brand.IsDeleted = true;

            await _brandWriteRepository.SaveAsync();
        }

        public async Task<ListBrandDto> GetAllBrandAsync(int page, int size)
        {
            var brands = _brandReadRepository.GetAll(false).Skip(page * size).Take(size);
            return new() { Brands = brands, TotalBrandCount = brands.Count() };
        }

        public async Task<BrandDto> GetBrandByIdAsync(Guid BrandId)
        {
            var brand = await _brandReadRepository.GetByIdAsync(BrandId.ToString());
            return new() { BrandId = brand.Id, Name = brand.Name };
        }

        public async Task HardDeleteBrandAsync(Guid brandId)
        {
            await _brandWriteRepository.RemoveAsync(brandId.ToString());
            await _brandWriteRepository.SaveAsync();
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var brand = await _brandReadRepository.GetByIdAsync(updateBrandDto.BrandId.ToString());
            brand.Name = updateBrandDto.Name;
            _brandWriteRepository.Update(brand);
            await _brandWriteRepository.SaveAsync();
        }
    }
}
