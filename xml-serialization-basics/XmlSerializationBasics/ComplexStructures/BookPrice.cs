using System.Xml.Serialization;

namespace XmlSerializationBasics.ComplexStructures;

public class BookPrice
{
    [XmlAttribute("currency")]
    public string? Currency { get; set; }

    [XmlElement("price")]
    public decimal Price { get; set; }
}
