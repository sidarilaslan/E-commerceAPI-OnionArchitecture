using E_commerceAPI.Domain.Entities.Common;
using E_commerceAPI.Domain.Entities.Identity;

namespace E_commerceAPI.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
