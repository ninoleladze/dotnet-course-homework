using System.Xml;
using System.Xml.Linq;
using LogerExtensionDelegate;
using Microsoft.Extensions.Logging;
using Serialization;
using UriSerializationHelper;

namespace XDomWriter.Serialization;

/// <summary>
/// Presents the serialization functionality of the sequence<see cref="IEnumerable{Uri}"/>
/// with using X-DOM model.
/// </summary>
public class XDomTechnology : IDataSerializer<Uri>
{
    private readonly string path;
    private readonly ILogger<XDomTechnology>? logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="XDomTechnology"/> class.
    /// </summary>
    /// <param name="path">The path to json file.</param>
    /// <param name="logger">The logger.</param>
    /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
    public XDomTechnology(string? path, ILogger<XDomTechnology>? logger = default)
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

        var root = new XElement("uriAdresses");

        foreach (var uri in source)
        {
            var address = uri.ToSerializableObject();

            var addressElement = new XElement(
                "uriAdress",
                new XElement("scheme", new XAttribute("name", address.Scheme)),
                new XElement("host", new XAttribute("name", address.Host)),
                new XElement("path", address.Path.Select(segment => new XElement("segment", segment))));

            if (address.Query.Count > 0)
            {
                addressElement.Add(new XElement(
                    "query",
                    address.Query.Select(parameter =>
                        new XElement("parameter", new XAttribute("key", parameter.Key), new XAttribute("value", parameter.Value)))));
            }

            root.Add(addressElement);
        }

        var document = new XDocument(new XDeclaration("1.0", "utf-8", null), root);
        document.Save(this.path);

        LogerExtension.FastLoggerMessage(this.logger, $"Serialized data to file: {this.path}", new LogerExtensionException($"Serialized data to file: {this.path}"));
    }
}
