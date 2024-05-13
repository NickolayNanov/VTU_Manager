using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VTU_Manager.Domain.Enums
{
    public enum DepartmentsEnum
    {
        [EnumMember(Value = FacultyConstants.History)]
        Исторически,
        [EnumMember(Value = FacultyConstants.Pedagogically)]
        Педагогически,
        [EnumMember(Value = FacultyConstants.Religious)]
        Православен,
        [EnumMember(Value = FacultyConstants.Economic)]
        Стопански,
        [EnumMember(Value = FacultyConstants.Graphic)]
        Изобразително,
        [EnumMember(Value = FacultyConstants.Math)]
        ФМИ,
        [EnumMember(Value = FacultyConstants.Philology)]
        Филология,
        [EnumMember(Value = FacultyConstants.Philosophy)]
        Философия,
        [EnumMember(Value = FacultyConstants.Legal)]
        Юридически,
        [EnumMember(Value = FacultyConstants.Publish)]
        Издателство,
        [EnumMember(Value = FacultyConstants.Vratza)]
        Враца,
        [EnumMember(Value = FacultyConstants.Pleven)]
        Колеж
    }
}
