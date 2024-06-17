namespace Blater.Models.User;

public class BlaterPermission<TPermission> : BaseDataModel where TPermission : IConvertible
{
    public required TPermission Name { get; set; }
}

public class BlaterPermission : BlaterPermission<string>;