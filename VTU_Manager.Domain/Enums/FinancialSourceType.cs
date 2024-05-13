using System.ComponentModel.DataAnnotations;

namespace VTU_Manager.Domain.Enums
{
    public enum FinancialSourceType
    {
        [Display(Name = "Национално")]
        National = 0,
        [Display(Name = "Субсидия")]
        Subsidy = 1,
        [Display(Name = "Спонсор")]
        Sponsor = 2,
        [Display(Name = "Лични средства")]
        PersonalResources = 3,
        [Display(Name = "Дарения")]
        Donations = 4
    }
}
