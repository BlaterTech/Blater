using Blater.Models.Database;
using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Stores;

public interface IBlaterAuthPermissionStore
{
    Task<BlaterResult<BlaterPermission>> Create(BlaterPermission permission);

    Task<BlaterResult<BlaterPermission>> Update(BlaterPermission permission);

    Task<BlaterResult<bool>> Delete(BlaterPermission permission);
    Task<BlaterResult<bool>> Delete(Ulid id);
    Task<BlaterResult<bool>> Delete(BlaterQuery query);

    Task<BlaterResult<IReadOnlyList<BlaterPermission>>> GetAll();

    Task<BlaterResult<BlaterPermission>> GetById(Ulid id);
    Task<BlaterResult<BlaterPermission>> GetPermission(string permissionName);
}