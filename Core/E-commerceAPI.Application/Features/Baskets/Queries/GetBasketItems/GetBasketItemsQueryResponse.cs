using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.Application.Features.Baskets.Queries.GetBasketItems
{
    public class GetBasketItemsQueryResponse
    {
        public string BasketItemId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
