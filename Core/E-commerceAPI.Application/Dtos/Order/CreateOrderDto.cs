namespace E_commerceAPI.Application.Dtos.Order
{
    public class CreateOrderDto
    {
        public Guid BasketId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
    }
}
