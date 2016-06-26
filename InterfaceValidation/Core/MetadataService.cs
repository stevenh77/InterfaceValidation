using System;
using System.IO;

namespace InterfaceValidation.Core
{
    public class MetadataService : IMetadataService
    {
        public Metadata Get()
        {
            var configFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Files.xml";
            using (Stream reader = new FileStream(configFilePath, FileMode.Open))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Metadata));
                return (Metadata)serializer.Deserialize(reader);
            }
        }
    }
}