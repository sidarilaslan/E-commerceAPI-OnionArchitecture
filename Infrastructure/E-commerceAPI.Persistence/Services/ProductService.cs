using E_commerceAPI.Application.Constants;
using E_commerceAPI.Application.Dtos.Product;
using E_commerceAPI.Application.Middlewares.Exceptions;
using E_commerceAPI.Application.Repositories.ProductRepository;
using E_E_commerceAPI.Application.Abstractions.Services;
using Microsoft.EntityFrameworkCore;

namespace E_commerceAPI.Persistence.Services
{
    public class ProductService : IProductService
    {
        private IProductReadRepository _productReadRepository;
        private IProductWriteRepository _productWriteRepository;

        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Code = createProductDto.Code,
                Description = createProductDto.Description,
                UnitPrice = createProductDto.UnitPrice,
                Color = createProductDto.Color,
                Name = createProductDto.Name,
                StockQuantity = createProductDto.StockQuantity,
                BrandId = createProductDto.BrandId,
                CategoryId = createProductDto.CategoryId,
            });
            await _productWriteRepository.SaveAsync();
        }

        public async Task DeleteProductAsync(Guid ProductId)
        {
            var product = await _productReadRepository.GetByIdAsync(ProductId.ToString());
            product.IsDeleted = true;

            await _productWriteRepository.SaveAsync();
        }

        public async Task<object> GetAllProductAsync(int page, int size)
        {

            return _productReadRepository.GetAll(false).Skip(page * size).Take(size)
                .Include(p => p.Brand)
                .Include(p => p.Category)
              .Select(product => new
              {
                  ProductId = product.Id,
                  Name = product.Name,
                  BrandId = product.BrandId,
                  CategoryId = product.CategoryId,
                  CategoryName = product.Category.Name,
                  BrandName = product.Brand.Name,
                  Code = product.Code,
                  Color = product.Color,
                  Description = product.Description,
                  UnitPrice = product.UnitPrice,
                  StockQuantity = product.StockQuantity
              }).ToList();
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid ProductId)
        {

            var product = await _productReadRepository.GetByIdAsync(ProductId.ToString());
            return new ProductDto()
            {
                ProductId = product.Id,
                Name = product.Name,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                Code = product.Code,
                Color = product.Color,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                StockQuantity = product.StockQuantity
            };
        }

        public async Task HardDeleteProductAsync(Guid ProductId)
        {
            await _productWriteRepository.RemoveAsync(ProductId.ToString());
            await _productWriteRepository.SaveAsync();
        }

        public async Task StockUpdateToProductAsync(Guid productId, int stockQuantity)
        {
            var product = await _productReadRepository.GetByIdAsync(productId.ToString());
            if (product == null)
                throw new NotFoundException(Messages.Product.ProductNotFound);

            product.StockQuantity = stockQuantity;
            await _productWriteRepository.SaveAsync();
        }
    }
}
