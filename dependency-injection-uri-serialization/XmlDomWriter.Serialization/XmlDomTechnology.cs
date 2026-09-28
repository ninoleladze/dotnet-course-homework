using System.Xml;
using LogerExtensionDelegate;
using Microsoft.Extensions.Logging;
using Serialization;
using UriSerializationHelper;

namespace XmlDomWriter.Serialization;

/// <summary>
/// Presents the serialization functionality of the sequence<see cref="IEnumerable{Uri}"/>
/// with using XML-DOM model.
/// </summary>
public class XmlDomTechnology : IDataSerializer<Uri>
{
    private readonly string path;
    private readonly ILogger<XmlDomTechnology>? logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="XmlDomTechnology"/> class.
    /// </summary>
    /// <param name="path">The path to json file.</param>
    /// <param name="logger">The logger.</param>
    /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
    public XmlDomTechnology(string? path, ILogger<XmlDomTechnology>? logger = default)
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

        var document = new XmlDocument();
        document.AppendChild(document.CreateXmlDeclaration("1.0", "utf-8", null));

        var root = document.CreateElement("uriAdresses");
        document.AppendChild(root);

        foreach (var uri in source)
        {
            var address = uri.ToSerializableObject();

            var addressElement = document.CreateElement("uriAdress");

            var schemeElement = document.CreateElement("scheme");
            schemeElement.SetAttribute("name", address.Scheme);
            addressElement.AppendChild(schemeElement);

            var hostElement = document.CreateElement("host");
            hostElement.SetAttribute("name", address.Host);
            addressElement.AppendChild(hostElement);

            var pathElement = document.CreateElement("path");
            foreach (var segment in address.Path)
            {
                var segmentElement = document.CreateElement("segment");
                segmentElement.InnerText = segment;
                pathElement.AppendChild(segmentElement);
            }

            addressElement.AppendChild(pathElement);

            if (address.Query.Count > 0)
            {
                var queryElement = document.CreateElement("query");
                foreach (var parameter in address.Query)
                {
                    var parameterElement = document.CreateElement("parameter");
                    parameterElement.SetAttribute("key", parameter.Key);
                    parameterElement.SetAttribute("value", parameter.Value);
                    queryElement.AppendChild(parameterElement);
                }

                addressElement.AppendChild(queryElement);
            }

            root.AppendChild(addressElement);
        }

        document.Save(this.path);

        LogerExtension.FastLoggerMessage(this.logger, $"Serialized data to file: {this.path}", new LogerExtensionException($"Serialized data to file: {this.path}"));
    }
}
