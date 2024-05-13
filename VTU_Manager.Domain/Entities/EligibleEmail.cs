using System.ComponentModel.DataAnnotations.Schema;

namespace VTU_Manager.Domain.Entities
{
    [Table("EligibleEmails", Schema = "Manager")]
    public class EligibleEmail : EntityBase<int>
    {
        public string Email { get; set; }
        public bool IsDean { get; set; } = false;
        public bool IsViceDean { get; set; } = false;
        public bool IsHeadOfDepartment { get; set; } = false;
        public bool IsScientificSecretary { get; set; } = false;
        public bool IsSupervisor { get; set; } = false;
        public Department Department { get; set; }
    }
}
