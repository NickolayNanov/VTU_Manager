using VTU_Manager.Domain.Interfaces.Models;

namespace VTU_Manager.Domain.Entities
{
    public class EntityBase<TKey> : IEntityBase
    {
        public TKey Id { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string DeletedBy { get; set; }
    }
}
