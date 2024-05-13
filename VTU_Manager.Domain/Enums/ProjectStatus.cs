using System.ComponentModel.DataAnnotations;

namespace VTU_Manager.Domain.Enums
{
    public enum ProjectStatus
    {
        [Display(Name = "Новосъздаден")]
        NewlyCreated = 0,
        [Display(Name = "В процес на разработка")]
        InProgress = 1,
        [Display(Name = "В процес на разглеждане и оценка")]
        Reviewing = 2,
        [Display(Name = "Закрит")]
        Closed = 3
    }
}
