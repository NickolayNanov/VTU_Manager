using System.ComponentModel.DataAnnotations.Schema;
using VTU_Manager.Domain.Enums;

namespace VTU_Manager.Domain.Entities
{
    [Table("ProjectAccess", Schema = "Manager")]
    public class ProjectAccess : EntityBase<int>
    {
        public ProjectsAccessEnum ProjectsAccess { get; set; }
        public ICollection<ProjectAccessVTUser> ProjectAccessesVTUsers { get; set; } = new List<ProjectAccessVTUser>();
    }
}
