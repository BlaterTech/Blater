using System.Linq.Expressions;
using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthPermissionRepository
{
    Task<BlaterPermission> Create(BlaterPermission permission);

    Task<BlaterPermission> Update(BlaterPermission permission);

    Task<bool> Delete(BlaterPermission permission);
    Task<bool> Delete(Ulid id);
    Task<bool> Delete(Expression<Func<BlaterPermission, bool>> predicate);

    Task<IReadOnlyList<BlaterPermission>> GetAll();

    Task<BlaterPermission> GetById(Ulid id);
    Task<BlaterPermission> GetPermission(string permissionName);
}