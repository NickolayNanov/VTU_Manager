using System.ComponentModel.DataAnnotations.Schema;
using VTU_Manager.Domain.Enums;

namespace VTU_Manager.Domain.Entities
{
    [Table("Projects", Schema = "Manager")]
    public class Project : EntityBase<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Link Link { get; set; }
        public RoleForVTU RoleForVTU { get; set; }
        public string LeadingOrganization { get; set; }
        public LeadingOrganizationCountry LeadingOrganizationCountry { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PlannedBudget { get; set; }
        public Currency Currency { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double PlannedBudgetVTU { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double PlannedFinancationVTU { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double ExpensesAfterProjectCompletion { get; set; }
        public string TargetGroups { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public FinancialSourceType FinancialSourceType { get; set; }
        public string FinancialSourceInfo { get; set; }
        public DateTime YearFinanced { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double MinimalAcceptanceAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double MaximalAcceptanceAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double RequirementCoFinancing { get; set; }
        public DateTime DeadlineProjectSubmition { get; set; }
        public string ProjectImplementationPlace { get; set; }
        public bool RequiresPartnership { get; set; }
        public bool IsInternationalCooperating { get; set; }
        public string ManagerId { get; set; }
        public VTUser Manager { get; set; }
    }
}
