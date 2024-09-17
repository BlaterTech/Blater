using System.Reflection;

namespace Blater.Helpers;

public static class TypesHelper
{
    static TypesHelper()
    {
        Initialize();
    }

    public static HashSet<Assembly> Assemblies { get; } = [];
    
    public static List<Assembly> RoutesAssemblies { get; } = [];

    public static HashSet<Type> AllTypes { get; } = [];
    public static Dictionary<string, Type> TypesDictionary { get; } = new();

    private const string BlaterString = "Blater";

    public static void Initialize()
    {
        //Current Running Assembly
        var currentAssembly = Assembly.GetExecutingAssembly();

        Assemblies.Add(currentAssembly);
        AllTypes.UnionWith(currentAssembly.GetTypes());

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var assembly in assemblies)
        {
            if (!assembly.GetName().Name?.StartsWith(BlaterString) ?? false)
            //Log.Debug("Skipping assembly {AssemblyName}", assembly.FullName);
            {
                continue;
            }

            //Log.Debug("Adding assembly {AssemblyName}", assembly.FullName);
            Assemblies.Add(assembly);
            AllTypes.UnionWith(assembly.GetTypes());
        }

        //Create dictionary of types
        foreach (var type in AllTypes)
        {
            TypesDictionary[type.Name] = type;
        }
    }

    /// <summary>
    /// Get all types in a specific namespace
    /// </summary>
    /// <param name="namespace"></param>
    /// <returns></returns>
    public static HashSet<Type> GetTypesInNamespace(string @namespace)
    {
        return AllTypes.Where(t => t.Namespace == @namespace).ToHashSet();
    }

    /// <summary>
    /// Get all types that implements a specific interface
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    /// <returns></returns>
    public static HashSet<Type> GetTypesImplementingInterface<TInterface>()
    {
        var interfaceType = typeof(TInterface);
        return AllTypes.Where(t => interfaceType.IsAssignableFrom(t) && t is { IsClass: true, IsAbstract: false }).ToHashSet();
    }
}