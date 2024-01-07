using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Constants;
using E_commerceAPI.Application.Dtos.Basket;
using E_commerceAPI.Application.Middlewares.Exceptions;
using E_commerceAPI.Application.Repositories.BasketItemRepository;
using E_commerceAPI.Application.Repositories.BasketRepository;
using E_commerceAPI.Application.Repositories.OrderRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_commerceAPI.Persistence.Services
{
    public class BasketService : IBasketService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        readonly IOrderReadRepository _orderReadRepository;
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IBasketReadRepository _basketReadRepository;
        readonly IBasketItemWriteRepository _basketItemWriteRepository;
        readonly IBasketItemReadRepository _basketItemReadRepository;
        public BasketService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IOrderReadRepository orderReadRepository, IBasketWriteRepository basketWriteRepository, IBasketItemWriteRepository basketItemWriteRepository, IBasketItemReadRepository basketItemReadRepository, IBasketReadRepository basketReadRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _orderReadRepository = orderReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _basketItemWriteRepository = basketItemWriteRepository;
            _basketItemReadRepository = basketItemReadRepository;
            _basketReadRepository = basketReadRepository;
        }

        private async Task<Basket?> ContextUser()
        {

            var nameIdentifier = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(nameIdentifier))
            {
                AppUser? user = await _userManager.Users
                          .Include(u => u.Baskets)
                          .FirstOrDefaultAsync(u => u.Id == Guid.Parse(nameIdentifier));

                var _basket = from basket in user.Baskets
                              join order in _orderReadRepository.Table
                              on basket.Id equals order.Id into BasketOrders
                              from order in BasketOrders.DefaultIfEmpty()
                              select new
                              {
                                  Basket = basket,
                                  Order = order
                              };

                Basket? targetBasket = null;
                if (_basket.Any(b => b.Order is null))
                    targetBasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;
                else
                {
                    targetBasket = new();
                    user.Baskets.Add(targetBasket);
                }

                await _basketWriteRepository.SaveAsync();
                return targetBasket;
            }
            throw new NotFoundException(Messages.User.UserNotFound);
        }


        public async Task AddItemToBasketAsync(CreateBasketItemDto basketItem)
        {
            Basket? basket = await ContextUser();
            if (basket != null)
            {
                BasketItem _basketItem = await _basketItemReadRepository.GetSingleAsync(bi => bi.BasketId == basket.Id && bi.ProductId == Guid.Parse(basketItem.ProductId.ToString()));
                if (_basketItem != null)
                    _basketItem.Quantity++;
                else
                    await _basketItemWriteRepository.AddAsync(new()
                    {
                        BasketId = basket.Id,
                        ProductId = Guid.Parse(basketItem.ProductId.ToString()),
                        Quantity = basketItem.Quantity
                    });

                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public async Task<List<BasketItem>> GetBasketItemsAsync()
        {
            Basket? basket = await ContextUser();
            Basket? result = await _basketReadRepository.Table
                 .Include(b => b.BasketItems)
                 .ThenInclude(bi => bi.Product)
                 .FirstOrDefaultAsync(b => b.Id == basket.Id);

            return result.BasketItems
                .ToList();
        }

        public async Task RemoveBasketItemAsync(Guid basketItemId)
        {
            BasketItem? basketItem = await _basketItemReadRepository.GetByIdAsync(basketItemId.ToString());
            if (basketItem != null)
            {
                _basketItemWriteRepository.Remove(basketItem);
                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public async Task UpdateQuantityAsync(UpdateBasketItemDto basketItem)
        {
            BasketItem? _basketItem = await _basketItemReadRepository.GetByIdAsync(basketItem.BasketItemId.ToString());
            if (_basketItem != null)
            {
                _basketItem.Quantity = basketItem.Quantity;
                await _basketItemWriteRepository.SaveAsync();
            }
        }
        public Basket? GetUserActiveBasket
        {
            get
            {
                Basket? basket = ContextUser().Result;
                return basket;
            }
        }

    }
}