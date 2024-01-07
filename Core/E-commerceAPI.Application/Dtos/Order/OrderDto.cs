namespace E_commerceAPI.Application.Dtos.Order
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public string OrderCode { get; set; }
        public string Address { get; set; }
        public object BasketItems { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
