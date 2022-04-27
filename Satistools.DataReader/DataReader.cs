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
    private readonly Dictionary<Type, string> _entities;

    /// <summary>
    /// </summary>
    /// <param name="path">Path to the factorygame file</param>
    public DataReader(string path)
    {
        _path = path;
        _entities = EntityResolver.Resolve();
    }

    /// <summary>
    /// </summary>
    /// <param name="path">Path to the factorygame file</param>
    /// <param name="fileName">Name of the factorygame file</param>
    public DataReader(string path, string fileName)
    {
        _path = path;
        _fileName = fileName;
        _entities = EntityResolver.Resolve();
    }

    /// <summary>
    /// Reads from the JSON file data described by the selected descriptor.
    /// </summary>
    /// <returns>List of parsed data.</returns>
    public List<TTargetEntity> Read<TTargetEntity>()
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

        Type entityType = typeof(TTargetEntity);
        if (!_entities.ContainsKey(entityType))
        {
            throw new Exception($"Descriptor for target type '{entityType}' not found.");
        }

        string nativeClass = _entities[entityType];
        Data data = fileContent.Single(f => f.NativeClass == nativeClass);

        JsonSerializerOptions options = new()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };
        List<TTargetEntity> parsedData = new(data.Classes.Length);
        foreach (JsonNode node in data.Classes)
        {
            TTargetEntity? parsed = node.Deserialize<TTargetEntity>(options);
            if (parsed is null)
            {
                throw new NullReferenceException($"Node {node} could not be parsed to target type {entityType}");
            }

            parsedData.Add(parsed);
        }

        return parsedData;
    }
}