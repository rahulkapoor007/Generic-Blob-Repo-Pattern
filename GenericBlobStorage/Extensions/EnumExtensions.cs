using System.ComponentModel;
using System.Reflection;

namespace GenericBlobStorage.Extensions
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum enumeration)
        {
            FieldInfo fi = enumeration.GetType().GetField(enumeration.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0 && !string.IsNullOrEmpty(attributes[0].Description))
            {
                return attributes[0].Description;
            }
            return enumeration.ToString();
        }
    }
}
