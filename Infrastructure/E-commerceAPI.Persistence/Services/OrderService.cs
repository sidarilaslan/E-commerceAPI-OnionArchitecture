using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Dtos.Order;
using E_commerceAPI.Application.Repositories.CompletedOrderRepository;
using E_commerceAPI.Application.Repositories.OrderRepository;
using E_commerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_commerceAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;
        readonly ICompletedOrderWriteRepository _completedOrderWriteRepository;
        readonly ICompletedOrderReadRepository _completedOrderReadRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository, ICompletedOrderWriteRepository completedOrderWriteRepository, ICompletedOrderReadRepository completedOrderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
            _completedOrderWriteRepository = completedOrderWriteRepository;
            _completedOrderReadRepository = completedOrderReadRepository;
        }


        public async Task CreateOrderAsync(CreateOrderDto createOrder)
        {
            await _orderWriteRepository.AddAsync(new()
            {
                Address = createOrder.Address,
                Description = createOrder.Description,
                BasketId = createOrder.BasketId
            });
            await _orderWriteRepository.SaveAsync();
        }

        public async Task<ListOrdersDto> GetAllOrdersAsync(int page, int size)
        {
            var query = _orderReadRepository.Table.Include(o => o.Basket)
                      .ThenInclude(b => b.User)
                      .Include(o => o.Basket)
                         .ThenInclude(b => b.BasketItems)
                         .ThenInclude(bi => bi.Product).Skip(page * size).Take(size);

            var orders = from order in query
                         join completedOrder in _completedOrderReadRepository.Table
                            on order.Id equals completedOrder.OrderId into co
                         from _co in co.DefaultIfEmpty()
                         select new
                         {
                             Id = order.Id,
                             CreatedDate = order.CreatedDate,
                             Address = order.Address,
                             Description = order.Description,
                             Basket = order.Basket,
                             Completed = _co != null ? true : false
                         };

            return new()
            {
                TotalOrderCount = await query.CountAsync(),
                Orders = await orders.Select(o => new
                {
                    Id = o.Id,
                    CreatedDate = o.CreatedDate,
                    TotalPrice = o.Basket.BasketItems.Sum(bi => bi.Product.UnitPrice * bi.Quantity),
                    Description = o.Description,
                    o.Completed
                }).ToListAsync()
            };
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid orderId)
        {
            var query = _orderReadRepository.Table
                                .Include(o => o.Basket)
                                    .ThenInclude(b => b.BasketItems)
                                        .ThenInclude(bi => bi.Product);

            var data = await (from order in query
                              join completedOrder in _completedOrderReadRepository.Table
                                   on order.Id equals completedOrder.OrderId into _completedOrder
                              from _co in _completedOrder.DefaultIfEmpty()
                              select new
                              {
                                  Id = order.Id,
                                  CreatedDate = order.CreatedDate,
                                  Basket = order.Basket,
                                  Completed = _co != null ? true : false,
                                  Address = order.Address,
                                  Description = order.Description
                              }).FirstOrDefaultAsync(o => o.Id == orderId);

            return new()
            {
                OrderId = orderId,
                BasketItems = data.Basket.BasketItems.Select(bi => new
                {
                    bi.Product.Name,
                    bi.Product.UnitPrice,
                    bi.Quantity,
                }),
                Address = data.Address,
                CreatedDate = data.CreatedDate,
                Description = data.Description,
                Completed = data.Completed
            };
        }

        public async Task<(bool, CompletedOrderDto)> CompleteOrderAsync(Guid orderId)
        {
            Order? order = await _orderReadRepository.Table
                .Include(o => o.Basket)
                .ThenInclude(b => b.User)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order != null)
            {
                await _completedOrderWriteRepository.AddAsync(new() { OrderId = orderId });
                return (await _completedOrderWriteRepository.SaveAsync() > 0, new()
                {
                    OrderId = orderId,
                    OrderDate = order.CreatedDate
                });
            }
            return (false, null);
        }
    }
}
