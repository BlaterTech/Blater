using Blater.Models.Bases;

namespace Blater.Models.User;

public class BlaterRole<TFeature, TPermission>
    : BaseDataModel
    where TPermission : IConvertible
    where TFeature : IConvertible
{
    public required string Name { get; set; }

    public List<string> UsersIds { get; set; } = [];

    /// <summary>
    ///
    /// Examples:
    ///     Feature:Permission
    ///     Feature:SubFeature:Permission
    /// </summary>
    public Dictionary<TFeature, List<TPermission>> Permissions { get; set; } = [];
}

public class BlaterRole : BlaterRole<string, string>;

public class BlaterRole<TPermission> : BlaterRole<string, TPermission> where TPermission : IConvertible;