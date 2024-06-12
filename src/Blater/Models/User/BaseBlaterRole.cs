namespace Blater.Models.User;

public abstract class BaseBlaterRole<TFeature, TPermission>
    where TPermission : IConvertible
    where TFeature : IConvertible
{
    public  abstract string Name { get; set; }
    
    public List<BlaterId> UsersIds { get; set; } = [];
    
    /// <summary>
    ///
    /// Examples:
    ///     Feature:Permission
    ///     Feature:SubFeature:Permission
    /// </summary>
    public abstract Dictionary<TFeature, List<TPermission>> Permissions { get; set; }
}

public abstract class BaseBlaterRole : BaseBlaterRole<string, string>;