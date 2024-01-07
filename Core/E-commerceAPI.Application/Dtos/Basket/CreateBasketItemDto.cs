namespace E_commerceAPI.Application.Dtos.Basket
{
    public class CreateBasketItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
