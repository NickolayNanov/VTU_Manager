using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VTU_Manager.Domain.Enums
{
    public enum Link
    {
        [Display(Name = "Филологически факултет")]
        PhilologyFaculty = 0,
        [Display(Name = "Факултет Математима и Информатика")]
        FMI = 1,
        [Display(Name = "Стопански факултет")]
        EconomicsFaculty = 2,
        [Display(Name = "Стопански факултетasdasd")]
        EconomicsFacultyasdasd = 3
    }
}