using E_commerceAPI.Domain.Entities.Common;

namespace E_commerceAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public Basket Basket { get; set; }
        public Guid BasketId { get; set; }
        public CompletedOrder CompletedOrder { get; set; }
    }
}
