using E_commerceAPI.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerceAPI.Domain.Entities
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public override DateTime? ModifiedDate { get => base.ModifiedDate; set => base.ModifiedDate = value; }
        [NotMapped]
        public override Guid? ModifiedByUserId { get => base.ModifiedByUserId; set => base.ModifiedByUserId = value; }
    }
}
