using System.Reflection;
using Satistools.DataReader.Attributes;

namespace Satistools.DataReader;

/// <summary>
/// Resolves all data entities inside an assembly
/// </summary>
public static class EntityResolver
{
    public static Dictionary<Type, string> Resolve()
    {
        IEnumerable<KeyValuePair<Type, string>> values = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => a.FullName is not null && a.FullName!.StartsWith("Satistools.DataReader") && !a.FullName.Contains("Test"))
            .SelectMany(a => a.DefinedTypes.Where(t => t.GetCustomAttribute<DataEntityAttribute>() is not null))
            .Select(t => new KeyValuePair<Type, string>(t, t.GetCustomAttribute<DataEntityAttribute>()!.NativeClass));

        return new Dictionary<Type, string>(values);
    }
}