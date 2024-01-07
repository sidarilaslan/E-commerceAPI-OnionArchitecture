using E_commerceAPI.Domain.Entities.Common;

namespace E_commerceAPI.Application.Dtos.AuthorizationConfigration
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public List<Action> Actions { get; set; } = new();
    }
}
