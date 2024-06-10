using Ardalis.SmartEnum;

namespace Blater.Models.User.Permissions;

public class BaseBlaterPermission : SmartEnum<BaseBlaterPermission>
{
    public BaseBlaterPermission(string name) : base(name, HashCode.Combine(name, typeof(BaseBlaterPermission)))
    {
    }
}