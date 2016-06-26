using System.Xml.Serialization;

namespace InterfaceValidation.Core
{
    public class IsRequiredObject : NamedObject
    {
        [XmlAttribute("IsRequired")]
        public bool IsRequired { get; set; }

        public IsRequiredObject(string name, bool isRequired) : base(name)
        {
            IsRequired = isRequired;
        }
    }
}