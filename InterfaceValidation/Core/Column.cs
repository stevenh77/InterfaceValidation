using System.Xml.Serialization;

namespace InterfaceValidation.Core
{
    public class Column : IsRequiredObject
    {
        [XmlAttribute("Type")]
        public string Type { get; set; }

        public Column(string name, bool isRequired, string type): base(name, isRequired)
        {
            Type = type;
        }
    }
}