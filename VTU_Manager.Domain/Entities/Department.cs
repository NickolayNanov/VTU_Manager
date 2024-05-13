using System.ComponentModel.DataAnnotations;
using VTU_Manager.Domain.Enums;

namespace VTU_Manager.Domain.Entities
{
    public class Department : EntityBase<int>
    {
        [Required]
        public DepartmentsEnum DepartmentName { get; set; }
        public ICollection<VTUser> Users { get; set; }
        public ICollection<Protocol> Protocols { get; set; }
        public ICollection<EligibleEmail> EligibleEmails { get; set; }
    }
}
