using System.Text.Json;
using System.Text.Json.Serialization;
using LogerExtensionDelegate;
using Microsoft.Extensions.Logging;
using Serialization;
using UriSerializationHelper;

namespace JsonSerializer.Serialization;

/// <summary>
/// Presents the serialization functionality of the sequence<see cref="IEnumerable{Uri}"/>
/// with using JsonSerialization class.
/// </summary>
public class JsonSerializerTechnology : IDataSerializer<Uri>
{
    private static readonly JsonSerializerOptions Options = new ()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    private readonly string path;
    private readonly ILogger<JsonSerializerTechnology>? logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonSerializerTechnology"/> class.
    /// </summary>
    /// <param name="path">The path to json file.</param>
    /// <param name="logger">The logger.</param>
    /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
    public JsonSerializerTechnology(string? path, ILogger<JsonSerializerTechnology>? logger = default)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentException("The path must not be null or empty.", nameof(path));
        }

        this.path = path;
        this.logger = logger;
    }

    /// <summary>
    /// Serializes the source sequence of Uri elements in json format.
    /// </summary>
    /// <param name="source">The source sequence of Uri elements.</param>
    /// <exception cref="ArgumentNullException">Throw if the source sequence is null.</exception>
    public void Serialize(IEnumerable<Uri>? source)
    {
        ArgumentNullException.ThrowIfNull(source);

        var addresses = source.Select(uri => uri.ToSerializableObject()).ToArray();
        var json = System.Text.Json.JsonSerializer.Serialize(addresses, Options);

        File.WriteAllText(this.path, json);

        LogerExtension.FastLoggerMessage(this.logger, $"Serialized data to file: {this.path}", new LogerExtensionException($"Serialized data to file: {this.path}"));
    }
}
