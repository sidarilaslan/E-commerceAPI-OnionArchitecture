using E_commerceAPI.Domain.Entities.Common;

namespace E_commerceAPI.Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
        public Product Product { get; set; }

    }
}
