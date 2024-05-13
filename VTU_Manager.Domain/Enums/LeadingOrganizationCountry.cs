using System.ComponentModel.DataAnnotations;

namespace VTU_Manager.Domain.Enums
{
    public enum LeadingOrganizationCountry
    {
        [Display(Name = "България")]
        Bulgaria = 0,

        [Display(Name = "Франция")]
        France = 1,

        [Display(Name = "Германия")]
        Germany = 2
    }
}
