using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthPermissionRoleStore<TRole, in TPermission> 
    where TRole : BaseBlaterRole 
    where TPermission : IConvertible
{
    Task<BlaterResult<TRole>> AddToRole(TRole role, TPermission permission);
    Task<BlaterResult<TRole>> AddToRole(string roleName, TPermission permission);

    Task<BlaterResult> RemoveFromRole(TRole role, TPermission permission);
    Task<BlaterResult> RemoveFromRole(string roleName, TPermission permission);

    Task<BlaterResult<IReadOnlyList<TRole>>> GetRoles(TPermission permission);
}