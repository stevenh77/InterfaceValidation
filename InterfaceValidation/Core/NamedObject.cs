using System.Xml.Serialization;

namespace InterfaceValidation.Core
{
    public class NamedObject
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        public NamedObject(string name)
        {
            Name = name;
        }
    }
}