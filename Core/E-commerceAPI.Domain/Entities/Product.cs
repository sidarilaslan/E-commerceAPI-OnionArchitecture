using E_commerceAPI.Domain.Entities.Common;

namespace E_commerceAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public float UnitPrice { get; set; }
        public string Description { get; set; }
        public Guid? BrandId { get; set; }
        public string Code { get; set; }
        public string Color { get; set; }
        public Guid? CategoryId { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
    }
}
