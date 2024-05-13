using System.ComponentModel.DataAnnotations;

namespace VTU_Manager.Domain.Enums
{
    public enum Currency
    {
        [Display(Name = "BGN")]
        BGN = 0,
        [Display(Name = "EUR")]
        EUR = 1,
        [Display(Name = "USD")]
        USD = 2
    }
}
