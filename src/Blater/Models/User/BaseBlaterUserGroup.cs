namespace Blater.Models.User;

public abstract class BaseBlaterUserGroup<TUser, TPermission> where TUser : BaseBlaterUser where TPermission : Enum
{
    public abstract List<TUser> Users { get; set; }
    
    public abstract List<TPermission> Permissions { get; set; }
}