using E_commerceAPI.Application.Dtos.Product;

namespace E_E_commerceAPI.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task StockUpdateToProductAsync(Guid productId, int stockQuantity);
        Task DeleteProductAsync(Guid ProductId);
        Task HardDeleteProductAsync(Guid ProductId);
        Task<object> GetAllProductAsync(int page, int size);
        Task<ProductDto> GetProductByIdAsync(Guid ProductId);
    }
}
