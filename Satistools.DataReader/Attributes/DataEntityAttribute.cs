namespace Satistools.DataReader.Attributes;

/// <summary>
/// Describes class serving as entity for parsing JSON data of FactoryGame.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class DataEntityAttribute : Attribute
{
    public DataEntityAttribute(string nativeClass)
    {
        NativeClass = nativeClass;
    }

    /// <summary>
    /// The name of class describing json entity.
    /// </summary>
    public string NativeClass { get; }
}