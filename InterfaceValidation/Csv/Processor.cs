using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using InterfaceValidation.Csv.Messages;
using System.Linq;

namespace InterfaceValidation.Csv
{
    public class Processor
    {
        public IEnumerable<ValidationMessage> Execute(ProcessorRequest request)
        {
            var messages = new List<ValidationMessage>();
            var filesInDirectory = ReadFilesInDirectory(request.FileSystem, request.Path);

            request.UnexpectedFile.Validate(messages, 
                                            filesInDirectory, 
                                            request.Files, 
                                            request.FileExtension);

            foreach (var file in request.Files)
            {
                request.RequiredFile.Validate(messages, 
                                                filesInDirectory, 
                                                file);

                if (!filesInDirectory.Contains(file.Name)) continue;

                using (var reader = new StreamReader(file.Name))
                {
                    var line = reader.ReadLine();
                    if (!request.FileChecksum.Read(messages, file.Name, line))
                        continue;

                    line = reader.ReadLine();
                    var columnHeaders = request.DelimiterParser.Get(line);

                    request.RequiredColumn.Validate(messages,   
                                                    file, 
                                                    columnHeaders);

                    request.UnexpectedColumn.Validate(messages, 
                                                        file, 
                                                        columnHeaders);

                    int i = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        i++;
                        var data = request.DelimiterParser.Get(line);
                        request.InvalidDataInColumn.Validate(messages, 
                                                                file, 
                                                                i, 
                                                                columnHeaders, 
                                                                data);
                    }

                    request.FileChecksum.Validate(messages, 
                                                    file.Name, 
                                                    i);
                }
            }
            return messages;
        }

        private IEnumerable<string> ReadFilesInDirectory(IFileSystem fileSystem, string path)
        {
            return fileSystem.Directory
                             .GetFiles(path)
                             .Select(fileSystem.Path.GetFileName);
        }
    }
}