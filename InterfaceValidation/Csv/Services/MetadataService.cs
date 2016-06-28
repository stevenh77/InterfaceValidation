using System;
using System.IO;
using InterfaceValidation.Core;

namespace InterfaceValidation.Csv.Services
{
    public class MetadataService : IMetadataService
    {
        public Metadata Get()
        {
            var configFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Files.xml";
            using (Stream reader = new FileStream(configFilePath, FileMode.Open))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Metadata));
                var metadata = (Metadata)serializer.Deserialize(reader);

                foreach (var file in metadata.Files)
                    file.FullFilename = string.Concat(metadata.Path, file.Name + "." + metadata.FileExtension);

                return metadata;
            }
        }
    }
}