using Blater.Models.User;
using Blater.Query.Models;
using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthPermissionStore<in TPermission> where TPermission : BaseBlaterPermission
{
    Task<BlaterResult<bool>> Create(TPermission role);
    
    Task<BlaterResult<bool>> Update(TPermission role);
    
    Task<BlaterResult<bool>> Delete(TPermission role);
    Task<BlaterResult<bool>> Delete(BlaterId id);
    Task<BlaterResult<bool>> Delete(BlaterQuery query);
}