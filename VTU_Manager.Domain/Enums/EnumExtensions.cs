using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace VTU_Manager.Domain.Enums
{
    public static class EnumExtensions
    {
        /// <summary>
        ///     Generic method which is used to return a string representation of the given enum.
        ///     If there is Display Attribute with a given name it will return it as a string value
        /// </summary>
        public static string GetEnumString(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumValue.ToString();
        }
    }
}
