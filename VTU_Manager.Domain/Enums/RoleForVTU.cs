using System.ComponentModel.DataAnnotations;

namespace VTU_Manager.Domain.Enums
{
    public enum RoleForVTU
    {
        [Display(Name = "Водеща организация")]
        PrimaryOrganization = 0,
        [Display(Name = "Второстепенна организация")]
        SecondaryOrganization = 1,
        [Display(Name = "Трета страна")]
        ThirdParty = 2,
        [Display(Name = "Неутрална")]
        Neutral = 3
    }
}
