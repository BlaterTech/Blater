﻿using Blater.Models.User;
using Blater.Query.Models;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthRoleStore
{
    Task<BlaterResult<BaseBlaterRole>> Create(BaseBlaterRole role);
    
    Task<BlaterResult<BaseBlaterRole>> Update(BaseBlaterRole role);
    
    Task<BlaterResult<bool>> Delete(BlaterId id);
    Task<BlaterResult<bool>> Delete(BlaterQuery query);
    Task<BlaterResult<bool>> Delete(BaseBlaterRole role);
    
    Task<BlaterResult<BaseBlaterRole>> Get(BlaterId id);
    Task<BlaterResult<BaseBlaterRole>> GetByName(string roleName);
    Task<BlaterResult<IReadOnlyList<BaseBlaterRole>>> GetPermissions(string permissionName);
}