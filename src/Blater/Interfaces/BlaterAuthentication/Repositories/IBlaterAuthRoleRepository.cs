using System.Linq.Expressions;
using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthRoleRepository
{
    Task<BlaterRole> Create(BlaterRole role);
    
    Task<BlaterRole> Update(BlaterRole role);
    
    Task<bool> Delete(BlaterId id);
    Task<bool> Delete(BlaterRole role);
    Task<bool> Delete(Expression<Func<BlaterRole, bool>> predicate);
    
    Task<BlaterRole> GetById(BlaterId id);
    Task<BlaterRole> GetByName(string roleName);
    Task<IReadOnlyList<BlaterRole>> GetPermissions(string permissionName);
}