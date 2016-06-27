using System.Xml.Serialization;

namespace InterfaceValidation.Core
{
    public class Column : IsRequiredObject
    {
        [XmlAttribute("Type")]
        public string Type { get; set; }

        [XmlAttribute("MinLength")]
        public int MinLength { get; set; }

        [XmlAttribute("MaxLength")]
        public int MaxLength { get; set; }

        public Column()
        {
        }
            
        public Column(string name, bool isRequired, string type): base(name, isRequired)
        {
            Type = type;
        }
    }
}