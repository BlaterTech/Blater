using Blater.Models.User;
using Blater.Query.Models;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthPermissionRepository
{
    Task<BlaterPermission> Create(BlaterPermission permission);
    
    Task<BlaterPermission> Update(BlaterPermission permission);
    
    Task<bool> Delete(BlaterPermission permission);
    Task<bool> Delete(BlaterId id);
    Task<bool> Delete(BlaterQuery query);
    
    Task<IReadOnlyList<BlaterPermission>> GetAll();
    
    Task<BlaterPermission> GetById(BlaterId id);
    Task<BlaterPermission> GetPermission(string permissionName);
}