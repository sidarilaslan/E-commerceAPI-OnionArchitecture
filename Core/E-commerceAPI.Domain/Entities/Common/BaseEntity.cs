namespace E_commerceAPI.Domain.Entities.Common
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual Guid? CreatedByUserId { get; set; }
        public virtual Guid? ModifiedByUserId { get; set; }

    }
}
