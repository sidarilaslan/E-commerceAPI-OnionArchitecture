using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.Application.Dtos.Order
{
    public class CompletedOrderDto
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
