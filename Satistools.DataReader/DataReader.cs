using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Satistools.DataReader.Entities;
using Satistools.DataReader.Entities.Items;

namespace Satistools.DataReader;

/// <summary>
/// A tool for reading JSON provided by the FactoryGame.
/// </summary>
public class DataReader
{
    /// <summary>
    /// The name of used file.
    /// </summary>
    private readonly string _fileName = "data.json";

    /// <summary>
    /// Path to the json file.
    /// </summary>
    private readonly string _path;

    /// <summary>
    /// List of available descriptors used for JSON data.
    /// </summary>
    private readonly Dictionary<Type, string> _descriptors = new()
    {
        { typeof(ItemDescriptor), "Class'/Script/FactoryGame.FGItemDescriptor'" },
        { typeof(Recipe), "Class'/Script/FactoryGame.FGRecipe'" }
    };

    /// <summary>
    /// </summary>
    /// <param name="path">Path to the factorygame file</param>
    public DataReader(string path)
    {
        _path = path;
    }

    /// <summary>
    /// </summary>
    /// <param name="path">Path to the factorygame file</param>
    /// <param name="fileName">Name of the factorygame file</param>
    public DataReader(string path, string fileName)
    {
        _path = path;
        _fileName = fileName;
    }

    /// <summary>
    /// Reads from the JSON file data described by the selected descriptor.
    /// </summary>
    /// <returns>List of parsed data.</returns>
    public List<TTargetDescriptor> Read<TTargetDescriptor>()
    {
        string filePath = Path.Combine(_path, _fileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The JSON at '{filePath}' was not found.");
        }

        FileStream stream = File.OpenRead(filePath);
        Data[]? fileContent = JsonSerializer.Deserialize<Data[]>(stream);
        if (fileContent is null)
        {
            throw new NullReferenceException($"Data from the file '{fileContent}' could not be read.");
        }

        Type descriptorType = typeof(TTargetDescriptor);
        if (!_descriptors.ContainsKey(descriptorType))
        {
            throw new Exception($"Descriptor for target type '{descriptorType}' not found.");
        }

        string nativeClass = _descriptors[descriptorType];
        Data data = fileContent.Single(f => f.NativeClass == nativeClass);

        JsonSerializerOptions options = new()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };
        List<TTargetDescriptor> parsedData = new(data.Classes.Length);
        foreach (JsonNode node in data.Classes)
        {
            TTargetDescriptor? parsed = node.Deserialize<TTargetDescriptor>(options);
            if (parsed is null)
            {
                throw new NullReferenceException($"Node {node} could not be parsed to target type {descriptorType}");
            }

            parsedData.Add(parsed);
        }

        return parsedData;
    }
}