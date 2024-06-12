using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthPermissionRoleStore<in TPermission>
{
    Task<BlaterResult<bool>> AddToRole(TPermission permission, string roleName);
    
    Task<BlaterResult<bool>> RemoveFromRole(TPermission permission, string roleName);
    
    Task<BlaterResult<IEnumerable<string>>> GetRoles(TPermission permission, string roleName);
}