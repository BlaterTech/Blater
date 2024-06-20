using Blater.Models.User;
using Blater.Query.Models;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthRoleStore
{
    Task<BlaterRole> Create(BlaterRole role);
    
    Task<BlaterRole> Update(BlaterRole role);
    
    Task<bool> Delete(BlaterId id);
    Task<bool> Delete(BlaterQuery query);
    Task<bool> Delete(BlaterRole role);
    
    Task<BlaterRole> GetById(BlaterId id);
    Task<BlaterRole> GetByName(string roleName);
    Task<IReadOnlyList<BlaterRole>> GetPermissions(string permissionName);
}