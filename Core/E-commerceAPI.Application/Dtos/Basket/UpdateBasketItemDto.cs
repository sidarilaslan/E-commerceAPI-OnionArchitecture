namespace E_commerceAPI.Application.Dtos.Basket
{
    public class UpdateBasketItemDto
    {
        public Guid BasketItemId { get; set; }
        public int Quantity { get; set; }
    }
}
