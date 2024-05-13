using Microsoft.AspNetCore.Identity;
using VTU_Manager.Domain.Interfaces.Models;

namespace VTU_Manager.Domain.Entities
{
    public class VTUser : IdentityUser<string>, IEntityBase
    {
        public VTUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool IsDean { get; set; } = false;
        public bool IsViceDean { get; set; } = false;
        public bool IsHeadOfDepartment { get; set; } = false;
        public bool IsScientificSecretary { get; set; } = false;
        public bool IsSupervisor { get; set; } = false;
        public string AcademicTitle { get; set; }
        public Department Department { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string DeletedBy { get; set; }
        public ICollection<ProjectAccessVTUser> VTUserProjectAccesses { get; set; } = new List<ProjectAccessVTUser>();
    }
}
