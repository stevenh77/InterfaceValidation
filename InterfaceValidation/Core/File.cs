using System.Collections.Generic;
using System.Xml.Serialization;

namespace InterfaceValidation.Core
{
    public class File : IsRequiredObject
    {
        [XmlElement("Column")]
        public List<Column> Columns { get; set; }

        public File()
        {
        }

        public File(string name, bool isRequired): base(name, isRequired)
        {
        }
    }
}