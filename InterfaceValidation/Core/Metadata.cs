using System.Collections.Generic;
using System.Xml.Serialization;

namespace InterfaceValidation.Core
{
    [XmlRoot("Files")]
    public class Metadata
    {
        [XmlAttribute("Path")]
        public string Path { get; set; }

        [XmlAttribute("Delimiter")]
        public string Delimiter { get; set; }

        [XmlAttribute("FileExtension")]
        public string FileExtension { get; set; }

        [XmlElement("File")]
        public List<File> Files { get; set; }
    }
}