using E_commerceAPI.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace E_commerceAPI.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<Guid>, IEntity
    {
        public ICollection<Endpoint> Endpoints { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
