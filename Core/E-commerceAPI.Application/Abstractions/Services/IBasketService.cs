using E_commerceAPI.Application.Dtos.Basket;
using E_commerceAPI.Domain.Entities;

namespace E_commerceAPI.Application.Abstractions.Services
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetBasketItemsAsync();
        public Task AddItemToBasketAsync(CreateBasketItemDto basketItem);
        public Task UpdateQuantityAsync(UpdateBasketItemDto basketItem);
        public Task RemoveBasketItemAsync(Guid basketItemId);
        public Basket? GetUserActiveBasket { get; }
    }
}
