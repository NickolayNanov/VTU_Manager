using System.ComponentModel.DataAnnotations.Schema;

namespace VTU_Manager.Domain.Entities
{
    [Table("ProjectAccessVTUser", Schema = "Manager")]
    public class ProjectAccessVTUser
    {
        public string VTUserId { get; set; }

        public VTUser VTUser { get; set; }

        public int ProjectAccessId { get; set; }

        public ProjectAccess ProjectAccess { get; set; }
    }
}
