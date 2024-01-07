using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.Application.Features.UserRoles.Queries.GetRoleById
{
    public class GetRoleByIdQueryResponse
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
