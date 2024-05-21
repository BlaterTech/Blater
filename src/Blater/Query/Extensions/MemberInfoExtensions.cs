using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json.Serialization;
using Humanizer;

namespace Blater.Query.Extensions
{
    internal static class MemberInfoExtensions
    {
        public static string GetBlaterPropertyName(this MemberInfo memberInfo)
        {
            var jsonPropertyAttributes = memberInfo.GetCustomAttributes(typeof(JsonPropertyNameAttribute), true);
            var jsonProperty = jsonPropertyAttributes.Length > 0 
                ? jsonPropertyAttributes[0] as JsonPropertyNameAttribute
                : null;

            return jsonProperty != null
                ? jsonProperty.Name
                : memberInfo.Name.Camelize();
        }
    }
}
