using System.Linq.Expressions;
using Blater.Models.User;
using Blater.Query.Models;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthPermissionRepository
{
    Task<BlaterPermission> Create(BlaterPermission permission);
    
    Task<BlaterPermission> Update(BlaterPermission permission);
    
    Task<bool> Delete(BlaterPermission permission);
    Task<bool> Delete(BlaterId id);
    Task<bool> Delete(Expression<Func<BlaterPermission, bool>> predicate);
    
    Task<IReadOnlyList<BlaterPermission>> GetAll();
    
    Task<BlaterPermission> GetById(BlaterId id);
    Task<BlaterPermission> GetPermission(string permissionName);
}