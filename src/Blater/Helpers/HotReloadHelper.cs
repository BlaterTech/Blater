using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using Blater.Helpers;
using Blater.Logging;

[assembly: MetadataUpdateHandler(typeof(HotReloadHelper))]

namespace Blater.Helpers;

[SuppressMessage("Design", "CA1003:Usar instâncias do manipulador de eventos genéricos")]
public static class HotReloadHelper
{
    public static event Action<Type[]?>? UpdateApplicationEvent;
    
    internal static void ClearCache(Type[]? types)
    {
    }
    
    internal static void UpdateApplication(Type[]? types)
    {
        using var _ = new LogTimer("HotReloadHelper.UpdateApplication");
        UpdateApplicationEvent?.Invoke(types);
    }
}