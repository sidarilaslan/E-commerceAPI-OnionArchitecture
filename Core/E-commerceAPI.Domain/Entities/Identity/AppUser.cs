using E_commerceAPI.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;


namespace E_commerceAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public ICollection<Basket> Baskets { get; set; }

    }
}
