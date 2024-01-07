namespace E_commerceAPI.Application.Dtos.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public float UnitPrice { get; set; }
        public string Description { get; set; }
        public Guid? BrandId { get; set; }
        public string Code { get; set; }
        public string Color { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
