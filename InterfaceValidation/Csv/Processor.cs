using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using InterfaceValidation.Csv.Messages;
using InterfaceValidation.Csv.Services;
using InterfaceValidation.Csv.Validators;
using System.Linq;

namespace InterfaceValidation.Csv
{
    public class Processor
    {
        public IEnumerable<ValidationMessage> Execute(IFileSystem fileSystem,
                                                        IEnumerable<Core.File> files,
                                                        string path,
                                                        string fileExtension,
                                                        IDelimiterParser delimiterParser,
                                                        UnexpectedFileValidator unexpectedFileValidator,
                                                        RequiredFileValidator requiredFileValidator,
                                                        FileChecksumValidator fileChecksumValidator,
                                                        RequiredColumnValidator requiredColumnValidator,
                                                        UnexpectedColumnValidator unexpectedColumnValidator,
                                                        InvalidDataInColumnValidator invalidDataInColumnValidator)
        {
            var messages = new List<ValidationMessage>();
            var filesInDirectory = ReadFilesInDirectory(fileSystem, path);

            unexpectedFileValidator.Validate(messages, filesInDirectory, files, fileExtension);

            foreach (var file in files)
            {
                requiredFileValidator.Validate(messages, filesInDirectory, file);
                if (!filesInDirectory.Contains(file.Name)) continue;

                using (var reader = new StreamReader(file.Name))
                {
                    var line = reader.ReadLine();
                    if (!fileChecksumValidator.Read(messages, file.Name, line)) continue;

                    line = reader.ReadLine();
                    var columnHeaders = delimiterParser.Get(line);

                    requiredColumnValidator.Validate(messages, file, columnHeaders);
                    unexpectedColumnValidator.Validate(messages, file, columnHeaders);

                    int i = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        i++;
                        var data = delimiterParser.Get(line);
                        invalidDataInColumnValidator.Validate(messages, file, i, columnHeaders, data);
                    }

                    fileChecksumValidator.Validate(messages, file.Name, i);
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