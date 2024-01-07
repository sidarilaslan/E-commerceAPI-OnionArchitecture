using E_commerceAPI.Domain.Entities.Common;
using E_commerceAPI.Domain.Entities.Identity;

namespace E_commerceAPI.Domain.Entities
{
    public class Endpoint : BaseEntity
    {
        public string ActionType { get; set; }
        public string Definition { get; set; }
        public string HttpType { get; set; }
        public string Code { get; set; }

        public Menu Menu { get; set; }
        public ICollection<AppRole> Roles { get; set; }
        public Endpoint()
        {
            Roles = new HashSet<AppRole>();
        }
    }
}
