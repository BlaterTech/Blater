using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace Blater.Extensions;

public static class EventCallbackExtensions
{
    public static readonly MethodInfo EventCallbackFactoryCreate = EventCallback.Factory.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                                                                .Where(m => m.Name == nameof(EventCallback.Factory.Create)).ToList()[8];
}