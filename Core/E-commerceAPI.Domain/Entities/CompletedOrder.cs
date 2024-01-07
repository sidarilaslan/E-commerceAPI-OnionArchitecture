using E_commerceAPI.Domain.Entities.Common;

namespace E_commerceAPI.Domain.Entities
{
    public class CompletedOrder : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
