using System.Xml;
using LogerExtensionDelegate;
using Microsoft.Extensions.Logging;
using Serialization;
using UriSerializationHelper;

namespace XmlWriter.Serialization;

/// <summary>
/// Presents the serialization functionality of the sequence<see cref="IEnumerable{Uri}"/>
/// with using XmlWriter class.
/// </summary>
public class XmlWriterTechnology : IDataSerializer<Uri>
{
    private readonly string path;
    private readonly ILogger<XmlWriterTechnology>? logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="XmlWriterTechnology"/> class.
    /// </summary>
    /// <param name="path">The path to json file.</param>
    /// <param name="logger">The logger.</param>
    /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
    public XmlWriterTechnology(string? path, ILogger<XmlWriterTechnology>? logger = default)
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

        var settings = new XmlWriterSettings { Indent = true };
        using var writer = System.Xml.XmlWriter.Create(this.path, settings);

        writer.WriteStartDocument();
        writer.WriteStartElement("uriAdresses");

        foreach (var uri in source)
        {
            var address = uri.ToSerializableObject();

            writer.WriteStartElement("uriAdress");

            writer.WriteStartElement("scheme");
            writer.WriteAttributeString("name", address.Scheme);
            writer.WriteEndElement();

            writer.WriteStartElement("host");
            writer.WriteAttributeString("name", address.Host);
            writer.WriteEndElement();

            writer.WriteStartElement("path");
            foreach (var segment in address.Path)
            {
                writer.WriteElementString("segment", segment);
            }

            writer.WriteEndElement();

            if (address.Query.Count > 0)
            {
                writer.WriteStartElement("query");
                foreach (var parameter in address.Query)
                {
                    writer.WriteStartElement("parameter");
                    writer.WriteAttributeString("key", parameter.Key);
                    writer.WriteAttributeString("value", parameter.Value);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        writer.WriteEndElement();
        writer.WriteEndDocument();

        LogerExtension.FastLoggerMessage(this.logger, $"Serialized data to file: {this.path}", new LogerExtensionException($"Serialized data to file: {this.path}"));
    }
}
