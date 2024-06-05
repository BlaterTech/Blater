using System.ComponentModel;

namespace Blater.Constants;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Dumb rule")]
public enum BlaterCodes
{
    [Description("Undefined error")]
    Undefined = 0,
    
    [Description("Not authenticated")]
    Auth_NotAuthenticated,
    
    [Description("Not authorized")]
    Auth_NotAuthorized,
    
    [Description("Token expired")]
    Auth_TokenExpired,
    
    [Description("Token revoked")]
    Auth_TokenRevoked,
    
    [Description("Invalid token")]
    Auth_TokenInvalid,
    
    [Description("Invalid ID")]
    Auth_InvalidId,
    
    [Description("Not found")]
    General_NotFound,
    
    [Description("Serialization error")]
    General_SerializationError,
    
    [Description("Internal error")]
    General_InternalError,
    
    [Description("Invalid argument")]
    General_InvalidArgument,
    
    [Description("Invalid operation")]
    General_InvalidOperation,
    
    [Description("Invalid state")]
    General_InvalidState,
    
    [Description("Invalid format")]
    General_InvalidFormat,
    
    [Description("Invalid data")]
    General_InvalidData,
    
    [Description("Invalid request")]
    General_InvalidRequest,
    
    [Description("Invalid response")]
    General_InvalidResponse,
    
    [Description("Invalid configuration")]
    General_InvalidConfiguration,
    
    [Description("Invalid environment")]
    General_InvalidEnvironment,
    
    [Description("Invalid version")]
    General_InvalidVersion,
    
    [Description("Invalid type")]
    General_InvalidType,
    
    [Description("Invalid provider information")]
    General_InvalidProviderInformation,
    
    [Description("Invalid provider information")]
    General_InvalidAuthenticateProvider,
    
    [Description("Conflict")]
    General_Conflict,
    
    [Description("Bad request")]
    General_BadRquest,
    
    [Description("Success")]
    General_Success,
}