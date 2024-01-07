namespace E_commerceAPI.Domain.Entities.Common
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
