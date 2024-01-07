using E_commerceAPI.Application.Dtos.Order;

namespace E_commerceAPI.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto createOrder);
        Task<ListOrdersDto> GetAllOrdersAsync(int page, int size);
        Task<OrderDto> GetOrderByIdAsync(Guid orderId);
        Task<(bool, CompletedOrderDto)> CompleteOrderAsync(Guid orderId);
    }
}
