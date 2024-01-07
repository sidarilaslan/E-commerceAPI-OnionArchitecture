using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryResponse
    {
        public Guid OrderId { get; set; }
        public string Address { get; set; }
        public object BasketItems { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
