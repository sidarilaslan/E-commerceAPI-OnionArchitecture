using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.Application.Features.UserRoles.Queries.GetAllRole
{
    public class GetAllRoleQueryResponse
    {
        public object Roles { get; set; }
        public int TotalRoleCount { get; set; }
    }
}
