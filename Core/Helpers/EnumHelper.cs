using System.ComponentModel;

namespace Core.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field == null) return value.ToString();

            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}
