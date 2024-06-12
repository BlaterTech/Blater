using Blater.Models.User;
using Blater.Query.Models;
using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthRoleStore<TRole> where TRole : BlaterRole
{
    Task<BlaterResult<bool>> Create(TRole role);
    
    Task<BlaterResult<bool>> Update(TRole role);
    
    Task<BlaterResult<bool>> Delete(TRole role);
    Task<BlaterResult<bool>> Delete(BlaterId id);
    Task<BlaterResult<bool>> Delete(BlaterQuery query);
    
    Task<BlaterResult<BlaterId>> GetRoleId(TRole role);
    Task<BlaterResult<string>> GetRoleName(TRole role);
    
    Task<BlaterResult<TRole>> FindById(BlaterId id);
    Task<BlaterResult<TRole>> FindByName(string roleName);
}