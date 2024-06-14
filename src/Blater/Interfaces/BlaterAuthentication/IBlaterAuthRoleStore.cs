using Blater.Models.User;
using Blater.Query.Models;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthRoleStore
{
    Task<BlaterResult<BlaterRole>> Create(BlaterRole role);
    
    Task<BlaterResult<BlaterRole>> Update(BlaterRole role);
    
    Task<BlaterResult<bool>> Delete(BlaterId id);
    Task<BlaterResult<bool>> Delete(BlaterQuery query);
    Task<BlaterResult<bool>> Delete(BlaterRole role);
    
    Task<BlaterResult<BlaterRole>> GetById(BlaterId id);
    Task<BlaterResult<BlaterRole>> GetByName(string roleName);
    Task<BlaterResult<IReadOnlyList<BlaterRole>>> GetPermissions(string permissionName);
}