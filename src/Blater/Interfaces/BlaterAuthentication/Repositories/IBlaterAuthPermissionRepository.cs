using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blater.Models.User;

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